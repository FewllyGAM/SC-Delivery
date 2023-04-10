using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class DialoguesPart1 : MonoBehaviour {

    public AudioClip restauranteSFX;
    public AudioClip musicaFunk;

    public Text falasJosue;
    public Text falasCozinheira;

    public RectTransform nomeJosue;
    public RectTransform nomeCozinheira;

    public Sprite j_fone;
    public Sprite j_fonesorriso;
    public Sprite j_deboche;
    public Sprite j_tedio;
    public Sprite j_normal;

    public Sprite c_brava;
    public Sprite c_normal;

    public Image josue;
    public Image cozinheira;

    public Image josueFa;
    public Image cozinheiraFa;


    public int cont = 1;

    private void Start()
    {
        ControlaAudio.instance.TocaMusica(musicaFunk);
        ControlaAudio.instance.TocaAudio(restauranteSFX);

    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.RightArrow))
            Dialogo();
    }

    public void Dialogo()
    {
        cont++;

        if (cont == 2)
        {   

            falasCozinheira.text = "Josué!! Cadê você criatura? Tem um monte de entrega para fazer!";
            falasJosue.text = "";

        }
        if (cont == 3)
        {
            josueFa.enabled = true;
            cozinheira.enabled = true;
            cozinheiraFa.enabled = false;

            falasCozinheira.text = "";
            falasJosue.text = "Que? Falou comigo? Que foi?";

            nomeCozinheira.gameObject.SetActive(false);
            nomeJosue.gameObject.SetActive(true);
        }
        if (cont == 4)
        {
            josue.enabled = cozinheiraFa.enabled = true;
            josueFa.enabled = cozinheira.enabled = false;

            cozinheira.sprite = c_brava;
            falasCozinheira.text = "Tira esse fone de ouvido moleque! Tem muita entrega para fazer! Você não escutou?";
            falasJosue.text = "";

            nomeCozinheira.gameObject.SetActive(true);
            nomeJosue.gameObject.SetActive(false);
        }
        if (cont == 5)
        {
            josue.enabled = cozinheiraFa.enabled = false;
            josueFa.enabled = cozinheira.enabled = true;

            josue.sprite = j_normal;
            falasCozinheira.text = "";
            falasJosue.text = "Foi mal, é que eu sou mais produtivo escutando música";

            nomeCozinheira.gameObject.SetActive(false);
            nomeJosue.gameObject.SetActive(true);
        }
        if (cont == 6)
        {
            josue.enabled = cozinheiraFa.enabled = true;
            josueFa.enabled = cozinheira.enabled = false;

            cozinheira.sprite = c_normal;
            falasCozinheira.text = "Eu não te pago uma fortuna para escutar música, te pago para trabalhar";
            falasJosue.text = "";

            nomeCozinheira.gameObject.SetActive(true);
            nomeJosue.gameObject.SetActive(false);
        }
        if (cont == 7)
        {
            josue.enabled = cozinheiraFa.enabled = false;
            josueFa.enabled = cozinheira.enabled = true;

            josue.sprite = j_deboche;
            falasCozinheira.text = "";
            falasJosue.text = "Não paga não";

            nomeCozinheira.gameObject.SetActive(false);
            nomeJosue.gameObject.SetActive(true);
        }
        if (cont == 8)
        {
            josue.enabled = cozinheiraFa.enabled = true;
            josueFa.enabled = cozinheira.enabled = false;

            cozinheira.sprite = c_brava;
            falasCozinheira.text = "O que foi que disse!??";
            falasJosue.text = "";

            nomeCozinheira.gameObject.SetActive(true);
            nomeJosue.gameObject.SetActive(false);
        }
        if (cont == 9)
        {
            josue.enabled = cozinheiraFa.enabled = false;
            josueFa.enabled = cozinheira.enabled = true;

            josue.sprite = j_tedio;
            falasCozinheira.text = "";
            falasJosue.text = "Já tô indo então, eu disse";

            nomeCozinheira.gameObject.SetActive(false);
            nomeJosue.gameObject.SetActive(true);
        }
        if (cont == 10)
        {
            josue.enabled = cozinheiraFa.enabled = true;
            josueFa.enabled = cozinheira.enabled = false;

            cozinheira.sprite = c_normal;
            falasCozinheira.text = "Sei, vai logo então, tenho mais o que fazer";
            falasJosue.text = "";

            nomeCozinheira.gameObject.SetActive(true);
            nomeJosue.gameObject.SetActive(false);
        }
        if (cont == 11)
        {
            cozinheiraFa.enabled = false;
            cozinheira.enabled = false;
            josueFa.enabled = true;
            josue.enabled = false;

            josue.sprite = j_deboche;
            falasCozinheira.text = "";
            falasJosue.text = "Velha chata";

            nomeCozinheira.gameObject.SetActive(false);
            nomeJosue.gameObject.SetActive(true);
        }
        if (cont == 12)
        {
            josue.sprite = j_fonesorriso;
            falasCozinheira.text = "";
            falasJosue.text = "";

        }
        if (cont == 13)
        {
            ProximaCena("PrologoGame");
        }

        josueFa.sprite = josue.sprite;
        cozinheiraFa.sprite = cozinheira.sprite;
    }

    public void ProximaCena(string nomeCena)
    {
        ControlaAudio.instance.ParaAudios();

        SceneManager.LoadScene(nomeCena);
    }
}
