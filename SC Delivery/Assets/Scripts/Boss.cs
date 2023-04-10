using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss : MonoBehaviour {

    public player jogador;
    CharacterController controlador;

    public int escolha;

    const float laneDis = 1f;
    const float turnSpeed = .05f;

    public float speed;
    float verticalVel = -1f;
    int desiredLane = 1;
    public float mudaLaneVel;
    public int vida;

    public GameObject motoPietro;
    public GameObject pietro;
    public GameObject motoPolicial;
    public GameObject policial;
    public GameObject canhao;

    public AudioClip batidaSFX;
    public AudioClip batida2SFX;
    public ParticleSystem batidaEfeito;

    public GameObject projetil;
    GameObject bala;
    Rigidbody rb;
    float reload;
    bool atiraEsq = true;
    public ParticleSystem atiraComida1;
    public ParticleSystem atiraComida2;


    private void Start()
    {
        escolha = ControlaJogo.instance.escolha;

        controlador = GetComponent<CharacterController>();
        StartCoroutine("Movimenta");
        if (escolha == 2)
        {
            pietro.SetActive(true);
            motoPietro.SetActive(true);
        }
        if (escolha == 1)
        {
            policial.SetActive(true);
            motoPolicial.SetActive(true);
        }
    }

    private void FixedUpdate()
    {
        speed = jogador.speed;

        Vector3 direAlvo = transform.position.z * Vector3.forward;
        if (desiredLane == 0)
            direAlvo += Vector3.left * laneDis;
        else if (desiredLane == 1)
            direAlvo += Vector3.right * laneDis;
        else if (desiredLane == -1)
            direAlvo += Vector3.left * laneDis * 3;
        else if (desiredLane == 2)
            direAlvo += Vector3.right * laneDis * 3;


        Vector3 moveVetor = Vector3.zero;
        moveVetor.x = (direAlvo - transform.position).x * speed;
        moveVetor.y = verticalVel;
        moveVetor.z = speed;

        if (!ControlaFase.isPaused) controlador.Move(moveVetor * Time.deltaTime);

        Vector3 dir = controlador.velocity;
        if (dir != Vector3.zero)
        {
            transform.forward = Vector3.Lerp(transform.forward, dir, turnSpeed);
        }
    }

    void MoveLane(bool indoDireita)
    {
        desiredLane += (indoDireita) ? -1 : 1;
        desiredLane = Mathf.Clamp(desiredLane, -1, 2);
    }

    IEnumerator Movimenta()
    {
        yield return new WaitForSeconds(4f);
        int randNum;
        while (vida > 0)
        {
            if (desiredLane != -1 && desiredLane != 2) randNum = Random.Range(0, 2);
            else if (desiredLane == -1) randNum = 0;
            else randNum = 1;
            
            if (randNum == 0) MoveLane(false);
            else MoveLane(true);

            if (!ControlaFase.isPaused)
            {
                if (atiraEsq)
                {
                    atiraComida2.Play();
                    bala = Instantiate(projetil) as GameObject;
                    bala.transform.position = canhao.transform.position + new Vector3(0.25f, 0, 1f);
                    rb = bala.GetComponent<Rigidbody>();
                    rb.velocity = transform.TransformDirection(new Vector3(Random.Range(-0.2f, 0.2f), 0, 1) * 30);

                    atiraEsq = false;
                }
                else
                {
                    atiraComida1.Play();
                    bala = Instantiate(projetil) as GameObject;
                    bala.transform.position = canhao.transform.position + new Vector3(0.6f, 0, 1f);
                    rb = bala.GetComponent<Rigidbody>();
                    rb.velocity = transform.TransformDirection(new Vector3(Random.Range(-0.2f, 0.2f), 0, 1) * 30);
                    atiraEsq = true;
                }
            }

            yield return new WaitForSeconds(mudaLaneVel);
        }
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "bala")
        {
            batidaEfeito.Play();            
            if (vida > 0)
            {
                ControlaAudio.instance.TocaAudio(batidaSFX);
                StartCoroutine("Pisca");
                vida -= 1;
            }
            if (vida == 4) mudaLaneVel = 0.5f;
            if (vida == 2) mudaLaneVel = 0.25f;
            if (vida == 0)
            {
                ControlaAudio.instance.TocaAudio(batida2SFX);
                verticalVel = 8;
                StopCoroutine("Movimenta");
                Invoke("Derrotado", 2);
            }
        }
    }

    IEnumerator Pisca()
    {
        gameObject.layer = 0;
        for (int i = 0; i < 4; i++)
        {
            motoPietro.SetActive(false);
            if (escolha == 2) pietro.SetActive(false);
            if (escolha == 1) policial.SetActive(false);
            if (escolha == 2) motoPietro.SetActive(false);
            if (escolha == 1) motoPolicial.SetActive(false);
            canhao.SetActive(false);
            yield return new WaitForSeconds(.25f);
            motoPietro.SetActive(true);
            if (escolha == 2) pietro.SetActive(true);
            if (escolha == 1) policial.SetActive(true);
            if (escolha == 2) motoPietro.SetActive(true);
            if (escolha == 1) motoPolicial.SetActive(true);
            canhao.SetActive(true);
            yield return new WaitForSeconds(.25f);
        }
        gameObject.layer = 9;
    }

    void Derrotado()
    {
        jogador.CompletaFase(true);
    }
}
