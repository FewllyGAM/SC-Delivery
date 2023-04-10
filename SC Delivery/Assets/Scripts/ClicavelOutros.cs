using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ClicavelOutros : MonoBehaviour {

    public ControlaIntFac controlaInterface;
    public ComputadorInter computador;

    public AudioClip botaoSFX;

    Outline outline;

    public Camera cameraSala;
    public Camera cameraOficina;
    public Transform cameraPC;
    public Transform cameraMoto;
    public Transform cameraOficinaOPos;

    public AudioClip pcSFX;
    public AudioClip motoSFX;
    public AudioClip transiSFX;

    public GameObject pcTela;
    public GameObject menuBotao;

    public GameObject menuMoto;
    public Text dinheiro;

    public GameObject transiOfi;
    public bool naOficina = false;
    bool noPC = false;
    bool naMoto = false;

    bool inTransi = false;

    private void Start()
    {
        outline = GetComponent<Outline>();
    }


    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && !inTransi)
        {
            if (noPC)
            {
                menuBotao.SetActive(true);
                computador.FechaJanelas();
                noPC = false;
                pcTela.SetActive(false);
                StartCoroutine(MudaCamTransform(cameraPC, cameraOficinaOPos, 25, 0.04f));
            }

            else if (naMoto)
            {
                menuBotao.SetActive(true);
                naMoto = false;
                menuMoto.SetActive(false);
                StartCoroutine(MudaCamTransform(cameraMoto, cameraOficinaOPos, 25, 0.04f));
            }

        }
    }

    private void OnMouseEnter()
    {
        if (!controlaInterface.janelaAtiva)
        {
            if (!noPC && !naMoto)
            {
                ControlaAudio.instance.TocaAudio(botaoSFX);
                outline.enabled = true;
            }
        }
    }

    private void OnMouseOver()
    {
        if (Input.GetMouseButtonDown(0) && !noPC && !naMoto)
        {
            if (!controlaInterface.janelaAtiva)
            {
                if (gameObject.name == "ArcoOficina")
                {
                    if (!naOficina) StartCoroutine(MudaCamera(true));
                    else StartCoroutine(MudaCamera(false));
                }
            }

            if (gameObject.name == "Escrivaninha" && !inTransi)
            {
                menuBotao.SetActive(false);
                noPC = true;
                StartCoroutine(MudaCamTransform(cameraOficina.transform, cameraPC, 50, 0.02f));
            }

            if (gameObject.name == "Moto" && !inTransi)
            {
                menuBotao.SetActive(false);
                naMoto = true;
                StartCoroutine(MudaCamTransform(cameraOficina.transform, cameraMoto, 50, 0.02f));
            }
        }
    }

    private void OnMouseExit()
    {
        outline.enabled = false;
    }

    public void SaiPc()
    {
        noPC = false;
        pcTela.SetActive(false);
        StartCoroutine(MudaCamTransform(cameraPC, cameraOficinaOPos, 25, 0.04f));
    }

    public void SaiMoto()
    {
        naMoto = false;
        StartCoroutine(MudaCamTransform(cameraMoto, cameraOficinaOPos, 25, 0.04f));
    }

    IEnumerator MudaCamera(bool condition)
    {
        transiOfi.SetActive(true);
        ControlaAudio.instance.TocaAudio(transiSFX);
        yield return new WaitForSeconds(0.25f);
        cameraSala.enabled = !condition;
        naOficina = condition;
        cameraOficina.enabled = condition;
        transiOfi.SetActive(false);
    }


    //Transição da camera em posição e rotação para posição e rotção de um outro objeto, ticks * intervalo definem o tempo,
    IEnumerator MudaCamTransform(Transform CamOriginal, Transform CamAlvo, int ticksMax, float veloc)
    {
        ControlaAudio.instance.TocaAudio(transiSFX);
        inTransi = true;
        int ticks;
        float tempoMuda = 0;
        for (ticks = 0; ticks < ticksMax; ticks++)
        {
            cameraOficina.transform.position = Vector3.Lerp(CamOriginal.position, CamAlvo.position, tempoMuda);
            cameraOficina.transform.rotation = Quaternion.Lerp(CamOriginal.rotation, CamAlvo.rotation , tempoMuda);
            tempoMuda += veloc;
            yield return new WaitForSeconds(0.01f);
        }
        if (noPC) TransiPC();
        if (naMoto) TransiMoto();
        inTransi = false;

    }

    void TransiPC()
    {
        ControlaAudio.instance.TocaAudio(pcSFX);
        pcTela.SetActive(true);
    }

    void TransiMoto()
    {
        ControlaAudio.instance.TocaAudio(motoSFX);
        dinheiro.text = "R$" + Mathf.Ceil(ControlaJogo.instance.dinheiroTotal).ToString() + ",00";
        menuMoto.SetActive(true);
    }
}
