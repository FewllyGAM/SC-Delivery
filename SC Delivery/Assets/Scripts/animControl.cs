using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class animControl : MonoBehaviour {

    //Script para pegar o Animator de algum obejto animado.

    public Animator anim;

    private void Awake()
    {
        anim = GetComponent<Animator>();
    }


    // Use this for initialization
    void Start () {
        
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
