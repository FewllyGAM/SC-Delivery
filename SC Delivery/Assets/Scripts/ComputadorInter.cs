using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ComputadorInter : MonoBehaviour {

    public GameObject telaPrincipal;
    public GameObject telaLoja;
    public GameObject telaConquista;
    public GameObject telaRank;

    public InterfaceMoto interMoto;

    public AudioClip click;

    public Text capaceteQuant;

    public Text rankConq;
    public Text rankBeSe;
    public Text rankRiOu;
    public Text rankSaCr;

    public Image checkPra;
    public Image checkCP;
    public Image checkMF;
    public Image checkCC;
    public Image checkRL;
    public Image checkM;
    public Image checkPro;
    public Image checkCV;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            ControlaJogo.instance.capaceteTotal += 1;
        }
    }

    public void MudaTelaLoja(bool condi)
    {
        capaceteQuant.text = ControlaJogo.instance.capaceteTotal.ToString() + "x";

        if (ControlaJogo.instance.comprouPra) checkPra.enabled = true;
        if (ControlaJogo.instance.comprouCP) checkCP.enabled = true;
        if (ControlaJogo.instance.comprouMF) checkMF.enabled = true;
        if (ControlaJogo.instance.comprouCC) checkCC.enabled = true;
        if (ControlaJogo.instance.comprouRL) checkRL.enabled = true;
        if (ControlaJogo.instance.comprouM) checkM.enabled = true;
        if (ControlaJogo.instance.comprouPro) checkPro.enabled = true;
        if (ControlaJogo.instance.comprouCV) checkCV.enabled = true;

        ControlaAudio.instance.TocaAudio(click);
        telaPrincipal.SetActive(!condi);
        telaLoja.SetActive(condi);
    }

    public void MudaTelaConq(bool condi)
    {
        ControlaAudio.instance.TocaAudio(click);
        telaPrincipal.SetActive(!condi);
        telaConquista.SetActive(condi);
    }

    public void MudaTelaRank(bool condi)
    {
        rankConq.text = "R$" + Mathf.Floor(ControlaJogo.instance.maiorReConq).ToString() + ",00";
        rankBeSe.text = "R$" + Mathf.Floor(ControlaJogo.instance.maiorReBeSe).ToString() + ",00";
        rankRiOu.text = "R$" + Mathf.Floor(ControlaJogo.instance.maiorReRiOu).ToString() + ",00";
        rankSaCr.text = "R$" + Mathf.Floor(ControlaJogo.instance.maiorReSaCr).ToString() + ",00";

        ControlaAudio.instance.TocaAudio(click);
        telaPrincipal.SetActive(!condi);
        telaRank.SetActive(condi);
    }

    public void FechaJanelas()
    {
        telaLoja.SetActive(false);
        telaConquista.SetActive(false);
        telaRank.SetActive(false);
        telaPrincipal.SetActive(true);
    }

    public void CompraPowerUp(int num)
    {        
        ControlaJogo.instance.ComprarPU(num);
        interMoto.DesbloqueiaPwUp(num);
        StartCoroutine("AtualizaCapa");
        switch (num)
        {
            case 1:
                if (ControlaJogo.instance.capaceteTotal >= ControlaJogo.instance.pranchaPrice)
                    checkPra.enabled = true;
                break;
            case 2:
                if (ControlaJogo.instance.capaceteTotal >= ControlaJogo.instance.cortaPipaPrice)
                    checkCP.enabled = true;
                break;
            case 3:
                if (ControlaJogo.instance.capaceteTotal >= ControlaJogo.instance.motoFantasmaPrice)
                    checkMF.enabled = true;
                break;
            case 4:
                if (ControlaJogo.instance.capaceteTotal >= ControlaJogo.instance.canhaoPrice)
                    checkCC.enabled = true;
                break;
            case 5:
                if (ControlaJogo.instance.capaceteTotal >= ControlaJogo.instance.reparoLentoPrice)
                    checkRL.enabled = true;
                break;
            case 6:
                if (ControlaJogo.instance.capaceteTotal >= ControlaJogo.instance.molaPrice)
                    checkM.enabled = true;
                break;
            case 7:
                if (ControlaJogo.instance.capaceteTotal >= ControlaJogo.instance.propulsorPrice)
                    checkPro.enabled = true;
                break;
            case 8:
                if (ControlaJogo.instance.capaceteTotal >= ControlaJogo.instance.coletaVitalPrice)
                    checkCV.enabled = true;
                break;
        }
    }

    IEnumerator AtualizaCapa()
    {
        yield return new WaitForSeconds(0.1f);
        capaceteQuant.text = ControlaJogo.instance.capaceteTotal.ToString() + "x";
    }
}
