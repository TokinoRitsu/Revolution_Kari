using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class BackButtonController : MonoBehaviour
{
    private string sceneName;
    private UIManager uiManager;
    private Manager gameManager;
    private BattleManager battleManager;
    private SettingsPersistenceManager settingsManager;
    private void Awake()
    {
        uiManager = GameObject.Find("UIManager").GetComponent<UIManager>();
        sceneName = SceneManager.GetActiveScene().name;
        settingsManager = GameObject.Find("SettingsPersistenceManager").GetComponent<SettingsPersistenceManager>();
        if (sceneName == "MenuScene") this.GetComponent<Button>().onClick.AddListener(() => BackButtonAction_Menu());
        else if (sceneName == "GameScene")
        {
            gameManager = GameObject.Find("Manager").GetComponent<Manager>();
            if (gameManager.mode == Manager.gameMode.Battling)
            {
                battleManager = GameObject.FindGameObjectWithTag("BattleManager").GetComponent<BattleManager>();
                this.GetComponent<Button>().onClick.AddListener(() => BackButtonAction_Game());
            }
        }
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse1))
        {
            if (sceneName == "GameScene")
            {
                if (gameManager.mode == Manager.gameMode.Battling)
                {
                    if (battleManager.counter > 0) BackButtonAction_Game();
                }
            }
            else if (sceneName == "MenuScene")
            {
                BackButtonAction_Menu();
            }
        }
    }

    private void BackButtonAction_Menu()
    {
        if (!uiManager.isClicked)
        {
            settingsManager.SaveSettings();
            uiManager.isClicked = true;
            StartCoroutine(backToPreviousPanel());
        }
    }

    private void BackButtonAction_Game()
    {
        if (gameManager.mode == Manager.gameMode.Battling)
        {
            battleManager.counter--;
            battleManager.actions.Remove(battleManager.actions[battleManager.actions.Count - 1]);

            while (!battleManager.tempUnits[battleManager.counter].isAlly)
            {
                battleManager.counter--;
                battleManager.actions.Remove(battleManager.actions[battleManager.actions.Count - 1]);
            }

            battleManager.counter--;

            Destroy(transform.parent.gameObject);
            battleManager.finishedChoosing = true;
        }
    }

    private IEnumerator backToPreviousPanel()
    {
        uiManager.startPlusX1920();
        yield return new WaitForSeconds(0.7f);
        uiManager.isClicked = true;
        uiManager.RemovePanel(uiManager.panels[uiManager.panels.Count - 1]);
        uiManager.isClicked = false;
    }
}
