using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GeraPista : MonoBehaviour {

    public Transform borda;
    public Transform ferramenta;

    int[] lanes = new int[] {-3, -1, 1, 3};

    private void Awake()
    {
        Invoke("GeraModuloPista", 3);
    }

    void GeraModuloPista()
    {
        int randNum;
        int randLane;
        Instantiate(this, borda.position, borda.rotation);
        randNum = Random.Range(1, 11);
        randLane = Random.Range(0, 4);
        if (randNum < 3) Instantiate(ferramenta.gameObject, borda.position + new Vector3(lanes[randLane], .75f, 0), ferramenta.rotation);
    }
}
