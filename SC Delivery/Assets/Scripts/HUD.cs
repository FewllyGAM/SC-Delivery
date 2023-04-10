using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class HUD : MonoBehaviour {

    //Script geral da HUD

    public player jogador;
    public ControlaFase controlaFase;

    public RectTransform telaPause;

    public Text capaceteQuant;
    public Text tempoTXT;

    public Image gasAtual;

    public Image vidaCheia;
    public Image vida2;
    public Image vida1;

    public RectTransform painelPerdeu;
    public bool perdeu = false;

    public RectTransform telaPosJogo;
    public Text bonusGas;
    public Text bonusTempo;
    public Text entrega;
    public Text total;
    public Text capacetes;
    public Text contagem;

    public Text tempoConclu;

    public RectTransform trovao;

    public static HUD Instance { get; set; }
    public Image fadeImage;
    bool isInTransition;
    bool isShowing;
    float transition;
    float duration;

    public AudioClip botaoSFX;

    public GameObject configuracoesJ;
    public GameObject opcoesJ;
    public bool configuraAtivo = false;

    public Slider sliderMus;
    public Slider sliderEfei;

    public Image PUcooldownIcon;
    public Image PUAtivo;
    public Image PUPassivo;

    public Sprite spriteVazio;
    public Sprite spritePra;
    public Sprite spriteCP;
    public Sprite spriteMF;
    public Sprite spriteCC;
    public Sprite spriteRL;
    public Sprite spriteM;
    public Sprite spritePro;
    public Sprite spriteCV;

    private void Awake()
    {
        switch (ControlaJogo.instance.ativaEqui)
        {
            case 1:
                PUAtivo.sprite = spritePra;
                break;
            case 2:
                PUAtivo.sprite = spriteCP;
                break;
            case 3:
                PUAtivo.sprite = spriteMF;
                break;
            case 4:
                PUAtivo.sprite = spriteCC;
                break;
            case 5:
                PUAtivo.sprite = spriteVazio;
                break;
        }

        switch (ControlaJogo.instance.passivaEqui)
        {
            case 1:
                PUPassivo.sprite = spriteRL;
                break;
            case 2:
                PUPassivo.sprite = spriteM;
                break;
            case 3:
                PUPassivo.sprite = spritePro;
                break;
            case 4:
                PUPassivo.sprite = spriteCV;
                break;
            case 5:
                PUPassivo.sprite = spriteVazio;
                break;
        }

        sliderMus.value = ControlaAudio.instance.volumeMusica;
        sliderEfei.value = ControlaAudio.instance.volumeEfeitos;
        ControlaAudio.instance.AplicarVolume();

        StartCoroutine("ContagemRe");
        Instance = this;
    }

	void Update () {

        //Controle da HUD, vida, gasolina, etc..
        if (tempoTXT != null)
        {
            if (controlaFase.tempo < 60)
            {
                if (controlaFase.tempo >= 10) tempoTXT.text = "00:" + Mathf.Floor(controlaFase.tempo).ToString();
                else tempoTXT.text = "00:0" + Mathf.Round(controlaFase.tempo).ToString();
            }
            else if (controlaFase.tempo < 120 && controlaFase.tempo >= 60)
            {
                if (controlaFase.tempo - 60 >= 10) tempoTXT.text = "0" + Mathf.Floor(controlaFase.tempo / 60).ToString() + ":" + Mathf.Floor(controlaFase.tempo - 60).ToString();
                else if (controlaFase.tempo - 60 > 9) tempoTXT.text = "0" + Mathf.Floor(controlaFase.tempo / 60).ToString() + ":0" + Mathf.Floor(controlaFase.tempo - 60).ToString();
                else tempoTXT.text = "0" + Mathf.Floor(controlaFase.tempo / 60).ToString() + ":0" + Mathf.Round(controlaFase.tempo - 60).ToString();
            }
            else if (controlaFase.tempo < 180 && controlaFase.tempo >= 120)
            {
                if (controlaFase.tempo - 120 >= 10) tempoTXT.text = "0" + Mathf.Floor(controlaFase.tempo / 60).ToString() + ":" + Mathf.Floor(controlaFase.tempo - 120).ToString();
                else if (controlaFase.tempo - 120 > 9) tempoTXT.text = "0" + Mathf.Floor(controlaFase.tempo / 60).ToString() + ":0" + Mathf.Floor(controlaFase.tempo - 120).ToString();
                else tempoTXT.text = "0" + Mathf.Floor(controlaFase.tempo / 60).ToString() + ":0" + Mathf.Round(controlaFase.tempo - 120).ToString();
            }
            else if (controlaFase.tempo < 240 && controlaFase.tempo >= 180)
            {
                if (controlaFase.tempo - 180 >=  10) tempoTXT.text = "0" + Mathf.Floor(controlaFase.tempo / 60).ToString() + ":" + Mathf.Floor(controlaFase.tempo - 180).ToString();
                else if (controlaFase.tempo - 180 > 9) tempoTXT.text = "0" + Mathf.Floor(controlaFase.tempo / 60).ToString() + ":0" + Mathf.Floor(controlaFase.tempo - 180).ToString();
                else tempoTXT.text = "0" + Mathf.Floor(controlaFase.tempo / 60).ToString() + ":0" + Mathf.Round(controlaFase.tempo - 180).ToString();
            }
            else if (controlaFase.tempo < 300 && controlaFase.tempo >= 240)
            {
                if (controlaFase.tempo - 240 >= 10) tempoTXT.text = "0" + Mathf.Floor(controlaFase.tempo / 60).ToString() + ":" + Mathf.Floor(controlaFase.tempo - 240).ToString();
                else if (controlaFase.tempo - 240 > 9) tempoTXT.text = "0" + Mathf.Floor(controlaFase.tempo / 60).ToString() + ":0" + Mathf.Floor(controlaFase.tempo - 240).ToString();
                else tempoTXT.text = "0" + Mathf.Floor(controlaFase.tempo / 60).ToString() + ":0" + Mathf.Round(controlaFase.tempo - 240).ToString();
            }
        }

        if (gasAtual != null)
            gasAtual.fillAmount = jogador.gasRatio / 4;

        //Escurecimento da tela, ao morre por pipa;
        if (!isInTransition)
            return;
        transition += Time.deltaTime * (1 / duration);
        fadeImage.color = Color.Lerp(new Color(0, 0, 0, 0), Color.black, transition);
        if (transition > 1 || transition < 0)
            isInTransition = false;

    }

    //Atuliza vida
    public void AtualizaVida(int vidaPontos)
    {
        if (vida1 != null)
        {
            if (vidaPontos == 3)
                vidaCheia.gameObject.SetActive(true);
            else if (vidaPontos < 3)
                vidaCheia.gameObject.SetActive(false);
            if (vidaPontos >= 2)
                vida2.gameObject.SetActive(true);
            else if (vidaPontos < 2)
                vida2.gameObject.SetActive(false);
            if (vidaPontos >= 1)
                vida1.gameObject.SetActive(true);
            else if (vidaPontos < 1)
                vida1.gameObject.SetActive(false);
        }
    }

    //Atualiza quantidade capacete
    public void AtualizaCapaceteC(int capacete)
    {
        if (capaceteQuant != null)
            capaceteQuant.text = "x" + capacete;
    }
    
    //Detecta conclusão da fase
    public void terminaFase(float dinheiroGas, float dinheiroTemp, float dinheiroFase, float dinheiroTotal, int capaceteFase)
    {
        if (ControlaJogo.prologoFeito) StartCoroutine(Completou(dinheiroGas, dinheiroTemp, dinheiroFase, dinheiroTotal, capaceteFase));
    }

    //Condição derrota gasolina e tempo
    public void Perdeu_T_G(bool condition)
    {
        perdeu = condition;
    }

    IEnumerator DerrotaDelay()
    {
        yield return new WaitForSeconds(1);
        painelPerdeu.gameObject.SetActive(true);
    }

    //Modulo para escurecimento da tela
    public void Fade(float duracao)
    {
        isInTransition = true;
        duration = duracao;
        transition = 0;
    }

    //Tela pós fase;
    IEnumerator Completou(float dinheiroGas, float dinheiroTemp, float dinheiroFase, float dinheiroTotal, int capaceteFase)
    {
        yield return new WaitForSeconds(3);
        telaPosJogo.gameObject.SetActive(true);
        capacetes.text = "x" + capaceteFase.ToString();
        if (controlaFase.faseNum > 4) tempoConclu.text = (240 - controlaFase.tempo).ToString() + "s";
        yield return new WaitForSeconds(1);
        bonusGas.text = "R$" + Mathf.Ceil(dinheiroGas).ToString() + ",00";
        yield return new WaitForSeconds(1);        
        bonusTempo.text = "R$" + Mathf.Ceil(dinheiroTemp).ToString() + ",00";
        yield return new WaitForSeconds(1);
        entrega.text = "R$" + Mathf.Ceil(dinheiroFase).ToString() + ",00";
        yield return new WaitForSeconds(1.5f);
        total.text = "R$" + Mathf.Ceil(dinheiroTotal).ToString() + ",00";
    }

    //Pausar
    public void PauseGame()
    {
        controlaFase.Pause(true);
        telaPause.gameObject.SetActive(true);
    }
       

    //Despausar
    public void disPause()
    {
        telaPause.gameObject.SetActive(false);
        StartCoroutine("ContagemRe");
    }

    //Morreu
    public void Perdeu()
    {
        StartCoroutine("DerrotaDelay");
        jogador.AlteraVelocidade(0, false);
    }

    IEnumerator ContagemRe()
    {
        contagem.text = "3";
        yield return new WaitForSeconds(1);
        contagem.text = "2";
        yield return new WaitForSeconds(1);
        contagem.text = "1";
        yield return new WaitForSeconds(1);
        contagem.text = "";
        controlaFase.Pause(false);
    }

    public void BotaoSom()
    {
        ControlaAudio.instance.TocaAudio(botaoSFX);
    }

    public void MenuConfigura(bool condition)
    {
        configuraAtivo = condition;
        configuracoesJ.SetActive(condition);
        opcoesJ.SetActive(!condition);

        if (!condition)
        {
            ControlaAudio.instance.VolumeMusica = sliderMus.value;
            ControlaAudio.instance.VolumeEfeitos = sliderEfei.value;
            ControlaAudio.instance.AplicarVolume();
        }
    }

    //Efeito Trovao
    public void Trovao()
    {
        StartCoroutine("TrovaoClarao");
    }

    IEnumerator TrovaoClarao()
    {
        trovao.gameObject.SetActive(true);
        yield return new WaitForSeconds(0.05f);
        trovao.gameObject.SetActive(false);
        yield return new WaitForSeconds(0.1f);
        trovao.gameObject.SetActive(true);
        yield return new WaitForSeconds(0.06f);
        trovao.gameObject.SetActive(false);
    }

    //Recarga skill
    public IEnumerator AtivaCD(float cooldownAtu, float cooldownMax)
    {
        PUcooldownIcon.enabled = true;
        PUcooldownIcon.fillAmount = cooldownAtu / cooldownMax;
        float cooldownPor;
        float cooldownAt = cooldownAtu;
        while (cooldownAt > 0)
        {
            if (ControlaFase.isPaused) break;
            cooldownPor = cooldownAt / cooldownMax;
            PUcooldownIcon.fillAmount = cooldownPor;
            cooldownAt -= 0.1f;
            yield return new WaitForSeconds(0.1f);
        }
        if (!ControlaFase.isPaused) PUcooldownIcon.enabled = false;
    }
}
