using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class veiculos : MonoBehaviour {

    //Script dos veículos, movimentção e colisão;

    public float obstSpeed;
    Rigidbody obst;
    public player jogador;

    Vector3 reDirecionamento;
    Vector3 velocidade;

    WaitForSeconds delay = new WaitForSeconds(0.2f);
    float reparoLentoTemp;
    int reparoLentoPisc;

    public cameraShake camShake;

    public bool subida;
    public bool descida;

    public bool estacionado;

    public bool carroAtviado = false;

    public AudioClip batidaSFX;
    public AudioClip batida2SFX;

    public AudioClip reparoLentoSFX;

    AudioSource audioCarros;

    void Start() {
        reparoLentoPisc = ControlaJogo.instance.reparoLentoPisc;
        reparoLentoTemp = ControlaJogo.instance.reparoLentoTemp;

        if (!estacionado) audioCarros = GetComponent<AudioSource>();

        obst = GetComponent<Rigidbody>();
        velocidade = new Vector3(0, 0, obstSpeed);
        obst.velocity = Vector3.zero;
        reDirecionamento = Vector3.zero;
    }


    void Update() {

        if (ControlaFase.isPaused) obst.velocity = Vector3.zero;
        if (!estacionado) audioCarros.volume = ControlaAudio.instance.volumeEfeitos;

        //Velocidade do carro;
        if (carroAtviado && !ControlaFase.isPaused)
        {

            if (subida)
            {
                obst.velocity = velocidade + Vector3.up * 3 + reDirecionamento;
            }
            else if (descida)
            {
                obst.velocity = velocidade + Vector3.down * 5 + reDirecionamento;
            }
            else
            {
                obst.velocity = velocidade + reDirecionamento;
            }
        }
    }

    void OnCollisionEnter(Collision other)
    {

        //Detectar colisão, e fazer player tomar dano;
        if (other.gameObject.tag == "Player")
        {
            Destroy(gameObject.GetComponent<BoxCollider>());
            if (jogador.vida > 1)
            {
                ControlaAudio.instance.TocaAudio(batidaSFX);
                other.gameObject.layer = 8;
                jogador.ControlaVida(-1);
                jogador.AlteraVelocidade(2, true);

                StartCoroutine("Invulneravel");
                StartCoroutine(Piscando(5));
                StartCoroutine(camShake.Shake(0.8f, 0.4f));
            }
            else if (jogador.vida == 1)
            {
                ControlaAudio.instance.TocaAudio(batida2SFX);
                jogador.ControlaVida(-1);
                StartCoroutine(camShake.Shake(0.8f, 0.4f));
            }
        }
        //Detectar colisão com a bala;
        if (other.gameObject.tag == "bala")
        {
            obst.freezeRotation = false;
            reDirecionamento = Vector3.up * 10;
        }

    }

    public void AtivaCarro()
    {
        carroAtviado = true;
    }

    IEnumerator Invulneravel()
    {
        yield return new WaitForSeconds(2);
        if (jogador.reparoLento)
        {
            ControlaAudio.instance.TocaAudio(reparoLentoSFX);
            yield return new WaitForSeconds(reparoLentoTemp);
        }
        jogador.gameObject.layer = 0;
    }
    IEnumerator Piscando(int piscadas)
    {
        jogador.isPuLock = true;
        if (jogador.reparoLento)
        {            
            piscadas += reparoLentoPisc;
        }
        for (int i = 0; i < piscadas; i++)
        {
            jogador.invisivel = true;
            yield return delay;
            jogador.invisivel = false;
            yield return delay;
        }
        jogador.isPuLock = false;
    }
}
