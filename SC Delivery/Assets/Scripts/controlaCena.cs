using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class controlaCena : MonoBehaviour {

	
	void Start () {
        ControlaJogo.instance.PrimeiroInicio();
        if (!ControlaJogo.instance.primeiroInicio) ControlaJogo.instance.Carregar();        

        Invoke("ProxCena", 3);
	}

    void ProxCena()
    {
        SceneManager.LoadScene("Menu");
    }
}
