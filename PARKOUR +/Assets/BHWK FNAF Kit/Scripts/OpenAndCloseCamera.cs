using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenAndCloseCamera : MonoBehaviour
{
    public GameObject camObj;
    public float TempoDeTransicão = 1f;
    public Animator animCam;
    public bool isOpen = false;
    public Bateria b;

    private void Start()
    {
        b = FindObjectOfType<Bateria>();
    }
    public void Abrir()
    {
        StartCoroutine(IniciarCam());
    }

    IEnumerator IniciarCam()
    {
        if(isOpen == false)
        {
            animCam.SetBool("Abrir", true);
            yield return new WaitForSeconds(TempoDeTransicão);
            camObj.SetActive(true);
            isOpen = true;
            b.multiplicadorNivel++;
        }
        else
        {
            animCam.SetBool("Abrir", false);
            yield return new WaitForSeconds(TempoDeTransicão);
            camObj.SetActive(false);
            isOpen = false;
            b.multiplicadorNivel--;
        }
    }
}
