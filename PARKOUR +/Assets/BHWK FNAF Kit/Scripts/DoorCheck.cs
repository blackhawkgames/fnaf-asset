using UnityEngine;

public class DoorCheck : MonoBehaviour
{
    public Animator animDoor;
    public bool isOpen;
    public Bateria b;

    private void Start()
    {
        b = FindObjectOfType<Bateria>();
    }
    public void DoorCheck1()
    {
        if(isOpen == true)
        {
            animDoor.SetBool("isOpen", false);
            isOpen = false;
            b.multiplicadorNivel++;
        }
        else if(isOpen == false)
        {
            animDoor.SetBool("isOpen", true);
            isOpen = true;
            b.multiplicadorNivel--;
        }
    }
}
