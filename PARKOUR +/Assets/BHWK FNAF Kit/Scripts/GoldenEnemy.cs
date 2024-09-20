using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoldenEnemy : MonoBehaviour
{
    public GameObject enemy;
    public GameObject panfleto;
    public GameObject HUDbutton;
    public GameObject KillImage;
    public float TempoParaAtacar;
    private OpenAndCloseCamera oc;
    private WinMode wm;
    private CameraManager c;
    public int NumCamPanfleto;

    private void Start()
    {
        oc = FindObjectOfType<OpenAndCloseCamera>();
        c = FindObjectOfType<CameraManager>();
        wm = FindObjectOfType<WinMode>();
    }
    private void Update()
    {
        if (panfleto.activeSelf == true)
        {
            if (oc.isOpen == false)
            {
                enemy.SetActive(true);
                HUDbutton.SetActive(false);
                StartCoroutine(Kill());
            }
        }
    }

    public void StartTry()
    {
        int number = Random.Range(0, 100);
        if(number >= 98)
        {
            panfleto.SetActive(true);
        }     
    }

    IEnumerator Kill()
    {
        yield return new WaitForSeconds(TempoParaAtacar);
        wm.enabled = false;
        KillImage.SetActive(true);
        yield return new WaitForSeconds(2);
        Application.Quit();
    }
}
