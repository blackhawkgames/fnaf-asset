using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class PlayerData
{
    public int level;
    public PlayerData (GameManager gm)
    {
        level = gm.NoiteAtual;
    }
}
