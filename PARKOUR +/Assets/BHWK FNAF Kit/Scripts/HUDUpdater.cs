using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class HUDUpdater : MonoBehaviour
{
    public TextMeshProUGUI text;
    private GameManager gm;

    private void Start()
    {
        gm = FindObjectOfType<GameManager>();
        text.text = "NIGHT " + gm.NoiteAtual;

    }
}
