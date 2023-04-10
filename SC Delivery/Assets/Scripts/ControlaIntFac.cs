using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ControlaIntFac : MonoBehaviour {

    public GameObject janelaOption;

    public bool janelaAtiva = false;

    public AudioClip botaoSFX;
    public AudioClip bgMusicMenu;

    public ClicavelOutros arco;

    private void Start()
    {
        ControlaJogo.instance.Salvar();
        if (!ControlaAudio.instance.bgMusic.isPlaying) ControlaAudio.instance.TocaMusica(bgMusicMenu);
    }

    public void IrFaseSelecionada(string nomeFase)
    {
        ControlaAudio.instance.ParaAudios();
        SceneManager.LoadScene(nomeFase);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && !arco.naOficina)
        {
            if (janelaAtiva) VoltarASelecionar();
            else VoltaMenu();
        }
    }

    public void AtivaJanela()
    {
        janelaAtiva = true;
    }

    public void VoltarASelecionar()
    {
        janelaOption.SetActive(false);
        janelaAtiva = false;
    }

    public void BotaoSom()
    {
        ControlaAudio.instance.TocaAudio(botaoSFX);
    }

    public void VoltaMenu()
    {
        SceneManager.LoadScene("Menu");
    }

}
