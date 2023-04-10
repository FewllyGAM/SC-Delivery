using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Curva : MonoBehaviour {

    
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            if (tag == "CurvaDireita") transform.Rotate(0, 90, 0);
            else transform.Rotate(0, -90, 0);
        }
    }
}
