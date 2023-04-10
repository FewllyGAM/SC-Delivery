using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoupaObst : MonoBehaviour {

    public player jogador;

    MeshRenderer mesh;
    public PegaMesh roupaDobrada;
    public Transform roupaNaCara;

	void Start () {
        mesh = GetComponent<MeshRenderer>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            mesh.enabled = false;
            roupaDobrada.mesh.enabled = true;
            roupaNaCara.transform.parent = other.transform;
            jogador.gameObject.layer = 11;
            jogador.InverteControle(true);
            StartCoroutine("Normalize");
        }
    }

    IEnumerator Normalize()
    {
        yield return new WaitForSeconds(5);
        Destroy(roupaNaCara.gameObject);
        jogador.gameObject.layer = 0;
        jogador.InverteControle(false);

    }



}
