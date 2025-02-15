using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EnemyPositions : MonoBehaviour
{
    public GameObject objectToMove;
    public GameObject enemyDoor;
    public LightSystem ls;
    public DoorCheck dc;
    public Transform[] positions;
    public AudioSource playAvisoTchau;
    public WinMode wm;
    public GameObject HUD;
    public GameObject jumpscare;
    public GameObject telapreta;
    public GameObject camAnim;
    public GameObject camObj;
    public GameObject transicoes;
    public List<GameObject> events;



    [Header("Tempo Pra Dar Um Giro")]
    public float tempoParaInicio;
    [Header("Posicao limite inicial do Animatronic")]
    public int posicaoLimiteInicio;
    [Header("Posicao final do Animatronic")]
    public int posicaoLimite;
    [Header("TEMPOS PARA ATACAR")]
    public float tempoMinimo = 5.5f;
    public float tempoMaximo = 10.5f;
    private int lastPos;
    private int currentPositionIndex = 0;
    private bool stopMoving = false;
    private bool startingAttack = false;
    private bool iniciar = false;
    private GameManager gm;

    void Start()
    {
        gm = FindObjectOfType<GameManager>();
        // Inicia a mudan�a de posi��o repetitiva
        StartCoroutine(RandomizePosition());
    }

    private void Update()
    {
        if(iniciar == true && startingAttack == false)
        {
            events[currentPositionIndex].SetActive(true);
        }
        
        if (ls.lightObj.activeSelf == true && startingAttack == true)
        {
            enemyDoor.SetActive(true);
        }
        else
        {
            enemyDoor.SetActive(false);
        }

    }

    IEnumerator RandomizePosition()
    {
        yield return new WaitForSeconds(tempoParaInicio);
        iniciar = true;
        objectToMove.SetActive(false);

        int secondLastPos = -1; // Vari�vel para armazenar a pen�ltima posi��o

        while (!stopMoving)
        {
            if (currentPositionIndex < posicaoLimiteInicio)
            {
                // Randomiza entre as posi��es 0 a 3, garantindo que a posi��o n�o seja igual a lastPos ou secondLastPos
                do
                {
                    currentPositionIndex = Random.Range(0, posicaoLimiteInicio + 1);
                } while (currentPositionIndex == lastPos || currentPositionIndex == secondLastPos);

                StartCoroutine(transicao());
            }
            else if (currentPositionIndex >= posicaoLimiteInicio && currentPositionIndex < posicaoLimite)
            {
                // Randomiza entre as posi��es 4 a 5, garantindo que a posi��o n�o seja igual a lastPos ou secondLastPos
                do
                {
                    currentPositionIndex = Random.Range(posicaoLimiteInicio + 1, posicaoLimite + 1);
                } while (currentPositionIndex == lastPos || currentPositionIndex == secondLastPos);

                StartCoroutine(transicao());
            }

            // Move o objeto para a nova posi��o
            events[lastPos].SetActive(false);
            events[currentPositionIndex].transform.position = positions[currentPositionIndex].position;

            // Se chegar � posi��o 5, para a randomiza��o
            if (currentPositionIndex == posicaoLimite)
            {
                stopMoving = true;
                StartCoroutine(StartAttack());
            }

            // Atualiza secondLastPos antes de lastPos
            secondLastPos = lastPos;
            lastPos = currentPositionIndex;

            // Espera pelo intervalo antes de mudar de posi��o novamente
            yield return new WaitForSeconds(gm.velocidade);
        }
    }


    IEnumerator StartAttack()
    {
        yield return new WaitForSeconds(gm.velocidade);
        foreach (GameObject obj in events)
        {
            // Exemplo: Ativar todos os objetos na lista
            obj.SetActive(false);
        }
        startingAttack = true;
        Attack();
    }
    void Attack()
    {
        StartCoroutine(transicao());
        StartCoroutine(AttackTime());
    }

    IEnumerator AttackTime()
    {
        yield return new WaitForSeconds(Random.Range(tempoMinimo, tempoMaximo));
        if(dc.isOpen == false)
        {
            startingAttack = false;
            currentPositionIndex = Random.Range(1, posicaoLimiteInicio);
            stopMoving = false;
            StartCoroutine(RandomizePosition());
            playAvisoTchau.Play();
            events[currentPositionIndex].SetActive(true);
        }
        else
        {
            KillPlayer();
        }
    }
    void KillPlayer()
    {
        wm.enabled = false;
        HUD.SetActive(false);
        camObj.SetActive(false);
        camAnim.SetActive(false);
        StartCoroutine(KillCount());
    }

    IEnumerator KillCount()
    {
        jumpscare.SetActive(true);
        yield return new WaitForSeconds(3);
        telapreta.SetActive(true);
        jumpscare.SetActive(false);
        yield return new WaitForSeconds(7);
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    IEnumerator transicao()
    {
        transicoes.SetActive(true);
        yield return new WaitForSeconds(0.3f);
        transicoes.SetActive(false);
    }
}
