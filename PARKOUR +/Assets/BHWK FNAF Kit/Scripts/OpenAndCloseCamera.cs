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
    private bool canActivate = true;
    private void Start()
    {
        b = FindObjectOfType<Bateria>();
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        
        if (canActivate)
        {
            AudioS.Play();
            StartCoroutine(IniciarCam());
        }
    }

    IEnumerator IniciarCam()
    {
        if(isOpen == false)
        {
            canActivate = false;
            animCam.SetBool("Abrir", true);
            yield return new WaitForSeconds(TempoDeTransicão);
            isOpen = true;
            camObj.SetActive(true);
            b.multiplicadorNivel++;
            canActivate = true;
        }
        else
        {
            canActivate = false;
            animCam.SetBool("Abrir", false);
            yield return new WaitForSeconds(TempoDeTransicão);
            isOpen = false;
            camObj.SetActive(false);
            b.multiplicadorNivel--;
            canActivate = true;
        }
    }
}
