using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class obstParado : MonoBehaviour {

    //Sript dos obstáculos estaticos, colisões;

    public player jogador;

    WaitForSeconds delay = new WaitForSeconds(0.2f);
    float reparoLentoTemp;
    int reparoLentoPisc;

    public cameraShake camShake;

    public AudioClip batidaSFX;
    public AudioClip batida2SFX;

    public AudioClip reparoLentoSFX;

    private void Start()
    {
        reparoLentoPisc = ControlaJogo.instance.reparoLentoPisc;
        reparoLentoTemp = ControlaJogo.instance.reparoLentoTemp;
    }

    void OnCollisionEnter(Collision other)
    {

        //Detectar colisão e fazer player tomar dano;
        if (other.gameObject.tag == "Player")
        {
            Destroy(gameObject.GetComponent<BoxCollider>());
            Destroy(gameObject.GetComponent<SphereCollider>());
            StartCoroutine("Invulneravel");
            if (jogador.vida > 1)
            {
                ControlaAudio.instance.TocaAudio(batidaSFX);
                jogador.ControlaVida(-1);
                jogador.AlteraVelocidade(2, true);

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
    }

    IEnumerator Invulneravel()
    {
        jogador.gameObject.layer = 8;
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
