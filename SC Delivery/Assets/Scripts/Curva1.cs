using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Curva1 : MonoBehaviour
{

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            if (Input.GetKeyDown(KeyCode.RightArrow))
            {
                if (tag == "CurvaDireita") transform.Rotate(0, 90, 0);
                else transform.Rotate(0, -90, 0);
            }
        }
    }
}
