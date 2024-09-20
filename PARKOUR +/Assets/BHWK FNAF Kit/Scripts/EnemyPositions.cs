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
    public GameObject transicoes;

    [Header("Tempo Pra Dar Um Giro")]
    public float tempoParaInicio;
    [Header("Posicao limite inicial do Animatronic")]
    public int posicaoLimiteInicio;
    [Header("Posicao final do Animatronic")]
    public int posicaoLimite;
    [Header("TEMPOS PARA ATACAR")]
    public float tempoMinimo = 5.5f;
    public float tempoMaximo = 10.5f;

    private int currentPositionIndex = 0;
    private bool stopMoving = false;
    private bool startingAttack = false;
    private GameManager gm;

    void Start()
    {
        gm = FindObjectOfType<GameManager>();
        // Inicia a mudança de posição repetitiva
        StartCoroutine(RandomizePosition());
    }

    private void Update()
    {
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
        while (!stopMoving)
        {
            if (currentPositionIndex < posicaoLimiteInicio)
            {
                // Randomiza entre as posições 0 a 3
                
                currentPositionIndex = Random.Range(0, posicaoLimiteInicio + 1);
                StartCoroutine(transicao());
            }
            else if (currentPositionIndex >= posicaoLimiteInicio && currentPositionIndex < posicaoLimite)
            {
                // Randomiza entre as posições 4 a 5
                currentPositionIndex = Random.Range(posicaoLimiteInicio + 1, posicaoLimite + 1);
                StartCoroutine(transicao());
            }

            // Move o objeto para a nova posição
            objectToMove.transform.position = positions[currentPositionIndex].position;

            // Se chegar à posição 5, para a randomização
            if (currentPositionIndex == posicaoLimite)
            {
                stopMoving = true;
                StartCoroutine(StartAttack());
            }

            // Espera pelo intervalo antes de mudar de posição novamente
            yield return new WaitForSeconds(gm.velocidade);
        }
    }

    IEnumerator StartAttack()
    {
        yield return new WaitForSeconds(gm.velocidade);
        objectToMove.SetActive(false);
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
            objectToMove.SetActive(true);
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
