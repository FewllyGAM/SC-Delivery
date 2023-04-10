using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class DialoguesPart3 : MonoBehaviour {

    public Image fundo;

    public Image josue;
    public Image josueFa;
    public Image pietro;
    public Image pietroFa;
    public Image mei;
    public Image meiFa;

    public GameObject escolhasOp;

    public int escolha;

    public AudioClip celularTocandoSFX;
    public AudioClip celularDesligandoSFX;
    public AudioClip sireneSFX;
    public AudioClip funkST;

    public Sprite fundoEmpresa;
    public Sprite fundoLab;
    public Sprite fundoCozinhaRes;

    public Sprite j_sorriso1;
    public Sprite j_sorriso2;
    public Sprite j_assutado1;
    public Sprite j_assustado2;
    public Sprite j_normal;
    public Sprite j_tedio;
    public Sprite j_deboche;
    public Sprite j_celular;

    public Sprite m_seria;
    public Sprite m_sorrindo;
    public Sprite m_telefone;
    public Sprite m_normal;

    public RectTransform nomeJosue;
    public RectTransform nomePietro;
    public RectTransform nomeMei;

    public GameObject nomePietroCelular;
    public GameObject nomeJosueAux;

    public Text falasJosue;
    public Text falasPietro;
    public Text falasMei;

    public int cont = 1;

    bool lockSeta = false;

    private void Start()
    {
        ControlaAudio.instance.TocaMusica(funkST);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.RightArrow) && !lockSeta)
            Dialogo3();
    }

    public void Dialogo3()
    {
        cont++;

        josue.sprite = josueFa.sprite;
        pietro.sprite = pietroFa.sprite;
        mei.sprite = meiFa.sprite;

        if (cont == 2)
        {
            falasJosue.text = "E ai como tá indo as entregas?";
            falasMei.text = "";
        }
        if (cont == 3)
        {
            josueFa.enabled = false;
            josue.enabled = true;
            meiFa.enabled = true;
            mei.enabled = false;

            falasJosue.text = "";
            falasMei.text = "Indo bem, mas é cada lugar estranho que eu entrego";

            nomeJosue.gameObject.SetActive(false);
            nomeMei.gameObject.SetActive(true);
        }
        if (cont == 4)
        {
            josueFa.enabled = true;
            josue.enabled = false;
            meiFa.enabled = false;
            mei.enabled = true;

            falasJosue.text = "Ha ha ha! Nem me fale\n A pessoa não tem dinheiro para rebocar a casa, mas tem para gastar uma fortuna com pizza gourmet";
            falasMei.text = "";

            nomeJosue.gameObject.SetActive(true);
            nomeMei.gameObject.SetActive(false);
        }
        if (cont == 5)
        {
            josueFa.enabled = false;
            josue.enabled = true;
            meiFa.enabled = true;
            mei.enabled = false;

            falasJosue.text = "";
            falasMei.text = "Credo! Que maldade\n Ela só tem prioridades diferentes na vida";

            nomeJosue.gameObject.SetActive(false);
            nomeMei.gameObject.SetActive(true);
        }
        if (cont == 6)
        {
            josueFa.enabled = true;
            josue.enabled = false;
            meiFa.enabled = false;
            mei.enabled = true;

            falasJosue.text = "Isso eu entendo! Comer em primeiro lugar, Sempre\n Ha ha ha!";
            falasMei.text = "";

            nomeJosue.gameObject.SetActive(true);
            nomeMei.gameObject.SetActive(false);
        }
        if (cont == 7)
        {
            josueFa.enabled = false;
            josue.enabled = true;
            meiFa.enabled = true;
            mei.enabled = false;

            falasJosue.text = "";
            falasMei.text = "Você sabe onde está todo mundo? O mecânico Leo me disse para voltar pra cá, que precisava falar comigo,\n mas ele não tá na oficina e todo mundo sumiu";

            nomeJosue.gameObject.SetActive(false);
            nomeMei.gameObject.SetActive(true);
        }
        if (cont == 8)
        {
            josueFa.sprite = j_normal;

            josueFa.enabled = true;
            josue.enabled = false;
            meiFa.enabled = false;
            mei.enabled = true;

            falasJosue.text = "Estranho, nem o Pietro? Talvez esteja rolando alguma reunião";
            falasMei.text = "";

            nomeJosue.gameObject.SetActive(true);
            nomeMei.gameObject.SetActive(false);
        }
        if (cont == 9)
        {
            josueFa.enabled = false;
            josue.enabled = true;
            meiFa.enabled = true;
            mei.enabled = false;

            falasJosue.text = "";
            falasMei.text = "Eu olhei no escritório dele e nada\n Todo mundo simplesmente sumiu, bem em horário de serviço";

            nomeJosue.gameObject.SetActive(false);
            nomeMei.gameObject.SetActive(true);
        }
        if (cont == 10)
        {
            josueFa.enabled = true;
            josue.enabled = false;
            meiFa.enabled = false;
            mei.enabled = true;

            falasJosue.text = "Hmm, estranho";
            falasMei.text = "";

            nomeJosue.gameObject.SetActive(true);
            nomeMei.gameObject.SetActive(false);
        }
        if (cont == 11)
        {
            josueFa.enabled = false;
            josue.enabled = true;
            meiFa.enabled = true;
            mei.enabled = false;

            falasJosue.text = "";
            falasMei.text = "Sim, bem estranho";

            nomeJosue.gameObject.SetActive(false);
            nomeMei.gameObject.SetActive(true);
        }
        if (cont == 12)
        {
            josueFa.enabled = true;
            josue.enabled = false;
            meiFa.enabled = false;
            mei.enabled = true;

            falasJosue.text = "Pensando bem\n Existe apenas um lugar em que você ainda não olhou";
            falasMei.text = "";

            nomeJosue.gameObject.SetActive(true);
            nomeMei.gameObject.SetActive(false);
        }
        if (cont == 13)
        {
            josueFa.enabled = false;
            josue.enabled = true;
            meiFa.enabled = true;
            mei.enabled = false;

            falasJosue.text = "";
            falasMei.text = "Onde?";

            nomeJosue.gameObject.SetActive(false);
            nomeMei.gameObject.SetActive(true);
        }
        if (cont == 14)
        {
            josueFa.enabled = true;
            josue.enabled = false;
            meiFa.enabled = false;
            mei.enabled = true;

            falasJosue.text = "Na cozinha";
            falasMei.text = "";

            nomeJosue.gameObject.SetActive(true);
            nomeMei.gameObject.SetActive(false);
        }
        if (cont == 15)
        {
            josueFa.enabled = false;
            josue.enabled = true;
            meiFa.enabled = true;
            mei.enabled = false;

            falasJosue.text = "";
            falasMei.text = "Lógico que eu não procurei na cozinha, só os cozinheiros podem entrar";

            nomeJosue.gameObject.SetActive(false);
            nomeMei.gameObject.SetActive(true);
        }
        if (cont == 16)
        {
            josueFa.enabled = true;
            josue.enabled = false;
            meiFa.enabled = false;
            mei.enabled = true;

            falasJosue.text = "Mas talvez ele esteja lá";
            falasMei.text = "";

            nomeJosue.gameObject.SetActive(true);
            nomeMei.gameObject.SetActive(false);
        }
        if (cont == 17)
        {
            josueFa.enabled = false;
            josue.enabled = true;
            meiFa.enabled = true;
            mei.enabled = false;

            falasJosue.text = "";
            falasMei.text = "Pode ser, mas, não quero arriscar e levar sermão do Pietro, você sabe como ele é\n Acabei de entrar na empresa, não posso sair quebrando as regras";

            nomeJosue.gameObject.SetActive(false);
            nomeMei.gameObject.SetActive(true);
        }
        if (cont == 18)
        {
            josueFa.enabled = true;
            josue.enabled = false;
            meiFa.enabled = false;
            mei.enabled = true;

            falasJosue.text = "Não importa\n Eu vou entrar e não tô nem aí\n Sempre quis ver como é, e essa é uma ótima desculpa";
            falasMei.text = "";

            nomeJosue.gameObject.SetActive(true);
            nomeMei.gameObject.SetActive(false);
        }
        if (cont == 19)
        {
            josueFa.enabled = false;
            josue.enabled = true;
            meiFa.enabled = true;
            mei.enabled = false;

            falasJosue.text = "";
            falasMei.text = "Pode arriscar então\n Eu vou ligar para o Pietro pra saber";

            nomeJosue.gameObject.SetActive(false);
            nomeMei.gameObject.SetActive(true);
        }
        if (cont == 20)
        {
            josueFa.sprite = j_sorriso1;

            josueFa.enabled = true;
            josue.enabled = false;
            meiFa.enabled = false;
            mei.enabled = true;

            falasJosue.text = "Liga então\n Enquanto isso, vou ver se acho onde guardam o açaí";
            falasMei.text = "";

            nomeJosue.gameObject.SetActive(true);
            nomeMei.gameObject.SetActive(false);
        }
        if (cont == 21)
        {
            josueFa.enabled = false;
            josue.enabled = true;
            meiFa.enabled = true;
            mei.enabled = false;

            falasJosue.text = "";
            falasMei.text = "Que isso? Tá passando fome, é?";

            nomeJosue.gameObject.SetActive(false);
            nomeMei.gameObject.SetActive(true);
        }
        if (cont == 22)
        {
            josueFa.sprite = j_sorriso2;

            josueFa.enabled = true;
            josue.enabled = false;
            meiFa.enabled = false;
            mei.enabled = true;

            falasJosue.text = "Meu estômago tá que tá uma prastinha pregada nas costas\n Agora eu tiro a barriga da miséria! Ha ha ha!";
            falasMei.text = "";

            nomeJosue.gameObject.SetActive(true);
            nomeMei.gameObject.SetActive(false);
        }
        if (cont == 23)
        {
            josueFa.enabled = false;
            josue.enabled = false;
            meiFa.enabled = true;
            mei.enabled = false;

            falasJosue.text = "";
            falasMei.text = "Credo";

            nomeJosue.gameObject.SetActive(false);
            nomeMei.gameObject.SetActive(true);
        }
        if (cont == 24)
        {
            meiFa.sprite = m_telefone;

            ControlaAudio.instance.TocaAudio(celularTocandoSFX);
            falasMei.text = "";

        }
        if (cont == 25)
        {
            meiFa.enabled = false;
            mei.enabled = true;

            falasPietro.text = "Alô?";
            falasMei.text = "";

            nomeJosueAux.SetActive(false);
            nomePietroCelular.SetActive(true);
            nomeJosue.gameObject.SetActive(true);
            nomeMei.gameObject.SetActive(false);
        }
        if (cont == 26)
        {
            meiFa.enabled = true;
            mei.enabled = false;

            falasPietro.text = "";
            falasMei.text = "Alô? Pietro?";

            nomeJosue.gameObject.SetActive(false);
            nomeMei.gameObject.SetActive(true);
        }
        if (cont == 27)
        {
            meiFa.enabled = false;
            mei.enabled = true;

            falasPietro.text = "Oi Mei, como estão as entregas?";
            falasMei.text = "";

            nomeJosue.gameObject.SetActive(true);
            nomeMei.gameObject.SetActive(false);
        }
        if (cont == 28)
        {
            meiFa.enabled = true;
            mei.enabled = false;

            falasPietro.text = "";
            falasMei.text = "Então, Eu cheguei na empresa e não tem ninguém aqui\n Até os cozinheiros não estão, o que está acontecendo?";

            nomeJosue.gameObject.SetActive(false);
            nomeMei.gameObject.SetActive(true);
        }
        if (cont == 29)
        {
            meiFa.enabled = false;
            mei.enabled = true;

            falasPietro.text = "Nada não, Eu tive um imprevisto e precisei da ajuda deles\n Não saí daí, daqui a pouco eu chego";
            falasMei.text = "";

            nomeJosue.gameObject.SetActive(true);
            nomeMei.gameObject.SetActive(false);
        }
        if (cont == 30)
        {
            meiFa.enabled = true;
            mei.enabled = false;

            falasPietro.text = "";
            falasMei.text = "Tudo bem\n Só fiquei preocupada atoa";

            nomeJosue.gameObject.SetActive(false);
            nomeMei.gameObject.SetActive(true);
        }
        if (cont == 31)
        {
            meiFa.sprite = m_seria;

            ControlaAudio.instance.TocaAudio(celularDesligandoSFX);
            falasPietro.text = "";
            falasMei.text = "Josué? Josué?!\nNão acredito que ele entrou--'";

            nomeJosueAux.SetActive(true);
            nomePietroCelular.SetActive(false);
        }
        if (cont == 32)
        {
            falasMei.text = "";
        }
        if (cont == 33)
        {
            josueFa.sprite = j_sorriso1;

            josueFa.enabled = true;
            josue.enabled = false;
            meiFa.enabled = false;
            mei.enabled = false;

            fundo.sprite = fundoLab;
            falasJosue.text = "Açaizinho? Vem pro papai, vem";
            falasMei.text = "";

            nomeJosue.gameObject.SetActive(true);
            nomeMei.gameObject.SetActive(false);
        }
        if (cont == 34)
        {
            josueFa.sprite = j_normal;

            falasJosue.text = "----- Mas que p**** é essa?!";
        }
        if (cont == 35)
        {
            falasJosue.text = "";
            falasMei.text = "Josué?";

            nomeJosue.gameObject.SetActive(false);
            nomeMei.gameObject.SetActive(true);
        }
        if (cont == 36)
        {
            falasJosue.text = "Vem aqui!\nAgora!";
            falasMei.text = "";

            nomeJosue.gameObject.SetActive(true);
            nomeMei.gameObject.SetActive(false);
        }
        if (cont == 37)
        {
            josueFa.enabled = false;
            josue.enabled = true;
            meiFa.enabled = true;
            mei.enabled = false;

            falasJosue.text = "";
            falasMei.text = "Mas o que é isso?!";

            nomeJosue.gameObject.SetActive(false);
            nomeMei.gameObject.SetActive(true);
        }
        if (cont == 38)
        {
            josueFa.enabled = true;
            josue.enabled = false;
            meiFa.enabled = false;
            mei.enabled = true;

            falasJosue.text = "Parece um laboratório";
            falasMei.text = "";

            nomeJosue.gameObject.SetActive(true);
            nomeMei.gameObject.SetActive(false);
        }
        if (cont == 39)
        {
            josueFa.enabled = false;
            josue.enabled = true;
            meiFa.enabled = true;
            mei.enabled = false;

            falasJosue.text = "";
            falasMei.text = "Não parece, É um laboratório,\nDe drogas, 1… 2… 3… 4… Meu Deus, só olhando já consigo ver quatro drogas diferentes! Isso tá muito errado!";

            nomeJosue.gameObject.SetActive(false);
            nomeMei.gameObject.SetActive(true);
        }
        if (cont == 40)
        {
            josueFa.enabled = true;
            josue.enabled = false;
            meiFa.enabled = false;
            mei.enabled = true;

            falasJosue.text = "Não sei se tô surpreso pelas drogas ou por você conhecer tão bem todas elas";
            falasMei.text = "";

            nomeJosue.gameObject.SetActive(true);
            nomeMei.gameObject.SetActive(false);
        }
        if (cont == 41)
        {
            josueFa.enabled = false;
            josue.enabled = true;
            meiFa.enabled = true;
            mei.enabled = false;

            falasJosue.text = "";
            falasMei.text = "Isso não vem ao caso, eu-- não importa, você não percebe?\nOlha as caixas, provavelmente a gente tava entregando drogas esse tempo todo, Isso é tráfico d--";

            nomeJosue.gameObject.SetActive(false);
            nomeMei.gameObject.SetActive(true);
        }
        if (cont == 42)
        {
            meiFa.enabled = false;
            mei.enabled = true;

            falasJosue.text = "";
            falasMei.text = "";
            falasPietro.text = "(Ao fundo Pietro)\nMei? Onde você está?";

            nomeMei.gameObject.SetActive(false);
        }
        if (cont == 43)
        {
            meiFa.enabled = true;
            mei.enabled = false;

            falasJosue.text = "";
            falasMei.text = "Droga!";
            falasPietro.text = "";

            nomeMei.gameObject.SetActive(true);
        }
        if (cont == 44)
        {
            meiFa.enabled = false;
            mei.enabled = false;
            pietroFa.enabled = true;
            pietro.enabled = false;

            falasJosue.text = "";
            falasMei.text = "";
            falasPietro.text = "O que vocês estão fazendo aqui?!";

            nomeMei.gameObject.SetActive(false);
            nomePietro.gameObject.SetActive(true);
        }
        if (cont == 45)
        {
            josueFa.sprite = j_deboche;

            josueFa.enabled = true;
            josue.enabled = false;

            falasJosue.text = "A gente? nada demais, só passando o tempo\n E você, como tá indo o trabalho? Traficando muita droga?";
            falasPietro.text = "";

            nomeJosue.gameObject.SetActive(true);
            nomePietro.gameObject.SetActive(false);
        }
        if (cont == 46)
        {
            josueFa.enabled = false;
            josue.enabled = true;
            pietroFa.enabled = true;
            pietro.enabled = false;

            falasJosue.text = "";
            falasPietro.text = "O quê?! Qual parte de entrada restrita vocês não entenderam?!\nNão podem entrar aqui! Isso aqui não é da conta de vocês!";

            nomeJosue.gameObject.SetActive(false);
            nomePietro.gameObject.SetActive(true);
        }
        if (cont == 47)
        {
            meiFa.enabled = true;
            mei.enabled = false;
            pietroFa.enabled = false;
            pietro.enabled = false;

            falasMei.text = "Não é da nossa conta?!\n Se a polícia chegar aqui tenho certeza que vai ser da nossa conta!";
            falasPietro.text = "";

            nomeJosue.gameObject.SetActive(false);
            nomeMei.gameObject.SetActive(true);
            nomePietro.gameObject.SetActive(false);
        }
        if (cont == 48)
        {
            meiFa.enabled = false;
            mei.enabled = false;
            pietroFa.enabled = true;
            pietro.enabled = false;

            falasMei.text = "";
            falasPietro.text = "Não precisam se preocupar, Isso são só negócios\n Tenho parceiros na polícia, até clientes, vocês só precisam fazer entregas e tudo estará bem";

            nomeMei.gameObject.SetActive(false);
            nomePietro.gameObject.SetActive(true);
        }
        if (cont == 49)
        {
            meiFa.enabled = true;
            mei.enabled = false;
            pietroFa.enabled = false;
            pietro.enabled = false;

            falasMei.text = "Eu não acredito! tudo nessa cidade é podre e corrupto! Me recuso a ser parte disso\n Tô fora, me demito!";
            falasPietro.text = "";

            nomeMei.gameObject.SetActive(true);
            nomePietro.gameObject.SetActive(false);
        }
        if (cont == 50)
        {
            meiFa.enabled = false;
            mei.enabled = false;
            pietroFa.enabled = true;
            pietro.enabled = false;

            falasMei.text = "";
            falasPietro.text = "Tudo bem, A escolha é sua mas sabe muito bem que não há como fugir do crime nesta cidade, Ainda mais com os pais que você têm";

            nomeMei.gameObject.SetActive(false);
            nomePietro.gameObject.SetActive(true);
        }
        if (cont == 51)
        {
            meiFa.enabled = true;
            mei.enabled = false;
            pietroFa.enabled = false;
            pietro.enabled = false;

            falasMei.text = "Seu m****\nVocê não sabe nada da minha vida! Eu tô saindo, Josué você não vêm?";
            falasPietro.text = "";

            nomeMei.gameObject.SetActive(true);
            nomePietro.gameObject.SetActive(false);
        }
        if (cont == 52)
        {
            josueFa.sprite = j_normal;

            josueFa.enabled = true;
            josue.enabled = false;
            meiFa.enabled = false;
            mei.enabled = false;

            falasJosue.text = "E- Eu ---";
            falasMei.text = "";

            nomeJosue.gameObject.SetActive(true);
            nomeMei.gameObject.SetActive(false);
            nomePietro.gameObject.SetActive(false);
        }
        if (cont == 53)
        {
            josueFa.enabled = false;
            josue.enabled = true;
            pietroFa.enabled = true;
            pietro.enabled = false;

            falasJosue.text = "";
            falasPietro.text = "A escolha é sua, Nenhum emprego lhe pagará tão bem como esse, Posso até te dar um aumento e uma moto nova, como prova de minha confiança em você, O que acha?";

            nomeJosue.gameObject.SetActive(false);
            nomePietro.gameObject.SetActive(true);
        }
        if (cont == 54)
        {
            josueFa.enabled = true;
            josue.enabled = false;
            pietroFa.enabled = false;
            pietro.enabled = true;

            falasPietro.text = "";

            nomePietro.gameObject.SetActive(false);

            lockSeta = true;
            escolhasOp.SetActive(true);
        }

        //Escolha lado mau;
        if (escolha == 1)
        {
            if (cont == 55)
            {
                lockSeta = false;

                falasJosue.text = "Eu fico, Desculpa Mei, mas essa é minha chance de sair da merda, Quero ser mais do que um simples entregador de pizza, Tenho que pensar em mim pelo menos uma vez";

                nomeJosue.gameObject.SetActive(true);

                escolhasOp.SetActive(false);
            }
            if (cont == 56)
            {
                josueFa.enabled = false;
                josue.enabled = true;
                pietroFa.enabled = true;
                pietro.enabled = false;

                falasJosue.text = "";
                falasPietro.text = "Esse é meu garoto! Já temos novas entregas de esperando";

                nomeJosue.gameObject.SetActive(false);
                nomePietro.gameObject.SetActive(true);
            }
            if (cont == 57)
            {
                pietroFa.enabled = false;

                falasPietro.text = "(-Duas semanas depois-)";

                nomePietro.gameObject.SetActive(false);
            }
            if (cont == 58)
            {
                josueFa.sprite = j_celular;

                josueFa.enabled = true;
                josue.enabled = false;

                fundo.sprite = fundoEmpresa;
                ControlaAudio.instance.TocaAudio(celularTocandoSFX);
                falasPietro.text = "";
                falasJosue.text = "Alô Mei?";

                nomeJosue.gameObject.SetActive(true);
            }
            if (cont == 59)
            {
                josueFa.enabled = false;
                josue.enabled = true;

                falasMei.text = "Oi, Onde você tá?";
                falasJosue.text = "";

                nomeJosue.gameObject.SetActive(false);
                nomeMei.gameObject.SetActive(true);
            }
            if (cont == 60)
            {
                josueFa.enabled = true;
                josue.enabled = false;

                falasMei.text = "";
                falasJosue.text = "Tô na Sc. Olha desculpa eu ter falado daquele--";

                nomeJosue.gameObject.SetActive(true);
                nomeMei.gameObject.SetActive(false);
            }
            if (cont == 61)
            {
                josueFa.enabled = false;
                josue.enabled = true;

                falasMei.text = "Não, não, Preciso falar rápido, me escuta, A polícia descobriu o esquema da empresa, A verdadeira polícia, a não corrupta, Enfim se você é esperto, vaza daí agora!";
                falasJosue.text = "";

                nomeJosue.gameObject.SetActive(false);
                nomeMei.gameObject.SetActive(true);
            }
            if (cont == 62)
            {
                josueFa.enabled = true;
                josue.enabled = false;

                falasMei.text = "";
                falasJosue.text = "Como assim?! Você contou para eles?!";

                nomeJosue.gameObject.SetActive(true);
                nomeMei.gameObject.SetActive(false);
            }
            if (cont == 63)
            {
                josueFa.enabled = false;
                josue.enabled = true;

                falasMei.text = "Eu não. Acho que o mecânico contou, Sabe aquele dia? Em que não havia ninguém na empresa";
                falasJosue.text = "";

                nomeJosue.gameObject.SetActive(false);
                nomeMei.gameObject.SetActive(true);
            }
            if (cont == 64)
            {
                falasMei.text = "O mecânico tinha descoberto tudo, e essa máfia de cozinheiros foi atrás para impedi-lo, Agora nem sei se ele está vivo";
            }
            if (cont == 65)
            {
                josueFa.enabled = true;
                josue.enabled = false;

                falasMei.text = "";
                falasJosue.text = "Cê tá louca, Você saiu da empresa e nada de aconteceu";

                nomeJosue.gameObject.SetActive(true);
                nomeMei.gameObject.SetActive(false);
            }
            if (cont == 66)
            {
                josueFa.enabled = false;
                josue.enabled = true;

                ControlaAudio.instance.TocaAudio(sireneSFX);
                falasMei.text = "Isso não importa agora! Só foge antes que seja tarde";
                falasJosue.text = "";

                nomeJosue.gameObject.SetActive(false);
                nomeMei.gameObject.SetActive(true);
            }
            if (cont == 67)
            {
                josueFa.enabled = true;
                josue.enabled = false;

                ControlaAudio.instance.TocaAudio(celularDesligandoSFX);
                falasMei.text = "";
                falasJosue.text = "----- Preciso delisgar";

                nomeJosue.gameObject.SetActive(true);
                nomeMei.gameObject.SetActive(false);
            }
            if (cont == 68)
            {
                Fim();
            }
        }

        //Escolha lado bom;
        if (escolha == 2)
        {
            if (cont == 55)
            {
                lockSeta = false;

                falasJosue.text = "Minha mãe não me criou para isso cara, Eu fiz PROERD meu irmão, Drogas jamais, Ha ha ha!";

                nomeJosue.gameObject.SetActive(true);

                escolhasOp.SetActive(false);
            }
            if (cont == 56)
            {
                meiFa.sprite = m_sorrindo;

                pietro.enabled = false;
                pietroFa.enabled = false;
                josueFa.enabled = false;
                josue.enabled = true;
                meiFa.enabled = true;
                mei.enabled = false;

                falasJosue.text = "";
                falasMei.text = "Ha ha ha!";

                nomeJosue.gameObject.SetActive(false);
                nomeMei.gameObject.SetActive(true);
            }
            if (cont == 57)
            {
                pietroFa.enabled = true;
                pietro.enabled = false;
                meiFa.enabled = false;
                mei.enabled = false;

                falasJosue.text = "";
                falasPietro.text = "A escolha é sua, Vai apodrecer em um emprego de merda";
                falasMei.text = "";

                nomeJosue.gameObject.SetActive(false);
                nomeMei.gameObject.SetActive(false);
                nomePietro.gameObject.SetActive(true);
            }
            if (cont == 58)
            {
                josueFa.enabled = true;
                josue.enabled = false;
                pietroFa.enabled = false;
                pietro.enabled = true;

                falasJosue.text = "Não importa, Não quero ser rico se tiver que ferrar a vida das pessoas para isso, Qual a propósito de vencer se não tiver com quem compartilhar?";
                falasPietro.text = "";

                nomeJosue.gameObject.SetActive(true);
                nomePietro.gameObject.SetActive(false);
            }
            if (cont == 59)
            {
                falasJosue.text = "Você vai ter todo dinheiro do mundo, mas vai estar sempre sozinho, porque ferrou todos no seu caminho";
            }
            if (cont == 60)
            {
                josueFa.enabled = false;
                josue.enabled = true;
                pietroFa.enabled = true;
                pietro.enabled = false;

                falasJosue.text = "";
                falasPietro.text = "Não preciso do sermão de um zé ninguém, Quer ser um merda então some daqui";

                nomeJosue.gameObject.SetActive(false);
                nomePietro.gameObject.SetActive(true);
            }
            if (cont == 61)
            {
                meiFa.sprite = m_normal;

                pietroFa.enabled = false;
                meiFa.enabled = true;
                mei.enabled = false;

                falasMei.text = "Vamos Josué, antes que isso piore";
                falasPietro.text = "";

                nomeMei.gameObject.SetActive(true);
                nomePietro.gameObject.SetActive(false);
            }
            if (cont == 62)
            {
                meiFa.enabled = false;
                josue.enabled = true;

                falasMei.text = "(-Uma semana depois-)";

                nomeMei.gameObject.SetActive(false);
            }
            if (cont == 63)
            {
                josueFa.sprite = j_celular;

                josueFa.enabled = true;
                josue.enabled = false;

                fundo.sprite = fundoCozinhaRes;
                ControlaAudio.instance.TocaAudio(celularTocandoSFX);
                falasJosue.text = "Alô? Mei?";
                falasMei.text = "";

                nomeJosue.gameObject.SetActive(true);
                nomeMei.gameObject.SetActive(false);
            }
            if (cont == 64)
            {
                josueFa.enabled = false;
                josue.enabled = true;

                falasJosue.text = "";
                falasMei.text = "Oi, Onde você tá?";

                nomeJosue.gameObject.SetActive(false);
                nomeMei.gameObject.SetActive(true);
            }
            if (cont == 65)
            {
                josueFa.enabled = true;
                josue.enabled = false;

                falasJosue.text = "Tô na cozinha, Fala rápido, tenho que sair para fazer uma entrega";
                falasMei.text = "";

                nomeJosue.gameObject.SetActive(true);
                nomeMei.gameObject.SetActive(false);
            }
            if (cont == 66)
            {
                josueFa.enabled = false;
                josue.enabled = true;

                falasJosue.text = "";
                falasMei.text = "Que?! Você voltou para a SC?!";

                nomeJosue.gameObject.SetActive(false);
                nomeMei.gameObject.SetActive(true);
            }
            if (cont == 67)
            {
                josueFa.enabled = true;
                josue.enabled = false;

                falasJosue.text = "Não! Tá louca! Ha ha ha! Voltei para o meu antigo emprego";
                falasMei.text = "";

                nomeJosue.gameObject.SetActive(true);
                nomeMei.gameObject.SetActive(false);
            }
            if (cont == 68)
            {
                josueFa.enabled = false;
                josue.enabled = true;

                falasJosue.text = "";
                falasMei.text = "Quer me matar do coração?! Por um segundo acreditei, Mas enfim, O esquema da empresa foi descoberto, e a polícia tá por toda a rua da empresa";

                nomeJosue.gameObject.SetActive(false);
                nomeMei.gameObject.SetActive(true);
            }
            if (cont == 69)
            {
                josueFa.enabled = true;
                josue.enabled = false;

                falasJosue.text = "Que?? Você contou para a polícia?";
                falasMei.text = "";

                nomeJosue.gameObject.SetActive(true);
                nomeMei.gameObject.SetActive(false);
            }
            if (cont == 70)
            {
                josueFa.enabled = false;
                josue.enabled = true;

                falasJosue.text = "";
                falasMei.text = "Eu não, Acho que o mecânico contou, Sabe aquele dia? Em que não havia ninguém na empresa";

                nomeJosue.gameObject.SetActive(false);
                nomeMei.gameObject.SetActive(true);
            }
            if (cont == 71)
            {
                falasMei.text = "O mecânico tinha descoberto tudo, e essa máfia de cozinheiros foi atrás para impedi-lo";
            }
            if (cont == 72)
            {
                josueFa.enabled = true;
                josue.enabled = false;

                falasJosue.text = "E onde o mecânico está agora?";
                falasMei.text = "";

                nomeJosue.gameObject.SetActive(true);
                nomeMei.gameObject.SetActive(false);
            }
            if (cont == 73)
            {
                josueFa.enabled = false;
                josue.enabled = true;

                falasJosue.text = "";
                falasMei.text = "Nem sei se está vivo---";

                nomeJosue.gameObject.SetActive(false);
                nomeMei.gameObject.SetActive(true);
            }
            if (cont == 74)
            {
                josueFa.enabled = true;
                josue.enabled = false;

                falasJosue.text = "Mas a gente saiu da empresa já faz uma semana e nada aconteceu";
                falasMei.text = "";

                nomeJosue.gameObject.SetActive(true);
                nomeMei.gameObject.SetActive(false);
            }
            if (cont == 75)
            {
                josueFa.enabled = false;
                josue.enabled = true;

                falasJosue.text = "";
                falasMei.text = "Até agora! Pietro vai querer se vingar de quem contou, e ele já foi atrás do mecânico, Algo me diz que você é o próximo";

                nomeJosue.gameObject.SetActive(false);
                nomeMei.gameObject.SetActive(true);
            }
            if (cont == 76)
            {
                josueFa.enabled = true;
                josue.enabled = false;

                falasJosue.text = "Mas se a polícia tá na empresa, porque ele não tá preso?!";
                falasMei.text = "";

                nomeJosue.gameObject.SetActive(true);
                nomeMei.gameObject.SetActive(false);
            }
            if (cont == 77)
            {
                josueFa.enabled = false;
                josue.enabled = true;

                falasJosue.text = "";
                falasMei.text = "Acho que a parte de alguns policiais corruptos era verdade, Ele é de uma família poderosa de criminosos não vai ser preso tão facilmente";

                nomeJosue.gameObject.SetActive(false);
                nomeMei.gameObject.SetActive(true);
            }
            if (cont == 78)
            {
                josueFa.enabled = true;
                josue.enabled = false;

                falasJosue.text = "Mas e você?";
                falasMei.text = "";

                nomeJosue.gameObject.SetActive(true);
                nomeMei.gameObject.SetActive(false);
            }
            if (cont == 79)
            {
                josueFa.enabled = false;
                josue.enabled = true;

                falasJosue.text = "";
                falasMei.text = "Não se preocupa, Já estou bem longe de Santa Cruz só por garantia";

                nomeJosue.gameObject.SetActive(false);
                nomeMei.gameObject.SetActive(true);
            }
            if (cont == 80)
            {
                josueFa.enabled = true;
                josue.enabled = false;

                ControlaAudio.instance.TocaAudio(celularDesligandoSFX);
                falasJosue.text = "Preciso desligar--- Tchau";
                falasMei.text = "";

                nomeJosue.gameObject.SetActive(true);
                nomeMei.gameObject.SetActive(false);
            }
            if (cont == 81)
            {
                Fim();
            }
        }

    }

    public void Fim()
    {
        SceneManager.LoadScene("Rodovia");
    }

    public void Escolher(int num)
    {
        escolha = num;

        ControlaJogo.instance.escolha = escolha;
    }

}
