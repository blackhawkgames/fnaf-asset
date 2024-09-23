using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartCutscene : MonoBehaviour
{
    private WinMode wm;
    public List<GameObject> gmsToTurnAfter;
    public GameObject startCut;
    public float TempoPraIniciar = 5f;
    void Start()
    {
        wm = FindObjectOfType<WinMode>();
        wm.enabled = false;
        foreach (GameObject obj in gmsToTurnAfter)
        {
            // Exemplo: Ativar todos os objetos na lista
            obj.SetActive(false);
        }
        StartCoroutine(Inicio());

    }
    IEnumerator Inicio()
    {
        yield return new WaitForSeconds(TempoPraIniciar);
        startCut.SetActive(false);
        foreach (GameObject obj in gmsToTurnAfter)
        {
            // Exemplo: Ativar todos os objetos na lista
            obj.SetActive(true);
        }
        wm.enabled = true;
    }
}
