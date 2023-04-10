using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CocoTrigger : MonoBehaviour {

    public animControl coco;

	void Update () {
        if (ControlaFase.isPaused)
            coco.anim.speed = 0;
        else coco.anim.speed = 1;
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            coco.anim.enabled = true;
        }
    }

}
