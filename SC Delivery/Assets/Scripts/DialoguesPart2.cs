using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class DialoguesPart2 : MonoBehaviour {

    public AudioClip musicaFunk;
    public AudioClip campanhiaSFX;
    public AudioClip portaAbreSFX;

    public Text falasJosue;
    public Text falasPietro;

    public RectTransform nomeJosue;
    public RectTransform nomePietro;
    public RectTransform nomePietro2;

    public Sprite j_normalCp;
    public Sprite j_impacienteCp;
    public Sprite j_normal;
    public Sprite j_surpreso;
    public Sprite j_surpreso2;
    public Sprite j_sorrindo;
    public Sprite j_rindo;

    public Sprite p_rindo;
    public Sprite p_rindomal;
    public Sprite p_sorriso;
    public Sprite p_sorrisomal;

    public Image josue;
    public Image pietro;

    public Image josueFa;
    public Image pietroFa;

    public int cont = 1;

    private void Start()
    {
        ControlaAudio.instance.TocaMusica(musicaFunk);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.RightArrow))
            Dialogo2();
    }

    public void Dialogo2()
    {
        cont++;

        if (cont == 2)
        {
            ControlaAudio.instance.TocaAudio(campanhiaSFX);
            falasJosue.text = "";
            falasPietro.text = "";
           
        }
        if (cont == 3)
        {
            josue.enabled = true;
            josueFa.enabled = false;

            falasJosue.text = "";
            falasPietro.text = "Quem é?";

            nomeJosue.gameObject.SetActive(false);
            nomePietro.gameObject.SetActive(true);
        }
        if (cont == 4)
        {
            josue.enabled = false;
            josueFa.enabled = true;

            josue.sprite = j_impacienteCp;
            falasJosue.text = "Foi aqui que pediram um sequestro a mão armada?";
            falasPietro.text = "";

            nomeJosue.gameObject.SetActive(true);
            nomePietro.gameObject.SetActive(false);
        }
        if (cont == 5)
        {
            josue.enabled = true;
            josueFa.enabled = false;

            falasJosue.text = "";
            falasPietro.text = "Que? Como?";

            nomeJosue.gameObject.SetActive(false);
            nomePietro.gameObject.SetActive(true);
        }
        if (cont == 6)
        {
            josue.enabled = false;
            josueFa.enabled = true;

            josue.sprite = j_normalCp;
            falasJosue.text = "Sua pizza de calabresa senhor";
            falasPietro.text = "";

            nomeJosue.gameObject.SetActive(true);
            nomePietro.gameObject.SetActive(false);
        }
        if (cont == 7)
        {
            josue.enabled = true;
            josueFa.enabled = false;

            falasJosue.text = "";
            falasPietro.text = "Ah sim! Ha ha ha!";

            nomeJosue.gameObject.SetActive(false);
            nomePietro.gameObject.SetActive(true);
        }
        if (cont == 8)
        {
            pietroFa.enabled = true;

            ControlaAudio.instance.TocaAudio(portaAbreSFX);
            falasJosue.text = "";
            falasPietro.text = "Você me deu um susto garoto! Ha ha ha!";

            nomeJosue.gameObject.SetActive(false);
        }
        if (cont == 9)
        {
            josue.enabled = pietroFa.enabled = false;
            josueFa.enabled = pietro.enabled = true;

            falasJosue.text = "Sua pizza senhor;  são vinte reais";
            falasPietro.text = "";

            nomeJosue.gameObject.SetActive(true);
            nomePietro.gameObject.SetActive(false);
        }
        if (cont == 10)
        {
            josue.enabled = pietroFa.enabled = true;
            josueFa.enabled = pietro.enabled = false;

            pietro.sprite = p_sorriso;
            falasJosue.text = "";
            falasPietro.text = "Aquí está\nNão precisa de troco";

            nomeJosue.gameObject.SetActive(false);
            nomePietro.gameObject.SetActive(true);
        }
        if (cont == 11)
        {
            josue.enabled = pietroFa.enabled = false;
            josueFa.enabled = pietro.enabled = true;

            josue.sprite = j_surpreso;
            falasJosue.text = "Mas o senhor me deu 100 reais!";
            falasPietro.text = "";

            nomeJosue.gameObject.SetActive(true);
            nomePietro.gameObject.SetActive(false);
        }
        if (cont == 12)
        {
            josue.enabled = pietroFa.enabled = true;
            josueFa.enabled = pietro.enabled = false;

            falasJosue.text = "";
            falasPietro.text = "Fica de gorjeta, por ter me feito rir um pouco";

            nomeJosue.gameObject.SetActive(false);
            nomePietro.gameObject.SetActive(true);
        }
        if (cont == 13)
        {
            josue.enabled = pietroFa.enabled = false;
            josueFa.enabled = pietro.enabled = true;

            josue.sprite = j_surpreso2;
            falasJosue.text = "Érr, ér, Muito obrigado senhor!";
            falasPietro.text = "";

            nomeJosue.gameObject.SetActive(true);
            nomePietro.gameObject.SetActive(false);
        }
        if (cont == 14)
        {
            josue.enabled = pietroFa.enabled = true;
            josueFa.enabled = pietro.enabled = false;

            falasJosue.text = "";
            falasPietro.text = "Pode me chamar de Pietro";

            nomeJosue.gameObject.SetActive(false);
            nomePietro.gameObject.SetActive(false);
            nomePietro2.gameObject.SetActive(true);
        }
        if (cont == 15)
        {
            josue.enabled = pietroFa.enabled = false;
            josueFa.enabled = pietro.enabled = true;

            josue.sprite = j_sorrindo;
            falasJosue.text = "Valeu Pietro! Você é o cara! Isso é o que eu ganho no dia";
            falasPietro.text = "";

            nomeJosue.gameObject.SetActive(true);
            nomePietro2.gameObject.SetActive(false);
        }
        if (cont == 16)
        {
            josue.enabled = pietroFa.enabled = true;
            josueFa.enabled = pietro.enabled = false;

            pietro.sprite = p_rindo;
            falasJosue.text = "";
            falasPietro.text = "Que emprego de merda você tem garoto! Ha ha ha!\nJá trabalha nisso há muito tempo?";

            nomeJosue.gameObject.SetActive(false);
            nomePietro2.gameObject.SetActive(true);
        }
        if (cont == 17)
        {
            josue.enabled = pietroFa.enabled = false;
            josueFa.enabled = pietro.enabled = true;

            josue.sprite = j_rindo;
            falasJosue.text = "É sim! Desde sempre!\nAté mais, foi um prazer";
            falasPietro.text = "";

            nomeJosue.gameObject.SetActive(true);
            nomePietro2.gameObject.SetActive(false);
        }
        if (cont == 18)
        {
            josue.enabled = pietroFa.enabled = true;
            josueFa.enabled = pietro.enabled = false;

            pietro.sprite = p_rindomal;
            falasJosue.text = "";
            falasPietro.text = "Espera garoto!\nComo se chama?\nO que acha de um emprego melhor?";

            nomeJosue.gameObject.SetActive(false);
            nomePietro2.gameObject.SetActive(true);
        }
        if (cont == 19)
        {
            josue.enabled = pietroFa.enabled = false;
            josueFa.enabled = pietro.enabled = true;

            josue.sprite = j_normal;
            falasJosue.text = "Que? Josué\nComo assim?";
            falasPietro.text = "";

            nomeJosue.gameObject.SetActive(true);
            nomePietro2.gameObject.SetActive(false);
        }
        if (cont == 20)
        {
            josue.enabled = pietroFa.enabled = true;
            josueFa.enabled = pietro.enabled = false;

            falasJosue.text = "";
            falasPietro.text = "É que eu tenho uma empresa de delivery que entrega vários tipos de alimentos,\naçaí, pizza, hambúrguer, tudo que imaginar,\ne estamos precisando de mais motoboys, o que acha?";

            nomeJosue.gameObject.SetActive(false);
            nomePietro2.gameObject.SetActive(true);
        }
        if (cont == 21)
        {
            josue.enabled = pietroFa.enabled = false;
            josueFa.enabled = pietro.enabled = true;

            josue.sprite = j_surpreso2;
            falasJosue.text = "Peraí! O senhor é dono de uma empresa de delivery!?\nE por que pediu pizza na concorrência ?";
            falasPietro.text = "";

            nomeJosue.gameObject.SetActive(true);
            nomePietro2.gameObject.SetActive(false);
        }
        if (cont == 22)
        {
            josue.enabled = pietroFa.enabled = true;
            josueFa.enabled = pietro.enabled = false;

            pietro.sprite = p_sorrisomal;
            falasJosue.text = "";
            falasPietro.text = "Você é esperto Josué \nÉ que eu já tinha essa intenção\nPode ir lá conhecer o ambiente, a empresa presta um serviço de qualidade\nVocê vai ganhar em uma hora o que está ganhando pelo dia inteiro\nO que acha ?";

            nomeJosue.gameObject.SetActive(false);
            nomePietro2.gameObject.SetActive(true);
        }
        if (cont == 23)
        {
            josue.enabled = pietroFa.enabled = false;
            josueFa.enabled = pietro.enabled = true;

            josue.sprite = j_sorrindo;
            falasJosue.text = "Claro! Assim que folgar, vou lá conhecer!";
            falasPietro.text = "";

            nomeJosue.gameObject.SetActive(true);
            nomePietro2.gameObject.SetActive(false);
        }
        if (cont == 24)
        {
            falasJosue.text = "";
            falasPietro.text = "";

        }
        if (cont == 25)
        {
            ProximaCena("InteriorEmpresa");
        }

        josueFa.sprite = josue.sprite;
        pietroFa.sprite = pietro.sprite;

    }

    public void ProximaCena(string nomeCena)
    {
        ControlaJogo.prologoFeito = true;
        ControlaAudio.instance.ParaAudios();
        SceneManager.LoadScene(nomeCena);
    }
}

