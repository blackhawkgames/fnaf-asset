using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartCutscene : MonoBehaviour
{
    private WinMode wm;
    public GameObject startCut;
    public float TempoPraIniciar = 5f;
    void Start()
    {
        wm = FindObjectOfType<WinMode>();
        wm.enabled = false;
        StartCoroutine(Inicio());
    }
    IEnumerator Inicio()
    {
        yield return new WaitForSeconds(TempoPraIniciar);
        startCut.SetActive(false);
        wm.enabled = true;
    }
}
