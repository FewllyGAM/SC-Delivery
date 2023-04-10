using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player : MonoBehaviour {

    //Script do personagem, movimentação, colisões e variaveis;       
    
    public enum Item { Nenhum, CortaPipa, Prancha, MotoFantasma, CanhaoComida }
    public enum ItemPass { Nenhum, Mola, ReparoLento, Propulsores, ColetaVital }

    public Item ItemEquipado
    {
        get { return itemEquipado; }
        set
        {
            itemEquipado = value;
        }
    }

    public ItemPass PassEquipada
    {
        get { return passEquipada;  }
        set
        {
            passEquipada = value;
        }
    }

    [SerializeField]
    private Item itemEquipado;

    [SerializeField]
    private ItemPass passEquipada;

    public HUD hud;
    public ControlaFase controlaFase;

    public int capaceteCont = 0;

    public int dinheiro;

    bool inverteControle = false;

    public bool fourLanes = false;

    bool parando = false;
    bool reacelerando = false;

    public bool subida = false;
    public bool descida = false;
    public bool reta = true;
    public bool rodovia = false;

    const float laneDis = 1.0f;
    const float turnSpeed = .05f;

    public PegaMesh mesh1;
    public PegaMesh mesh3;
    public PegaMesh meshCanhao;
    public bool invisivel = false;
    public GameObject josueObj;
    public GameObject meiObj;

    public bool completou = false;

    CharacterController controller;
    public float speed;

    public float speedMax;
    public float jumpForce;
    public float gravity;
    float verticalVel;
    int desiredLane = 1;

    public float gas;
    public float gasMax;

    public float gasRatio;
    public int vida = 3;

    public ParticleSystem tomaDanoEfeito;
    public ParticleSystem passaNagua;

    //Variaveis PowerUps

    //Coleta Vital Escudo;
    public PegaMesh escudo;
    float coletaVitalTemp;
    public ParticleSystem escudoQuebra;
    
    //MotoFantasma;
    public GameObject personagemTranspa;
    public GameObject josueTranspa;
    public GameObject meiTranspa;
    float motoFantasmaCD;
    public ParticleSystem fantasmaEfeito;

    //CortaPipa
    public bool cortaPipa = false;
    public PegaMesh cortaPipaMesh;
    float cortaPipaCD;

    //Prancha;
    bool pranchaOn = false;
    public PegaMesh pranchaMesh;
    float pranchaCD;

    //CanhaoComida;
    public GameObject canhaoObj, projetil;
    GameObject bala;
    Rigidbody rb;
    bool canhaoOn = false;
    float canhaoTax;
    float reload;
    bool atiraEsq = true;
    float canhaoComidaCD;
    public ParticleSystem atiraComida1;
    public ParticleSystem atiraComida2;


    //Passiva Var
    public ParticleSystem propulsorEfeito;

    bool mola = false;
    float jumpMult = 1;

    public bool reparoLento = false;
    bool propulsor = false;
    float propulsorForce;
    bool coletaVital = false;


    //Cooldowns das habilidades
    float cooldownPu = 0;
    public bool isPuLock = false;

    //Audios;
    public AudioClip gasolinaSFX;
    public AudioClip relogioSFX;
    public AudioClip ferramentaSFX;
    public AudioClip capaceteSFX;
    public AudioClip puloSFX;
    public AudioClip coletaOnSFX;
    public AudioClip coletaOffSFX;
    public AudioClip atiraComidaSFX;
    public AudioClip equipaCanhaoSFX;
    public AudioClip equipaCortaPipaSFX;
    public AudioClip molaSFX;
    public AudioClip propulsorSFX;
    public AudioClip ativaFantasmaSFX;
    public AudioClip fantasmaSFX;
    public AudioClip ativaPranchaSFX;
    public AudioClip passaNaguaSFX;

    public AudioSource audioMoto;

    //Dinheiro do jogador
    float dinheiroBonusG;
    float dinheiroBonusT;
    float dinheiroFase;
    float dinheiroTotal;

    public AudioClip reparoLentoSFX;
    WaitForSeconds delay = new WaitForSeconds(0.2f);
    float reparoLentoTemp;
    int reparoLentoPisc;
    public AudioClip batidaSFX;
    public AudioClip batida2SFX;

    private void Awake()
    {
        switch (ControlaJogo.instance.ativaEqui)
        {
            case 1:
                itemEquipado = Item.Prancha;
                break;
            case 2:
                itemEquipado = Item.CortaPipa;
                break;
            case 3:
                itemEquipado = Item.MotoFantasma;
                break;
            case 4:
                itemEquipado = Item.CanhaoComida;
                break;
            case 5:
                itemEquipado = Item.Nenhum;
                break;
        }

        switch (ControlaJogo.instance.passivaEqui)
        {
            case 1:
                passEquipada = ItemPass.ReparoLento;
                break;
            case 2:
                passEquipada = ItemPass.Mola;
                break;
            case 3:
                passEquipada = ItemPass.Propulsores;
                break;
            case 4:
                passEquipada = ItemPass.ColetaVital;
                break;
            case 5:
                passEquipada = ItemPass.Nenhum;
                break;
        }

        audioMoto = GetComponent<AudioSource>();

        //Qual passiva equipada/
        switch (passEquipada)
        {
            case ItemPass.Mola:
                mola = true;
                break;
            case ItemPass.ReparoLento:
                reparoLento = true;
                break;
            case ItemPass.Propulsores:
                propulsor = true;
                break;
            case ItemPass.ColetaVital:
                coletaVital = true;
                break;
        }


        motoFantasmaCD = ControlaJogo.instance.motoFantasmaCD;
        cortaPipaCD = ControlaJogo.instance.cortaPipaCD;
        pranchaCD = ControlaJogo.instance.pranchaCD;
        canhaoComidaCD = ControlaJogo.instance.canhaoComidaCD;
        canhaoTax = ControlaJogo.instance.canhaoTax;

        coletaVitalTemp = ControlaJogo.instance.coletaVitalTemp;
        propulsorForce = ControlaJogo.instance.propulsorForce;

    }


    void Start () {
        audioMoto.Stop();
        controller = GetComponent<CharacterController>();

        reparoLentoPisc = ControlaJogo.instance.reparoLentoPisc;
        reparoLentoTemp = ControlaJogo.instance.reparoLentoTemp;

        if (ControlaJogo.instance.escolhaPerso == "Josue")
        {
            josueObj.SetActive(true);
            josueTranspa.SetActive(true);
        }
        else if (ControlaJogo.instance.escolhaPerso == "Mei")
        {
            meiObj.SetActive(true);
            meiTranspa.SetActive(true);
        }



        gas = gasMax;
        speed = speedMax;
	}
	
	void Update () {
        audioMoto.volume = ControlaAudio.instance.volumeEfeitos;
        //Verificar se jogo está pausado
        if (!ControlaFase.isPaused)
        {
            if (Input.GetKeyDown(KeyCode.RightArrow))
                MoveLane(true);
            if (Input.GetKeyDown(KeyCode.LeftArrow))
                MoveLane(false);

            //Ler qual item está equipado
            if (cooldownPu <= 0 && !isPuLock)
            {
                if (Input.GetKeyDown(KeyCode.S) && !isPuLock && itemEquipado != Item.Nenhum)
                {
                    switch (itemEquipado)
                    {
                        case Item.CortaPipa:                            
                            StartCoroutine(CortaPipa(25));
                            break;
                        case Item.MotoFantasma:
                            StartCoroutine(Invencivel(6));
                            break;
                        case Item.Prancha:
                            StartCoroutine(Prancha(24));
                            break;
                        case Item.CanhaoComida:                            
                            StartCoroutine(CanhaoComida(10));
                            break;
                    }
                }
            }

            //Atirar com o canhao
            if (Input.GetKeyDown(KeyCode.Space) && canhaoOn && reload <= 0)
            {               
                ControlaAudio.instance.TocaAudio(atiraComidaSFX);
                if (atiraEsq)
                {
                    atiraComida1.Play();
                    reload = canhaoTax;
                    bala = Instantiate(projetil) as GameObject;
                    bala.transform.position = canhaoObj.transform.position + new Vector3(0.25f, 0, 1f);
                    rb = bala.GetComponent<Rigidbody>();
                    if (!rodovia) rb.velocity = transform.TransformDirection(Vector3.forward * 30);
                    else rb.velocity = transform.TransformDirection(Vector3.back * 30);
                    atiraEsq = false;
                }
                else
                {
                    atiraComida2.Play();
                    reload = canhaoTax;
                    bala = Instantiate(projetil) as GameObject;
                    bala.transform.position = canhaoObj.transform.position + new Vector3(0.6f, 0, 1f);
                    rb = bala.GetComponent<Rigidbody>();
                    if (!rodovia) rb.velocity = transform.TransformDirection(Vector3.forward * 30);
                    else rb.velocity = transform.TransformDirection(Vector3.back * 30);
                    atiraEsq = true;
                }

            }
        }

        //Calcular a lane para onde o player está se movendo;
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

        //Pulo, descida rápida, velocidade em Z;
        if (controller.isGrounded)
        {
            if (!descida) verticalVel = -0.1f;
            else verticalVel = -5f;

            if (Input.GetKeyDown(KeyCode.UpArrow))
            {
                if (mola) ControlaAudio.instance.TocaAudio(molaSFX);
                else ControlaAudio.instance.TocaAudio(puloSFX);

                if (propulsor) StartCoroutine("Propulsor");
                
                if (!subida && !descida)
                {
                    if (mola) jumpMult = 1.6f;
                    verticalVel = jumpForce * jumpMult;
                }
                else if (subida)
                {
                    if (mola) jumpMult = 1.45f;
                    verticalVel = jumpForce * 1.7f * jumpMult;
                }
                else
                {
                    if (mola) jumpMult = 2.4f;
                    verticalVel = jumpForce * 0.4f * jumpMult;
                }
            }
        }
        else
        {
            verticalVel -= (gravity * Time.deltaTime);
            if (Input.GetKeyDown(KeyCode.DownArrow))
            {
                verticalVel -= jumpForce * 2;
            }
        }
        moveVetor.y = verticalVel;
        moveVetor.z = speed;

        if (!ControlaFase.isPaused) controller.Move(moveVetor * Time.deltaTime); //Comando para mover o player;

        //Girar o player para a direção que está indo;
        Vector3 dir = controller.velocity;
        if (dir != Vector3.zero)
        {
            transform.forward = Vector3.Lerp(transform.forward, dir, turnSpeed);
        }

        //Fazer player ficar invisível;
        if (invisivel)
        {
            mesh1.mesh.enabled = false;
            if (ControlaJogo.instance.escolhaPerso == "Josue") josueObj.SetActive(false);
            if (ControlaJogo.instance.escolhaPerso == "Mei") meiObj.SetActive(false);
            mesh3.mesh.enabled = false;
            if (canhaoOn)
                meshCanhao.mesh.enabled = false;
            if (cortaPipa)
                cortaPipaMesh.mesh.enabled = false;
            if (pranchaOn)
                pranchaMesh.mesh.enabled = false;
        }
        else
        {
            mesh1.mesh.enabled = true;
            if (ControlaJogo.instance.escolhaPerso == "Josue") josueObj.SetActive(true);
            if (ControlaJogo.instance.escolhaPerso == "Mei") meiObj.SetActive(true);
            mesh3.mesh.enabled = true;
            if (canhaoOn)
                meshCanhao.mesh.enabled = true;
            if (cortaPipa)
                cortaPipaMesh.mesh.enabled = true;
            if (pranchaOn)
                pranchaMesh.mesh.enabled = true;
        }


	}

    private void FixedUpdate()
    {
        //Calcular porcentagem da gasolina e desacelerção depois da gasolina acabar;
        speed = Mathf.Clamp(speed, 0, 15);
        gas = Mathf.Clamp(gas, 0, gasMax);
        if (!completou && !ControlaFase.isPaused && !controlaFase.perdeu) gas -= 2.5f * Time.deltaTime;
        gasRatio = gas / gasMax;

        if (gas < 1 && !controlaFase.perdeu)
        {
            speed -= 2.0f * Time.deltaTime;
            Parando();
        }

        if (parando && !controlaFase.perdeu)
        {
            speed -= 3.0f * Time.deltaTime;
        }

        if (reacelerando)
        {
            reacelerando = false;
            StartCoroutine("ParaReacelera");
        }

        //Cooldown dos powerups
        if (!ControlaFase.isPaused)
            if (reload > 0)
            {
                reload -= Time.deltaTime;
                reload = Mathf.Clamp(reload, 0, canhaoTax);
            }

    }

    //Se estiver indo para direita lane +1 senão lane -1;
    void MoveLane(bool indoDireita)
    {
        if (!inverteControle)
            desiredLane += (indoDireita) ? 1 : -1;
        else desiredLane += (indoDireita) ? -1 : 1;

        if (!fourLanes)
            desiredLane = Mathf.Clamp(desiredLane, 0, 1);
        else desiredLane = Mathf.Clamp(desiredLane, -1, 2);

    }

    //Detectar colisões para coleta de itens, finalização da fase e outras detecções;
    void OnTriggerEnter(Collider other)
    {
        //Coletáveis;
        if (other.gameObject.tag == "clock")
        {
            ControlaAudio.instance.TocaAudio(relogioSFX);
            if (coletaVital)
            {
                StartCoroutine(ColetaVital(coletaVitalTemp));
            }
            controlaFase.MudaTempo(10);

            Destroy(other.gameObject);
        }
        if (other.gameObject.tag == "gas")
        {
            ControlaAudio.instance.TocaAudio(gasolinaSFX);
            if (coletaVital)
            {
                StartCoroutine(ColetaVital(coletaVitalTemp));
            }
            gas += 15;

            Destroy(other.gameObject);
        }
        if (other.gameObject.tag == "tool")
        {
            ControlaAudio.instance.TocaAudio(ferramentaSFX);
            if (coletaVital)
            {
                StartCoroutine(ColetaVital(coletaVitalTemp));
            }
            ControlaVida(1);

            Destroy(other.gameObject);
        }
        if (other.gameObject.tag == "capacete")
        {
            ControlaAudio.instance.TocaAudio(capaceteSFX);
            if (coletaVital)
            {
                StartCoroutine(ColetaVital(coletaVitalTemp));
            }
            SomaCapacete(1);

            Destroy(other.gameObject);
        }

        //Poça de água
        if (other.gameObject.tag == "poca")
        {
            passaNagua.Play();
            ControlaAudio.instance.TocaAudio(passaNaguaSFX);
            if (!pranchaOn) speed = 3;
        }

        //Final e mudança de número de lanes;
        if ((other.gameObject.tag == "final") && (gas > 0))
        {
            CompletaFase(true);
        }
        if (other.gameObject.tag == "fourLanes")
            fourLanes = true;

        //Subida e Descida;
        if (other.gameObject.tag == "subida")
        {
            subida = true;
            descida = false;
            reta = false;
        }
        if (other.gameObject.tag == "descida")
        {
            subida = false;
            descida = true;
            reta = false;
        }
        if (other.gameObject.tag == "reta")
        {
            subida = false;
            descida = false;
            reta = true;
        }
            
    }

    //Detectar ao sair do trigger;
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "poca")
        {
            passaNagua.Stop();            
            if (!pranchaOn) speed = speedMax;
        }
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "bala")
        {
            Destroy(other.gameObject.GetComponent<Collider>());
            ControlaVida(-1);
            tomaDanoEfeito.Play();
            if (vida > 0)
            {
                StartCoroutine(Piscando(5));
                StartCoroutine("Invulneravel");
                ControlaAudio.instance.TocaAudio(batidaSFX);
            }
            else
            {
                invisivel = true;
                ControlaAudio.instance.TocaAudio(batida2SFX);
            }

        }
    }

    //Controla pontos de vida
    public void ControlaVida(int valor)
    {
        if (valor < 0)
        {
            vida += valor;
            tomaDanoEfeito.Play();
        }
        else if (vida < 3) vida += valor;
        hud.AtualizaVida(vida);

        if (vida == 0)
        {
            StartCoroutine(controlaFase.Derrota(true, 0));
            StartCoroutine(Desativa());
        }
    }

    //Controla capacetes pego na fase;
    void SomaCapacete(int valor)
    {
        capaceteCont += valor;
        hud.AtualizaCapaceteC(capaceteCont);
    }

    //Altera Velocidade
    public void AlteraVelocidade(float valor, bool reacelera)
    {
        speed = valor;
        reacelerando = reacelera;
    }

    //Verifica término da fase
    public void CompletaFase(bool condition)
    {
        completou = condition;
        controlaFase.Terminou();

        dinheiroBonusG = gasRatio * 150;
        dinheiroBonusT = controlaFase.tempo * 2.4f;
        dinheiroTotal = dinheiroBonusG + dinheiroBonusT + dinheiroFase;

        ControlaJogo.instance.dinheiroTotal += dinheiroTotal;
        ControlaJogo.instance.capaceteTotal += capaceteCont;
        controlaFase.DinheiroTotalFase(dinheiroTotal);

        hud.terminaFase(dinheiroBonusG, dinheiroBonusT, dinheiroFase, dinheiroTotal, capaceteCont);
    }

    //Recebe valor do pagamento da fase
    public void RecebeValor(float valor)
    {
        dinheiroFase = valor;
    }

    //Derrota Gasolina/Pipa
    public void Parando()
    {
        parando = true;
        StartCoroutine(controlaFase.Derrota(true, 2));
    }

    //Inverter Controle
    public void InverteControle(bool condition)
    {
        inverteControle = condition;
    }

    //Desativar
    IEnumerator Desativa()
    {
        speed = 0;
        invisivel = true;
        yield return new WaitForSeconds(2);
        gameObject.SetActive(false);
    }

    //Powerups

    //Efeito de Invencibilidade;
    IEnumerator Invencivel(float duracao)
    {
        ControlaAudio.instance.TocaAudio(ativaFantasmaSFX);
        ControlaAudio.instance.TocaAudioLoop(fantasmaSFX);
        fantasmaEfeito.Play();
        isPuLock = true;
        invisivel = true;
        personagemTranspa.SetActive(true);
        StartCoroutine(TempoRecarga(motoFantasmaCD, motoFantasmaCD));
        gameObject.layer = 8;
        yield return new WaitForSeconds(duracao);
        ControlaAudio.instance.ParaAudioLoop();
        fantasmaEfeito.Stop();
        gameObject.layer = 0;
        personagemTranspa.SetActive(false);
        invisivel = false;
    }

    //Efeito Corta Pipa;
    IEnumerator CortaPipa(float duracao)
    {
        ControlaAudio.instance.TocaAudio(equipaCortaPipaSFX);
        isPuLock = true;
        StartCoroutine(TempoRecarga(cortaPipaCD, cortaPipaCD));
        cortaPipa = true;
        cortaPipaMesh.mesh.enabled = true;
        yield return new WaitForSeconds(duracao);
        cortaPipaMesh.mesh.enabled = false;
        cortaPipa = false;
    }

    //Efeito Prancha;
    IEnumerator Prancha(float duracao)
    {
        ControlaAudio.instance.TocaAudio(ativaPranchaSFX);
        StartCoroutine(TempoRecarga(pranchaCD, pranchaCD));
        isPuLock = true;
        pranchaOn = true;
        pranchaMesh.mesh.enabled = true;
        yield return new WaitForSeconds(duracao);
        pranchaMesh.mesh.enabled = false;
        pranchaOn = false;
    }

    //Efeito Canhao;
    IEnumerator CanhaoComida(float duracao)
    {
        ControlaAudio.instance.TocaAudio(equipaCanhaoSFX);
        StartCoroutine(TempoRecarga(canhaoComidaCD, canhaoComidaCD));
        isPuLock = true;
        canhaoOn = true;
        meshCanhao.mesh.enabled = true;
        yield return new WaitForSeconds(duracao);
        meshCanhao.mesh.enabled = false;
        canhaoOn = false;        
    }

    //Aero-Propulsor;
    IEnumerator Propulsor()
    {              
        yield return new WaitForSeconds(0.3f);
        ControlaAudio.instance.TocaAudio(propulsorSFX);
        speed += propulsorForce;
        propulsorEfeito.Play();
        yield return new WaitForSeconds(1f);
        propulsorEfeito.Stop();
        speed = speedMax;
    }

    //Coleta Vital, tempo de invulnerabilidade após pega um item;
    IEnumerator ColetaVital(float duracao)
    {
        ControlaAudio.instance.TocaAudio(coletaOnSFX);
        escudo.mesh.enabled = true;
        gameObject.layer = 8;
        yield return new WaitForSeconds(duracao);
        gameObject.layer = 0;
        escudo.mesh.enabled = false;
        escudoQuebra.Play();
        ControlaAudio.instance.TocaAudio(coletaOffSFX);
    }

    //Para Reaceleramento
    IEnumerator ParaReacelera()
    {
        yield return new WaitForSeconds(0.5f);
        speed += 2f;
        yield return new WaitForSeconds(0.5f);
        speed += 2f;
        yield return new WaitForSeconds(0.5f);
        speed += 1f;
        yield return new WaitForSeconds(0.5f);
        speed = speedMax;
    }

    //Cooldown skills
    public IEnumerator TempoRecarga(float cooldown, float cooldownMax)
    {
        StartCoroutine(hud.AtivaCD(cooldown, cooldownMax));
        cooldownPu = cooldown + 0.01f;
        while (cooldownPu > 0)
        {
            if (ControlaFase.isPaused)
            {
                controlaFase.RecebeCD(cooldownPu, cooldownMax);
                break;
            }
            cooldownPu -= 0.1f;
            yield return new WaitForSeconds(0.1f);
        }
        if (!ControlaFase.isPaused) isPuLock = false;
    }


    //Pisca por hit do boss
    IEnumerator Invulneravel()
    {
        gameObject.layer = 8;
        yield return new WaitForSeconds(2);
        if (reparoLento)
        {
            ControlaAudio.instance.TocaAudio(reparoLentoSFX);
            yield return new WaitForSeconds(reparoLentoTemp);
        }
        gameObject.layer = 13;
    }
    IEnumerator Piscando(int piscadas)
    {
        isPuLock = true;
        if (reparoLento)
        {
            piscadas += reparoLentoPisc;
        }
        for (int i = 0; i < piscadas; i++)
        {
            invisivel = true;
            yield return delay;
            invisivel = false;
            yield return delay;
        }
        isPuLock = false;
    }

}
