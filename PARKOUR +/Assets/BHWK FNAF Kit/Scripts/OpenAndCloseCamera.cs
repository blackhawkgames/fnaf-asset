using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class OpenAndCloseCamera : MonoBehaviour, IPointerEnterHandler
{
    public GameObject camObj;
    public float TempoDeTransicão = 1f;
    public Animator animCam;
    public bool isOpen = false;
    private Bateria b;
    public AudioSource AudioS;
    private void Start()
    {
        b = FindObjectOfType<Bateria>();
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        AudioS.Play();
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
