using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ControlaFase : MonoBehaviour {

    //Script geral;
    public int faseNum;

    public float tempo;

    public float pagamentoEntrega;
    float dinheiroTotal = 0;

    public player jogador;
    public HUD hud;

    bool pauseIsLock = false;
    public bool perdeu = false;


    public static bool isPaused;

    public bool isBS_SC;

    public bool isProlog;

    bool umavez = false;
    int randNum;

    public AudioClip musicaFase;
    public AudioClip chuvaSFX;
    public AudioClip trovaoSFX;
    public AudioClip gameOverSFX;
    public AudioClip botaoSFX;

    float cdPausado;
    float cdPausadoMax;

    private void Start()
    {
        if (isProlog) ControlaJogo.instance.EscolheChar("Josue");

        ControlaAudio.instance.TocaMusica(musicaFase);

        jogador.RecebeValor(pagamentoEntrega);
        isPaused = true;
        hud.disPause();

        if (isBS_SC)
        {
            ControlaAudio.instance.TocaEfeitoDeFundoLoop(chuvaSFX);
            StartCoroutine("TocaTrovao");
        }
        
    }

    void FixedUpdate () {

        if (!isPaused && !perdeu && !jogador.completou)
        {
            tempo = Mathf.Clamp(tempo, 0, 300);
            if (!jogador.completou) tempo -= Time.deltaTime;
        }

        if (tempo <= 0 && !perdeu)
        {
            StartCoroutine(Derrota(true, 0));
        }
	}

    private void Update()
    {
        //Pause
        if (!pauseIsLock)
        {
            if (isPaused)
            {
                if (Input.GetKeyDown(KeyCode.Escape) && umavez && !hud.configuraAtivo)
                {
                    umavez = false;
                    hud.disPause();
                    StartCoroutine("DespausaPU");
                }
            }
            if (Input.GetKeyDown(KeyCode.Escape) && !isPaused)
            {
                hud.PauseGame();
            }
        }

    }

    //Recebe mudança de tempo
    public void MudaTempo(float valor)
    {
        tempo += valor;
    }


    //Despausa Habilidades
    IEnumerator DespausaPU()
    {
        yield return new WaitForSeconds(3.1f);
        StartCoroutine(jogador.TempoRecarga(cdPausado, cdPausadoMax));
    }
    //Recebe Cooldown
    public void RecebeCD(float cooldownAt, float cooldownMax)
    {
        cdPausado = cooldownAt;
        cdPausadoMax = cooldownMax;
    }

    //Verifica derrota do player
    public IEnumerator Derrota(bool condition, float delay)
    {
        TravaPause(true);
        yield return new WaitForSeconds(delay);
        ControlaAudio.instance.TocaAudio(gameOverSFX);
        perdeu = condition;
        hud.Perdeu();
        yield return new WaitForSeconds(2);
        isPaused = true;
    }

    //Verifica termino da fase
    public void Terminou()
    {        
        ControlaJogo.instance.Salvar();
        TravaPause(true);
        if (!ControlaJogo.prologoFeito) Invoke("ProximaCena", 3);
    }

    //Pause
    public void Pause(bool condition)
    {
        isPaused = condition;
        umavez = true;
        ControlaAudio.instance.PausaAudios(condition);
        if (condition && jogador.audioMoto != null) jogador.audioMoto.Stop();
        if (!condition) jogador.audioMoto.Play();
    }

    //Reinicia fase
    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        isPaused = false;
    }

    //Proxima Cena
    public void ProximaCena()
    {
        SceneManager.LoadScene("CinematicPart_2");
    }

    //Trava pause
    public void TravaPause(bool condition)
    {
        pauseIsLock = condition;
    }

    public void VoltaMenu(string menu)
    {
        ControlaAudio.instance.ParaAudios();
        SceneManager.LoadScene(menu);
    }

    public void DinheiroTotalFase(float valor)
    {
        dinheiroTotal = valor;
        ControlaJogo.instance.AtualizaRank(faseNum, dinheiroTotal);
    }

    //Trovao
    IEnumerator TocaTrovao()
    {
        while (!jogador.completou)
        {
            yield return new WaitForSeconds(10);
            randNum = Random.Range(0, 10);
            if (randNum <= 6)
            {
                hud.Trovao();
                yield return new WaitForSeconds(1);
                ControlaAudio.instance.TocaEfeitoDeFundo(trovaoSFX);
            }
        }
    }

}
