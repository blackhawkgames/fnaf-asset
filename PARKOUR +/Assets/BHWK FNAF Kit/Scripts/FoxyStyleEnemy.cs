using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FoxyStyleEnemy : MonoBehaviour
{
    public GameObject objectToMove;
    public GameObject enemyDoor;
    public DoorCheck dc;
    public Transform[] positions;
    public AudioSource playAvisoTchau;
    public WinMode wm;
    public GameObject HUD;
    public GameObject jumpscare;
    public GameObject telapreta;
    public GameObject transicoes;

    [Header("Tempo Pra Dar Um Giro")]
    public float tempoParaInicio;
    [Header("Posicao final do Animatronic")]
    public int posicaoLimite;
    [Header("TEMPOS PARA ATACAR")]
    public float tempoDeCorrida = 5.5f;
    [Header("TEMPOS PARA MOVIMENTAR")]
    public float tempoMinimoMove = 5.5f;
    public float tempoMaximoMove = 12f;


    private int currentPositionIndex = 0;
    private bool stopMoving = false;

    void Start()
    {
        StartCoroutine(RandomizePosition());
    }

    IEnumerator RandomizePosition()
    {
        yield return new WaitForSeconds(tempoParaInicio);
        while (!stopMoving)
        {
            currentPositionIndex++;
            StartCoroutine(transicao());
            // Move o objeto para a nova posição
            objectToMove.transform.position = positions[currentPositionIndex].position;

            // Se chegar à posição 5, para a randomização
            if (currentPositionIndex == posicaoLimite)
            {
                stopMoving = true;

                StartCoroutine(StartAttack());
            }

            // Espera pelo intervalo antes de mudar de posição novamente
            yield return new WaitForSeconds(Random.Range(tempoMinimoMove, tempoMaximoMove));
        }
    }

    IEnumerator StartAttack()
    {
        yield return new WaitForSeconds(Random.Range(tempoMinimoMove, tempoMaximoMove));
        objectToMove.SetActive(false);
        Attack();
    }
    void Attack()
    {
        enemyDoor.SetActive(true);
        StartCoroutine(transicao());
        StartCoroutine(AttackTime());
    }

    IEnumerator AttackTime()
    {
        yield return new WaitForSeconds(tempoDeCorrida);
        if(dc.isOpen == false)
        {
            currentPositionIndex = 0;
            stopMoving = false;
            StartCoroutine(RandomizePosition());
            playAvisoTchau.Play();
            enemyDoor.SetActive(false);
            objectToMove.SetActive(true);
        }
        else
        {
            KillPlayer();
        }
    }
    void KillPlayer()
    {
        enemyDoor.SetActive(false);
        wm.enabled = false;
        HUD.SetActive(false);
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
