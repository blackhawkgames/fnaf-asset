using UnityEngine;

public class LightSystem : MonoBehaviour
{
    public GameObject lightObj;
    public Bateria b;

    private void Start()
    {
        b = FindObjectOfType<Bateria>();
    }
    public void LightCheck()
    {
        if(lightObj.activeSelf == false)
        {
            lightObj.SetActive(true);
            b.multiplicadorNivel++;
        }
        else
        {
            lightObj.SetActive(false);
            b.multiplicadorNivel--;
        }
    }
}
