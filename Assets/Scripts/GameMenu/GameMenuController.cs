using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameMenuController : MonoBehaviour
{
    private Manager gameManager;
    private UIManager uiManager;
    private DataPersistenceManager dataManager;
    public Button optionButton;
    public Button saveDataButton;
    public Button closeMenuButton;
    private void Awake()
    {
        gameManager = GameObject.FindGameObjectWithTag("Manager").GetComponent<Manager>();
        uiManager = GameObject.FindGameObjectWithTag("UIManager").GetComponent<UIManager>();
        dataManager = GameObject.Find("DataPersistenceManager").GetComponent<DataPersistenceManager>();
    }
    // Start is called before the first frame update
    void Start()
    {
        closeMenuButton.onClick.AddListener(() => uiManager.closeMenu());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnDestroy()
    {
        gameManager.mode = Manager.gameMode.Normal;
    }

}
