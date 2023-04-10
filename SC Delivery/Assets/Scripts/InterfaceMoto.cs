using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InterfaceMoto : MonoBehaviour
{

    public Text dinheiroPlayer;

    public GameObject lockPUPra;
    public GameObject lockPUCP;
    public GameObject lockPUMF;
    public GameObject lockPUCC;
    public GameObject lockPURL;
    public GameObject lockPUM;
    public GameObject lockPUPro;
    public GameObject lockPUCV;


    public Text pricePra;
    public Text priceCP;
    public Text priceMF;
    public Text priceCC;
    public Text priceRL;
    public Text pricePro;
    public Text priceCV;

    public Text lvlPra;
    public Text lvlCP;
    public Text lvlMF;
    public Text lvlCC;
    public Text lvlRL;
    public Text lvlPro;
    public Text lvlCV;

    public AudioClip equipaItem;

    public Image ativaEqui;
    public Image passEqui;

    public Sprite spriteVazio;
    public Sprite spritePra;
    public Sprite spriteCP;
    public Sprite spriteMF;
    public Sprite spriteCC;
    public Sprite spriteRL;
    public Sprite spriteM;
    public Sprite spritePro;
    public Sprite spriteCV;

    private void Start()
    {
        dinheiroPlayer.text = "R$" + Mathf.Floor(ControlaJogo.instance.dinheiroTotal).ToString() + ",00";

        //Carregar se estão bloqueados;
        if (ControlaJogo.instance.comprouPra) lockPUPra.SetActive(false);
        if (ControlaJogo.instance.comprouCP) lockPUCP.SetActive(false);
        if (ControlaJogo.instance.comprouMF) lockPUMF.SetActive(false);
        if (ControlaJogo.instance.comprouCC) lockPUCC.SetActive(false);
        if (ControlaJogo.instance.comprouRL) lockPURL.SetActive(false);
        if (ControlaJogo.instance.comprouM) lockPUM.SetActive(false);
        if (ControlaJogo.instance.comprouPro) lockPUPro.SetActive(false);
        if (ControlaJogo.instance.comprouCV) lockPUCV.SetActive(false);

        //Atualizar preços;
        pricePra.text = "R$" + Mathf.Floor(ControlaJogo.instance.pranchaUpPrice).ToString() + ",00";
        priceCP.text = "R$" + Mathf.Floor(ControlaJogo.instance.cortaPipaUpPrice).ToString() + ",00";
        priceMF.text = "R$" + Mathf.Floor(ControlaJogo.instance.motoFantasmaUpPrice).ToString() + ",00";
        priceCC.text = "R$" + Mathf.Floor(ControlaJogo.instance.canhaoUpPrice).ToString() + ",00";
        priceRL.text = "R$" + Mathf.Floor(ControlaJogo.instance.reparoLentoUpPrice).ToString() + ",00";
        pricePro.text = "R$" + Mathf.Floor(ControlaJogo.instance.propulsorUpPrice).ToString() + ",00";
        priceCV.text = "R$" + Mathf.Floor(ControlaJogo.instance.coletaVitalUpPrice).ToString() + ",00";

        //Atualizar levels;
        if (ControlaJogo.instance.pranchaLVL < 5) lvlPra.text = ControlaJogo.instance.pranchaLVL.ToString();
        else lvlPra.text = "MAX";
        if (ControlaJogo.instance.cortaPipaLVL < 5) lvlCP.text = ControlaJogo.instance.cortaPipaLVL.ToString();
        else lvlCP.text = "MAX";
        if (ControlaJogo.instance.motoFantasmaLVL < 5) lvlMF.text = ControlaJogo.instance.motoFantasmaLVL.ToString();
        else lvlMF.text = "MAX";
        if (ControlaJogo.instance.canhaoLVL < 5) lvlCC.text = ControlaJogo.instance.canhaoLVL.ToString();
        else lvlCC.text = "MAX";
        if (ControlaJogo.instance.reparoLentoLVL < 5) lvlRL.text = ControlaJogo.instance.reparoLentoLVL.ToString();
        else lvlRL.text = "MAX";
        if (ControlaJogo.instance.propulsorLVL < 5) lvlPro.text = ControlaJogo.instance.propulsorLVL.ToString();
        else lvlPro.text = "MAX";
        if (ControlaJogo.instance.coletaVitalLVL < 5) lvlCV.text = ControlaJogo.instance.coletaVitalLVL.ToString();
        else lvlCV.text = "MAX";

    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            ControlaJogo.instance.dinheiroTotal += 20;
        }
    }

    public void DesbloqueiaPwUp(int num)
    {
        switch (num)
        {
            case 1:
                if (ControlaJogo.instance.capaceteTotal >= ControlaJogo.instance.pranchaPrice) lockPUPra.SetActive(false);
                break;
            case 2:
                if (ControlaJogo.instance.capaceteTotal >= ControlaJogo.instance.cortaPipaPrice) lockPUCP.SetActive(false);
                break;
            case 3:
                if (ControlaJogo.instance.capaceteTotal >= ControlaJogo.instance.motoFantasmaPrice) lockPUMF.SetActive(false);
                break;
            case 4:
                if (ControlaJogo.instance.capaceteTotal >= ControlaJogo.instance.canhaoPrice) lockPUCC.SetActive(false);
                break;
            case 5:
                if (ControlaJogo.instance.capaceteTotal >= ControlaJogo.instance.reparoLentoPrice) lockPURL.SetActive(false);
                break;
            case 6:
                if (ControlaJogo.instance.capaceteTotal >= ControlaJogo.instance.molaPrice) lockPUM.SetActive(false);
                break;
            case 7:
                if (ControlaJogo.instance.capaceteTotal >= ControlaJogo.instance.propulsorPrice) lockPUPro.SetActive(false);
                break;
            case 8:
                if (ControlaJogo.instance.capaceteTotal >= ControlaJogo.instance.coletaVitalPrice) lockPUCV.SetActive(false);
                break;
        }
    }

    public void UpgradePwUp(int num)
    {
        switch (num)
        {
            case 1:
                if (ControlaJogo.instance.dinheiroTotal >= ControlaJogo.instance.pranchaUpPrice)
                    ControlaJogo.instance.PraUpgrade();
                pricePra.text = "R$" + Mathf.Floor(ControlaJogo.instance.pranchaUpPrice).ToString() + ",00";
                if (ControlaJogo.instance.pranchaLVL < 5) lvlPra.text = ControlaJogo.instance.pranchaLVL.ToString();
                else lvlPra.text = "MAX";
                break;
            case 2:
                if (ControlaJogo.instance.dinheiroTotal >= ControlaJogo.instance.cortaPipaUpPrice)
                    ControlaJogo.instance.CPUpgrade();
                priceCP.text = "R$" + Mathf.Floor(ControlaJogo.instance.cortaPipaUpPrice).ToString() + ",00";
                if (ControlaJogo.instance.cortaPipaLVL < 5) lvlCP.text = ControlaJogo.instance.cortaPipaLVL.ToString();
                else lvlCP.text = "MAX";
                break;
            case 3:
                if (ControlaJogo.instance.dinheiroTotal >= ControlaJogo.instance.motoFantasmaUpPrice)
                    ControlaJogo.instance.MFUpgrade();
                priceMF.text = "R$" + Mathf.Floor(ControlaJogo.instance.motoFantasmaUpPrice).ToString() + ",00";
                if (ControlaJogo.instance.motoFantasmaLVL < 5) lvlMF.text = ControlaJogo.instance.motoFantasmaLVL.ToString();
                else lvlMF.text = "MAX";
                break;
            case 4:
                if (ControlaJogo.instance.dinheiroTotal >= ControlaJogo.instance.canhaoUpPrice)
                    ControlaJogo.instance.CCUpgrade();
                priceCC.text = "R$" + Mathf.Floor(ControlaJogo.instance.canhaoUpPrice).ToString() + ",00";
                if (ControlaJogo.instance.canhaoLVL < 5) lvlCC.text = ControlaJogo.instance.canhaoLVL.ToString();
                else lvlCC.text = "MAX";
                break;
            case 5:
                if (ControlaJogo.instance.dinheiroTotal >= ControlaJogo.instance.reparoLentoUpPrice)
                    ControlaJogo.instance.RLUpgrade();
                priceRL.text = "R$" + Mathf.Floor(ControlaJogo.instance.reparoLentoUpPrice).ToString() + ",00";
                if (ControlaJogo.instance.reparoLentoLVL < 5) lvlRL.text = ControlaJogo.instance.reparoLentoLVL.ToString();
                else lvlRL.text = "MAX";
                break;
            case 7:
                if (ControlaJogo.instance.dinheiroTotal >= ControlaJogo.instance.propulsorUpPrice)
                    ControlaJogo.instance.ProUpgrade();
                pricePro.text = "R$" + Mathf.Floor(ControlaJogo.instance.propulsorUpPrice).ToString() + ",00";
                if (ControlaJogo.instance.propulsorLVL < 5) lvlPro.text = ControlaJogo.instance.propulsorLVL.ToString();
                else lvlPro.text = "MAX";
                break;
            case 8:
                if (ControlaJogo.instance.dinheiroTotal >= ControlaJogo.instance.coletaVitalUpPrice)
                    ControlaJogo.instance.CVUpgrade();
                priceCV.text = "R$" + Mathf.Floor(ControlaJogo.instance.coletaVitalUpPrice).ToString() + ",00";
                if (ControlaJogo.instance.coletaVitalLVL < 5) lvlCV.text = ControlaJogo.instance.coletaVitalLVL.ToString();
                else lvlCV.text = "MAX";
                break;
        }

        dinheiroPlayer.text = "R$" + Mathf.Floor(ControlaJogo.instance.dinheiroTotal).ToString() + ",00";
    }

    public void EquipaItem(int num)
    {
        if (num < 9) ControlaAudio.instance.TocaAudio(equipaItem);
        ControlaJogo.instance.EquipaItem(num);
        switch (num)
        {
            case 1:
                ativaEqui.sprite = spritePra;
                break;
            case 2:
                ativaEqui.sprite = spriteCP;
                break;
            case 3:
                ativaEqui.sprite = spriteMF;
                break;
            case 4:
                ativaEqui.sprite = spriteCC;
                break;
            case 5:
                passEqui.sprite = spriteRL;
                break;
            case 6:
                passEqui.sprite = spriteM;
                break;
            case 7:
                passEqui.sprite = spritePro;
                break;
            case 8:
                passEqui.sprite = spriteCV;
                break;
            case 9:
                ativaEqui.sprite = spriteCV;
                break;
            case 10:
                passEqui.sprite = spriteCV;
                break;
        }
    }

    public void ApareceStatus(GameObject status)
    {
        status.SetActive(true);
    }

    public void SomeStatus(GameObject status)
    {
        status.SetActive(false);
    }
}

