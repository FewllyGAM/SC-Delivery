using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Clicaveis : MonoBehaviour {

    public Outline outline;
    public GameObject janelaOption;

    public ControlaIntFac controlaInterface;

    public AudioClip botaoSFX;

    private void OnMouseEnter()
    {
        if (!controlaInterface.janelaAtiva)
        {
            ControlaAudio.instance.TocaAudio(botaoSFX);
            outline.enabled = true;
        }
    }

    private void OnMouseOver()
    {
        if (!controlaInterface.janelaAtiva)
        {
            if (Input.GetMouseButtonDown(0))
            {
                janelaOption.SetActive(true);
                ControlaJogo.instance.EscolheChar(gameObject.name);

                controlaInterface.AtivaJanela();
            }
        }
    }

    private void OnMouseExit()
    {
        outline.enabled = false;
    }
}
