using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PegaMesh : MonoBehaviour {

    //Pegar o componente de Mesh dos objetos;

    public MeshRenderer mesh;
    

    void Start () {

        mesh = GetComponent<MeshRenderer>();
	}
	
}
