using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class arvoreTrigger : MonoBehaviour {

    //Script para detectar trigger e ativar animação da árvore caindo.

    public animControl arvore;
    public AudioClip arvoreCaiSFX;
    public ParticleSystem folhas;

	void Update () {
        if (ControlaFase.isPaused)
            arvore.anim.speed = 0;
        else arvore.anim.speed = 1;
	}

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            StartCoroutine("AtivaFolhas");
            ControlaAudio.instance.TocaAudio(arvoreCaiSFX);
            arvore.anim.enabled = true;
        }
    }

    IEnumerator AtivaFolhas()
    {
        yield return new WaitForSeconds(.8f);
        folhas.Play();
    }
}
