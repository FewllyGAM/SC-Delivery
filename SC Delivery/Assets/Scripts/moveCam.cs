using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class moveCam : MonoBehaviour {

    //Script de movimentação da camera;

    public GameObject playerPos;
    public Vector3 cameraDis = new Vector3();
    Vector3 rotacaoAngulos;

    public bool lutaBoss = false;
    public bool rioOu = false;
    player jogador;

    private void Start()
    {
        jogador = playerPos.GetComponent<player>();
        rotacaoAngulos = transform.rotation.eulerAngles;
    }

    void Update() {

        //Faz a camera seguir o player, com um pequeno atraso;
        if (!jogador.completou && !ControlaFase.isPaused)
        {
            Vector3 desiredPosition = playerPos.transform.position + cameraDis;
            desiredPosition.x = 0;
            transform.position = Vector3.Lerp(transform.position, desiredPosition, Time.deltaTime);
        }

        //Faz a camera sempre estar atrás do player, e reconhecer subida/descida;
        if (jogador.reta)
        {
            if (!lutaBoss)
            {
                if (!rioOu)
                {
                    cameraDis.y = 4;
                    cameraDis.z = jogador.speed - 2;
                }
                else
                {
                    cameraDis.y = 7;
                    cameraDis.z = jogador.speed - 3;
                }
            }
            else
            {
                cameraDis.y = 7;
                cameraDis.z = jogador.speed - 9.5f;
            }
            transform.rotation = Quaternion.Euler(rotacaoAngulos);
        }

        if (jogador.subida)
        {
            if (!rioOu)
            {
                cameraDis.z = jogador.speed - 3f;
                cameraDis.y = 7;
                transform.rotation = Quaternion.Euler(rotacaoAngulos.x - 20, transform.rotation.y, transform.rotation.z);
            }
            else
            {
                cameraDis.z = jogador.speed - 4f;
                cameraDis.y = 10;
                transform.rotation = Quaternion.Euler(rotacaoAngulos.x - 15, transform.rotation.y, transform.rotation.z);
            }
        }

        if (jogador.descida)
        {
            cameraDis.z = jogador.speed - 1;
            cameraDis.y = 2;
            transform.rotation = Quaternion.Euler(rotacaoAngulos.x + 25, transform.rotation.y, transform.rotation.z);
        }    

    }

}
