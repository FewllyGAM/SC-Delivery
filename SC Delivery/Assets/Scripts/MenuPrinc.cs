using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuPrinc : MonoBehaviour
{
    public GameObject realmenteSair;
    public GameObject layout1;
    public GameObject configuracoes;
    public GameObject creditos;

    public AudioClip bgMusicMenu;
    public AudioClip botaoSFX;

    public Slider sliderMus;
    public Slider sliderEfei;

    bool RSativo;
    bool outroMenu;

    Resolution[] resolutions;
    public Dropdown listaResolutions;

    private void Start()
    {
        ControlaJogo.instance.primeiroInicio = false;
        ControlaJogo.instance.Salvar();

        resolutions = Screen.resolutions;        

        listaResolutions.ClearOptions();
        List<string> opcoes = new List<string>();

        int resolucaoAtual = 0;
        for (int i = 0; i < resolutions.Length; i++)
        {
            string opcao = resolutions[i].width + "x" + resolutions[i].height;
            opcoes.Add(opcao);

            if (resolutions[i].width == Screen.currentResolution.width &&
                resolutions[i].height == Screen.currentResolution.height)
            {
                resolucaoAtual = i;
            }
        }

        listaResolutions.AddOptions(opcoes);
        listaResolutions.value = resolucaoAtual;
        listaResolutions.RefreshShownValue();

        if (!ControlaAudio.instance.bgMusic.isPlaying) ControlaAudio.instance.TocaMusica(bgMusicMenu);
        RSativo = false;

        sliderEfei.value = ControlaAudio.instance.volumeEfeitos;
        sliderMus.value = ControlaAudio.instance.volumeMusica;
    }

    public void Jogar()
    {        
        if (!ControlaJogo.prologoFeito) SceneManager.LoadScene("CinematicPart_1");
        else SceneManager.LoadScene("InteriorEmpresa");
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (!RSativo && !outroMenu)
            {
                realmenteSair.SetActive(true);
                RSativo = true;
            }
            else if (RSativo)
            {
                realmenteSair.SetActive(false);
                RSativo = false;
            }
            else
            {
                MenuConfigura(true);
                MenuCreditos(true);
            }
        }
    }

    public void AbrirFechar()
    {
        if (!RSativo)
        {
            realmenteSair.SetActive(true);
            RSativo = true;
        }
        else
        {
            realmenteSair.SetActive(false);
            RSativo = false;
        }
    }

    public void MenuConfigura(bool isAtivado)
    {       
        if (!isAtivado)
        {
            outroMenu = true;
            layout1.SetActive(false);
            configuracoes.SetActive(true);
        }
        else
        {
            ControlaAudio.instance.VolumeMusica = sliderMus.value;
            ControlaAudio.instance.VolumeEfeitos = sliderEfei.value;

            ControlaAudio.instance.AplicarVolume();
            outroMenu = false;
            layout1.SetActive(true);
            configuracoes.SetActive(false);
        }
    }

    public void MenuCreditos(bool isAtivado)
    {
        if (!isAtivado)
        {
            outroMenu = true;
            layout1.SetActive(false);
            creditos.SetActive(true);
        }
        else
        {
            outroMenu = false;
            layout1.SetActive(true);
            creditos.SetActive(false);
        }
    }

    public void BotaoSom()
    {
        ControlaAudio.instance.TocaAudio(botaoSFX);
    }

    public void AtualizaResolu(int indice)
    {
        Resolution resolution = resolutions[indice];
        Screen.SetResolution(resolution.width, resolution.height, Screen.fullScreen);
    }

    public void Qualidade(int indice)
    {
        QualitySettings.SetQualityLevel(indice);
    }

    public void TelaCheia(bool isFull)
    {
        Screen.fullScreen = isFull;
    }

    public void Resolution()
    {
        
    }

    public void SairJogo()
    {
        Application.Quit();
    }

}
