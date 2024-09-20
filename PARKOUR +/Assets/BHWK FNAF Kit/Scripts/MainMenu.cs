using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class MainMenu : MonoBehaviour
{
    private GameManager gm;
    public GameObject continueButton;
    public TextMeshProUGUI t;
    void Start()
    {
        gm = FindObjectOfType<GameManager>();
        if(gm.NoiteAtual == 1)
        {
            continueButton.SetActive(false);
        }
        t.text = "NOITE" + gm.NoiteAtual;
    }
    public void NewGame()
    {
        gm.NoiteAtual = 1;
        SaveSystem.SavePlayer(gm);
        SceneManager.LoadScene(1);


    }
    public void ContinueGame()
    {
        SceneManager.LoadScene(1);
    }

    public void Leave()
    {
        Application.Quit();
    }
}
