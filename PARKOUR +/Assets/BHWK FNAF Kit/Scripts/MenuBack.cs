using UnityEngine.SceneManagement;
using UnityEngine;

public class MenuBack : MonoBehaviour
{
    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            SceneManager.LoadScene(0);

        }
    }
}
