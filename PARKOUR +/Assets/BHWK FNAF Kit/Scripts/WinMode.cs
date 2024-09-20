using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class WinMode : MonoBehaviour
{
    public float TempoParaMudarAHora = 60f;
    private int actualTime;
    public TextMeshProUGUI TextoHora;
    public GameObject allEnemies;
    public GameObject NightTransition1;
    private GameManager gm;
    public GameObject EventSystem;

    private void Start()
    {
        gm = FindObjectOfType<GameManager>();
        StartCoroutine(Contagem());
    }


    IEnumerator Contagem()
    {
        TextoHora.text = "12:00AM";
        actualTime = 0;
        yield return new WaitForSeconds(TempoParaMudarAHora);
        TextoHora.text = "01:00AM";
        actualTime = 1;
        yield return new WaitForSeconds(TempoParaMudarAHora);
        TextoHora.text = "02:00AM";
        actualTime = 2;
        yield return new WaitForSeconds(TempoParaMudarAHora);
        TextoHora.text = "03:00AM";
        actualTime = 3;
        yield return new WaitForSeconds(TempoParaMudarAHora);
        TextoHora.text = "04:00AM";
        actualTime = 4;
        yield return new WaitForSeconds(TempoParaMudarAHora);
        TextoHora.text = "05:00AM";
        actualTime = 5;
        yield return new WaitForSeconds(TempoParaMudarAHora);
        TextoHora.text = "06:00AM";
        actualTime = 6;
        if (actualTime == 6 && gm.NoiteAtual < 6)
        {
            WinNight();
        }
        else if(actualTime == 6 && gm.NoiteAtual >= 6)
        {
            Application.Quit();
        }
    }

    void WinNight()
    {
        allEnemies.SetActive(false);
        StartCoroutine(NightTransition());
    }

    IEnumerator NightTransition()
    {
        NightTransition1.SetActive(true);
        EventSystem.SetActive(false);
        yield return new WaitForSeconds(7f);
        gm.NoiteAtual++;
        SaveSystem.SavePlayer(gm);
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
