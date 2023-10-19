using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SaveDataPanelController : MonoBehaviour
{
    public GameObject YesNoPanel;
    public GameObject closeButton;
    public Text dataText;

    private DataPersistenceManager dataManager;

    // Start is called before the first frame update
    void Start()
    {
        dataManager = GameObject.Find("DataPersistenceManager").GetComponent<DataPersistenceManager>();

        GameObject closeButtonObject = Instantiate(closeButton, gameObject.transform);
        closeButtonObject.GetComponent<RectTransform>().anchoredPosition = new Vector3(700, 290, 0);
        dataText.text = dataManager.gameData.playerName + " Lv." + dataManager.gameData.allies[0].level.ToString() + "\nプレイ時間 " + dataManager.gameData.playTime.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private IEnumerator SaveDataPanelAction()
    {

        yield return null;
    }
}
