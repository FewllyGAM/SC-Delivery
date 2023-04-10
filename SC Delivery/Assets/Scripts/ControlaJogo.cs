using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlaJogo : MonoBehaviour {

    public static ControlaJogo instance = null;

    public static bool prologoFeito = false;
    public bool primeiroInicio = true;

    public string escolhaPerso;

    public int escolha = 2;

    public int capaceteTotal;
    public float dinheiroTotal;

    public float maiorReConq = 0;
    public float maiorReBeSe = 0;
    public float maiorReRiOu = 0;
    public float maiorReSaCr = 0;

    public AudioClip compraSFX;

    //Ativas e passivas;
    public int ativaEqui = 5;
    public int passivaEqui = 5;

    //Variaveis dos powerups
    public float motoFantasmaCD = 25;
    public int motoFantasmaLVL = 0;
    public float motoFantasmaUpPrice = 150;
    public int motoFantasmaPrice = 3;
    public bool comprouMF = false;

    public float cortaPipaCD = 30;
    public int cortaPipaLVL = 0;
    public float cortaPipaUpPrice = 75;
    public int cortaPipaPrice = 1;
    public bool comprouCP = false;

    public float pranchaCD = 30;
    public int pranchaLVL = 0;
    public float pranchaUpPrice = 80;
    public int pranchaPrice = 1;
    public bool comprouPra = false;

    public float canhaoComidaCD = 20;
    public float canhaoTax = 0.5f;
    public int canhaoLVL = 0;
    public float canhaoUpPrice = 200;
    public int canhaoPrice = 3;
    public bool comprouCC = false;


    public float coletaVitalTemp = 1.5f;
    public int coletaVitalLVL = 0;
    public float coletaVitalUpPrice = 90;
    public int coletaVitalPrice = 1;
    public bool comprouCV = false;

    public float reparoLentoTemp = 2;
    public int reparoLentoPisc = 5;
    public int reparoLentoLVL = 0;
    public float reparoLentoUpPrice = 120;
    public int reparoLentoPrice = 1;
    public bool comprouRL = false;

    public float propulsorForce = 3;
    public int propulsorLVL = 0;
    public float propulsorUpPrice = 160;
    public int propulsorPrice = 2;
    public bool comprouPro = false;

    public int molaPrice = 1;
    public bool comprouM = false;

    //Fazer existir apenas 1 e não ser destruído
    private void Awake()
    {
        if (instance == null)
            instance = this;
        else if (instance != this)
            Destroy(gameObject);

        DontDestroyOnLoad(this);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.D))
        {
            Debug.Log("Deletou");
            PlayerPrefs.DeleteAll();
        }
            
    }

    //Personagem escolhido
    public void EscolheChar(string nome)
    {
        escolhaPerso = nome;
    }

    //Função de comprar PowerUp
    public void ComprarPU(int numPU)
    {
        switch (numPU)
        {
            case 1:
                if (capaceteTotal >= pranchaPrice && !comprouPra)
                {
                    ControlaAudio.instance.TocaAudio(compraSFX);
                    comprouPra = true;
                    capaceteTotal -= pranchaPrice;
                }
                break;
            case 2:
                if (capaceteTotal >= cortaPipaPrice && !comprouCP)
                {
                    ControlaAudio.instance.TocaAudio(compraSFX);
                    comprouCP = true;
                    capaceteTotal -= cortaPipaPrice;
                }
                break;
            case 3:
                if (capaceteTotal >= motoFantasmaPrice && !comprouMF)
                {
                    ControlaAudio.instance.TocaAudio(compraSFX);
                    comprouMF = true;
                    capaceteTotal -= motoFantasmaPrice;
                }
                break;
            case 4:
                if (capaceteTotal >= canhaoPrice && !comprouCC)
                {
                    ControlaAudio.instance.TocaAudio(compraSFX);
                    comprouCC = true;
                    capaceteTotal -= canhaoPrice;
                }
                break;
            case 5:
                if (capaceteTotal >= reparoLentoPrice && !comprouRL)
                {
                    ControlaAudio.instance.TocaAudio(compraSFX);
                    comprouRL = true;
                    capaceteTotal -= reparoLentoPrice;
                }
                break;
            case 6:
                if (capaceteTotal >= molaPrice && !comprouM)
                {
                    ControlaAudio.instance.TocaAudio(compraSFX);
                    comprouM = true;
                    capaceteTotal -= molaPrice;
                }
                break;
            case 7:
                if (capaceteTotal >= propulsorPrice && !comprouPro)
                {
                    ControlaAudio.instance.TocaAudio(compraSFX);
                    comprouPro = true;
                    capaceteTotal -= propulsorPrice;
                }
                break;
            case 8:
                if (capaceteTotal >= coletaVitalPrice && !comprouCV)
                {
                    ControlaAudio.instance.TocaAudio(compraSFX);
                    comprouCV = true;
                    capaceteTotal -= coletaVitalPrice;
                }
                break;

        }
    }

    //Funções de Upgrade dos powerups
    public void MFUpgrade()
    {
        if (motoFantasmaLVL < 5)
        {
            ControlaAudio.instance.TocaAudio(compraSFX);
            dinheiroTotal -= motoFantasmaUpPrice;
            motoFantasmaCD *= 0.9f;
            motoFantasmaUpPrice *= 1.5f;
            motoFantasmaLVL += 1;            
        }
    }

    public void CPUpgrade()
    {
        if (cortaPipaLVL < 5)
        {
            ControlaAudio.instance.TocaAudio(compraSFX);
            dinheiroTotal -= cortaPipaUpPrice;
            cortaPipaCD *= 0.8f;
            cortaPipaUpPrice *= 1.4f;
            cortaPipaLVL += 1;           
        }
    }

    public void PraUpgrade()
    {
        if (pranchaLVL < 5)
        {
            ControlaAudio.instance.TocaAudio(compraSFX);
            dinheiroTotal -= pranchaUpPrice;
            pranchaCD *= 0.8f;
            pranchaUpPrice *= 1.4f;
            pranchaLVL += 1;            
        }
    }

    public void CCUpgrade()
    {
        if (canhaoLVL < 5)
        {
            ControlaAudio.instance.TocaAudio(compraSFX);
            dinheiroTotal -= canhaoUpPrice;
            canhaoComidaCD *= 0.9f;
            canhaoTax *= 0.7f;
            canhaoUpPrice *= 1.6f;
            canhaoLVL += 1;            
        }
    }

    public void CVUpgrade()
    {
        if (coletaVitalLVL < 5)
        {
            ControlaAudio.instance.TocaAudio(compraSFX);
            dinheiroTotal -= coletaVitalUpPrice;
            coletaVitalTemp *= 1.3f;
            coletaVitalUpPrice *= 1.5f;
            coletaVitalLVL += 1;            
        }
    }

    public void ProUpgrade()
    {
        if (propulsorLVL < 5)
        {
            ControlaAudio.instance.TocaAudio(compraSFX);
            dinheiroTotal -= propulsorUpPrice;
            propulsorForce *= 1.3f;
            propulsorUpPrice *= 1.7f;
            propulsorLVL += 1;
        }
    }

    public void RLUpgrade()
    {
        if (reparoLentoLVL < 5)
        {
            ControlaAudio.instance.TocaAudio(compraSFX);
            dinheiroTotal -= reparoLentoUpPrice;
            reparoLentoTemp *= 1.25f;
            reparoLentoPisc += 1;
            reparoLentoUpPrice *= 1.3f;
            reparoLentoLVL += 1;
        }
    }

    public void EquipaItem(int num)
    {
        switch (num)
        {
            case 1:
                ativaEqui = 1;
                break;
            case 2:
                ativaEqui = 2;
                break;
            case 3:
                ativaEqui = 3;
                break;
            case 4:
                ativaEqui = 4;
                break;
            case 5:
                passivaEqui = 1;
                break;
            case 6:
                passivaEqui = 2;
                break;
            case 7:
                passivaEqui = 3;
                break;
            case 8:
                passivaEqui = 4;
                break;
            case 9:
                ativaEqui = 5;
                break;
            case 10:
                passivaEqui = 5;
                break;
        }
    }

    public void AtualizaRank(int num, float valor)
    {
        switch (num)
        {
            case 1:
                if (valor > maiorReConq) maiorReConq = valor;
                break;
            case 2:
                if (valor > maiorReBeSe) maiorReBeSe = valor;
                break;
            case 3:
                if (valor > maiorReRiOu) maiorReRiOu = valor;
                break;
            case 4:
                if (valor > maiorReSaCr) maiorReSaCr = valor;
                break;
        }
    }

    //Salvar e Carregar;
    public void Salvar()
    {
        //Salva bools
        PlayerPrefs.SetInt("comprouPra", comprouPra ? 1 : 0);
        PlayerPrefs.SetInt("comprouCP", comprouCP ? 1 : 0);
        PlayerPrefs.SetInt("comprouMF", comprouMF ? 1 : 0);
        PlayerPrefs.SetInt("comprouCC", comprouCC ? 1 : 0);
        PlayerPrefs.SetInt("comprouRL", comprouRL ? 1 : 0);
        PlayerPrefs.SetInt("comprouM", comprouM ? 1 : 0);
        PlayerPrefs.SetInt("comprouPro", comprouPro ? 1 : 0);
        PlayerPrefs.SetInt("comprouCV", comprouCV ? 1 : 0);
        PlayerPrefs.SetInt("prologoFeito", prologoFeito ? 1 : 0);
        PlayerPrefs.SetInt("primeiroInicio", primeiroInicio ? 1 : 0);

        //Salva dinheiro/capacete, itens equipados, ranks;
        PlayerPrefs.SetFloat("dinheiroTotal", dinheiroTotal);
        PlayerPrefs.SetInt("capaceteTotal", capaceteTotal);
        PlayerPrefs.SetInt("ativaEqui", ativaEqui);
        PlayerPrefs.SetInt("passivaEqui", passivaEqui);
        PlayerPrefs.SetFloat("maiorReConq", maiorReConq);
        PlayerPrefs.SetFloat("maiorReBeSe", maiorReBeSe);
        PlayerPrefs.SetFloat("maiorReRiOu", maiorReRiOu);
        PlayerPrefs.SetFloat("maiorReSaCr", maiorReSaCr);

        //Salva Preços de Upgrade;
        PlayerPrefs.SetFloat("pranchaUpPrice", pranchaUpPrice);
        PlayerPrefs.SetFloat("cortaPipaUpPrice", cortaPipaUpPrice);
        PlayerPrefs.SetFloat("motoFantasmaUpPrice", motoFantasmaUpPrice);
        PlayerPrefs.SetFloat("canhaoUpPrice", canhaoUpPrice);
        PlayerPrefs.SetFloat("reparoLentoUpPrice", reparoLentoUpPrice);
        PlayerPrefs.SetFloat("propulsorUpPrice", propulsorUpPrice);
        PlayerPrefs.SetFloat("coletaVitalUpPrice", coletaVitalUpPrice);

        //Salva Leveis;
        PlayerPrefs.SetInt("pranchaLVL", pranchaLVL);
        PlayerPrefs.SetInt("cortaPipaLVL", cortaPipaLVL);
        PlayerPrefs.SetInt("motoFantasmaLVL", motoFantasmaLVL);
        PlayerPrefs.SetInt("canhaoLVL", canhaoLVL);
        PlayerPrefs.SetInt("reparoLentoLVL", reparoLentoLVL);
        PlayerPrefs.SetInt("propulsorLVL", propulsorLVL);
        PlayerPrefs.SetInt("coletaVitalLVL", coletaVitalLVL);

        //Salva Status;
        PlayerPrefs.SetFloat("pranchaCD", pranchaCD);
        PlayerPrefs.SetFloat("cortaPipaCD", cortaPipaCD);
        PlayerPrefs.SetFloat("motoFantasmaCD", motoFantasmaCD);
        PlayerPrefs.SetFloat("canhaoTax", canhaoTax);
        PlayerPrefs.SetFloat("canhaoComidaCD", canhaoComidaCD);

        PlayerPrefs.SetFloat("reparoLentoTemp", reparoLentoTemp);
        PlayerPrefs.SetInt("reparoLentoPisc", reparoLentoPisc);
        PlayerPrefs.SetFloat("propulsorForce", propulsorForce);
        PlayerPrefs.SetFloat("coletaVitalTemp", coletaVitalTemp);
    }

    public void Carregar()
    {
        //Carrega bools;
        comprouPra = CarregaBool("comprouPra");
        comprouCP = CarregaBool("comprouCP");
        comprouMF = CarregaBool("comprouMF");
        comprouCC = CarregaBool("comprouCC");
        comprouRL = CarregaBool("comprouRL");
        comprouM = CarregaBool("comprouM");
        comprouPro = CarregaBool("comprouPro");
        comprouCV = CarregaBool("comprouCV");
        prologoFeito = CarregaBool("prologoFeito");

        //Carrega dinheiro/capacete, itens equipados, ranks;
        dinheiroTotal = PlayerPrefs.GetFloat("dinheiroTotal");
        capaceteTotal = PlayerPrefs.GetInt("capaceteTotal");
        ativaEqui = PlayerPrefs.GetInt("ativaEqui");        
        passivaEqui = PlayerPrefs.GetInt("passivaEqui");
        maiorReConq = PlayerPrefs.GetFloat("maiorReConq");
        maiorReBeSe = PlayerPrefs.GetFloat("maiorReBeSe");
        maiorReRiOu = PlayerPrefs.GetFloat("maiorReRiOu");
        maiorReSaCr = PlayerPrefs.GetFloat("maiorReSaCr");

        //Carrega Preços de Upgrade;
        pranchaUpPrice = PlayerPrefs.GetFloat("pranchaUpPrice");
        cortaPipaUpPrice = PlayerPrefs.GetFloat("cortaPipaUpPrice");
        motoFantasmaUpPrice = PlayerPrefs.GetFloat("motoFantasmaUpPrice");
        canhaoUpPrice = PlayerPrefs.GetFloat("canhaoUpPrice");
        reparoLentoUpPrice = PlayerPrefs.GetFloat("reparoLentoUpPrice");
        propulsorUpPrice = PlayerPrefs.GetFloat("propulsorUpPrice");
        coletaVitalUpPrice = PlayerPrefs.GetFloat("coletaVitalUpPrice");

        //Carrega Leveis;
        pranchaLVL = PlayerPrefs.GetInt("pranchaLVL");
        cortaPipaLVL = PlayerPrefs.GetInt("cortaPipaLVL");
        motoFantasmaLVL = PlayerPrefs.GetInt("motoFantasmaLVL");
        canhaoLVL = PlayerPrefs.GetInt("canhaoLVL");
        reparoLentoLVL = PlayerPrefs.GetInt("reparoLentoLVL");
        propulsorLVL = PlayerPrefs.GetInt("propulsorLVL");
        coletaVitalLVL = PlayerPrefs.GetInt("coletaVitalLVL");

        //Carrega Status;
        pranchaCD = PlayerPrefs.GetFloat("pranchaCD");
        cortaPipaCD = PlayerPrefs.GetFloat("cortaPipaCD");
        motoFantasmaCD = PlayerPrefs.GetFloat("motoFantasmaCD");
        canhaoTax = PlayerPrefs.GetFloat("canhaoTax");
        canhaoComidaCD = PlayerPrefs.GetFloat("canhaoComidaCD");

        reparoLentoTemp = PlayerPrefs.GetFloat("reparoLentoTemp");
        reparoLentoPisc = PlayerPrefs.GetInt("reparoLentoPisc");
        propulsorForce = PlayerPrefs.GetFloat("propulsorForce");
        coletaVitalTemp = PlayerPrefs.GetFloat("coletaVitalTemp");

    }

    public bool CarregaBool(string nome)
    {
        int valor = PlayerPrefs.GetInt(nome);

        if (valor == 1) return true;
        else return false;
    }

    public void PrimeiroInicio()
    {
        if (PlayerPrefs.HasKey("primeiroInicio")) primeiroInicio = CarregaBool("primeiroInicio");
    }
}
