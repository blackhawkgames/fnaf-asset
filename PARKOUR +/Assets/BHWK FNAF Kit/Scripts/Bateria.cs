using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Bateria : MonoBehaviour
{
    public float quantidade = 100f;
    public List<GameObject> objectsToDeactivate;
    public List<DoorCheck> doors;
    public int multiplicadorNivel = 1;
    public AudioSource ass;
    public TextMeshProUGUI texto;


    private void Start()
    {
        StartCoroutine(IniciarContador());
    }
    void Update()
    {
        texto.text = quantidade + "%";
        if(quantidade <= 0)
        {
            StopCoroutine(IniciarContador());
            EndPower();
            quantidade = 0;
        }
    }

    void EndPower()
    {
        foreach (GameObject obj in objectsToDeactivate)
        {
            if (obj != null)
            {
                obj.SetActive(false); // Desativa o objeto
            }
        }
        foreach (DoorCheck dck in doors)
        {
            if(dck != null)
            {
                dck.isOpen = true;
                dck.animDoor.SetBool("isOpen", true);
            }
        }
        ass.Play();
    }

    IEnumerator IniciarContador()
    {
        yield return new WaitForSeconds(5.6f);
        quantidade = quantidade - multiplicadorNivel;
        StartCoroutine(IniciarContador());
    }
}
