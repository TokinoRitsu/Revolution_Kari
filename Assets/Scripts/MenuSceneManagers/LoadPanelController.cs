using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LoadPanelController : MonoBehaviour
{
    public Text questionText;
    public Text dataText;
    public GameObject loadDataButton;
    private DataPersistenceManager dataManager;
    private MainMenuPanelManager menuManager;
    

    private void Start()
    {
        dataManager = GameObject.Find("DataPersistenceManager").GetComponent<DataPersistenceManager>();
        menuManager = GameObject.Find("MainPanel(Clone)").GetComponent<MainMenuPanelManager>();

        if (dataManager.gameDataExist())
        {
            questionText.text = "このデータをロードします。よろしいですか？";
            dataText.text = dataManager.gameData.playerName + " Lv." + dataManager.gameData.allies[0].level.ToString() + "\nプレイ時間 " + dataManager.gameData.playTime.ToString();
            loadDataButton.SetActive(true);
            loadDataButton.GetComponent<Button>().onClick.AddListener(() => StartCoroutine(menuManager.LoadSavedGame()));
        }
        else
        {
            questionText.text = "ロードできるデータをみつかりませんでした。";
            dataText.text = "";
            loadDataButton.SetActive(false);
        }
    }
}
