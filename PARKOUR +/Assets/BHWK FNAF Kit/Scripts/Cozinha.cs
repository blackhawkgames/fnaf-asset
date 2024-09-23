using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cozinha : MonoBehaviour
{
    public AudioSource as1;
    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "INIMIGO")
        {
            as1.Play();
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "INIMIGO")
        {
            as1.Stop();

        }
    }
}
