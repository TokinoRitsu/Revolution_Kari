using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class Manager : MonoBehaviour, IDataPersistence
{
    public List<unit> allies = new List<unit>();
    public string playerName;
    public GameObject battlePanel;
    private Canvas canvas;
    private UIManager uiManager;
    public gameMode mode;

    private float playTimer = 0;


    public enum gameMode
    {
        Normal,
        Talking,
        OnMenu,
        Battling,
    }

    // Start is called before the first frame update
    void Start()
    {
        mode = gameMode.Normal;
        canvas = GameObject.Find("Canvas").GetComponent<Canvas>();
        if (UnityEngine.SceneManagement.SceneManager.GetActiveScene().name == "GameScene")
        {
            uiManager = GameObject.FindGameObjectWithTag("UIManager").GetComponent<UIManager>();
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            allies.Add(new unit(2, 100));
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            allies.Add(new unit(3, 100));
        }
        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            allies.Add(new unit(4, 100));
        }
        if (Input.GetKeyDown(KeyCode.B))
        {
            startBattle(Database.enemy_info[Database.enemy_info.Count - 1]);
        }
    }

    public IEnumerator WarpToMap(WarpController warp)
    {
        uiManager.StartFadeIn();
        yield return new WaitForSeconds(1);
        Destroy(GameObject.FindGameObjectWithTag("Map"));
        Instantiate(warp.mapObject);
        GameObject.FindGameObjectWithTag("Player").transform.position = warp.warpPosition;
        uiManager.StartFadeOut();
    }


    // Start Battle------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
    public void startBattle(List<unit> enemyUnits)
    {
        mode = gameMode.Battling;
        GameObject _battlePanel = Instantiate(battlePanel, canvas.transform);
        _battlePanel.transform.SetParent(canvas.transform);
        BattleManager battleManager = _battlePanel.GetComponentInChildren<BattleManager>();
        battleManager.tempUnits = new List<BattleManager.tempUnit>();
        for (int i = 0; i < allies.Count; i++) if (i < 3) battleManager.tempUnits.Add(new BattleManager.tempUnit(true, new unit(allies[i], false)));
        foreach (unit enemy in enemyUnits) battleManager.tempUnits.Add(new BattleManager.tempUnit(false, new unit(enemy, true)));
    }

    public void endBattle()
    {
        mode = 0;
    }


    //------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------

    public void LoadData(GameData data)
    {
        this.playerName = data.playerName;
        this.playTimer = data.playTime;
        this.allies = data.allies;
    }
    public void SaveData(ref GameData data)
    {
        data.playerName = this.playerName;
        data.playTime = this.playTimer;
        data.allies = this.allies;
    }
}
