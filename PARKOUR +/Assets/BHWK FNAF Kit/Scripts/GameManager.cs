using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    public int NoiteAtual;
    [Header("Troca De Posicões. Quanto menos - Mais Rápido")]
    public float VelocidadeDaNoite1;
    public float VelocidadeDaNoite2;
    public float VelocidadeDaNoite3;
    public float VelocidadeDaNoite4;
    public float VelocidadeDaNoite5;
    public float VelocidadeDaNoite6;
    [HideInInspector]
    public float velocidade;
    public static GameObject instance;
    private void Start()
    {
        DontDestroyOnLoad(gameObject);

        if (instance == null)
            instance = gameObject;
        else
            Destroy(gameObject);
        PlayerData data = SaveSystem.LoadPlayer();
        if(data != null)
        {
            NoiteAtual = data.level;
        }
        else
        {
            NoiteAtual = 1;
        }
    }

    private void Update()
    {
        if(NoiteAtual == 1)
        {
            velocidade = VelocidadeDaNoite1;
        }
        else if(NoiteAtual == 2)
        {
            velocidade = VelocidadeDaNoite2;
        }
        else if (NoiteAtual == 3)
        {
            velocidade = VelocidadeDaNoite3;
        }
        else if (NoiteAtual == 4)
        {
            velocidade = VelocidadeDaNoite4;
        }
        else if (NoiteAtual == 5)
        {
            velocidade = VelocidadeDaNoite5;
        }
        else if (NoiteAtual == 6)
        {
            velocidade = VelocidadeDaNoite6;
        }
    }
}
