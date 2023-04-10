using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class veicTrigger : MonoBehaviour {

    //Script para detectar trigger e ativar os veículos.

    public veiculos veic;
    
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            veic.AtivaCarro();
        }
    }

}
