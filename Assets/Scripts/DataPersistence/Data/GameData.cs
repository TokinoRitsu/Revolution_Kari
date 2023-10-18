using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class GameData
{
    public float playTime;
    public string playerName;
    public int money;
    public List<unit> allies;

    public GameData()
    {
        this.playTime = 0;
        this.playerName = "ジョン";
        this.money = 500;

        this.allies = new List<unit>();
    }
}
