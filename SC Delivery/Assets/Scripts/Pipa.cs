using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pipa : MonoBehaviour {

    public PegaMesh cordaNormal;
    public PegaMesh cordaEsticada;
    public PegaMesh cordaCortada;

    public HUD hud;
    public GameObject jogador;
    public ControlaFase controlaFase;

    player scriptJogador;

    public AudioClip cortaPipaSFX;

    private void Start()
    {
        scriptJogador = jogador.GetComponent<player>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            if (!other.gameObject.GetComponent<player>().cortaPipa)
            {
                controlaFase.TravaPause(true);
                scriptJogador.Parando();
                hud.Fade(3);
                other.gameObject.layer = 8;
                hud.perdeu = true;
            }
            else
                ControlaAudio.instance.TocaAudio(cortaPipaSFX);
                StartCoroutine("CortaPipa");
        }
    }

    IEnumerator CortaPipa()
    {
        yield return new WaitForSeconds(.05f);
        cordaNormal.mesh.enabled = false;
        cordaEsticada.mesh.enabled = true;
        yield return new WaitForSeconds(.1f);
        cordaEsticada.mesh.enabled = false;
        cordaCortada.mesh.enabled = true;

    }
}
