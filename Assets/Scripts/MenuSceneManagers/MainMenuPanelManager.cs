using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainMenuPanelManager : MonoBehaviour
{
    private DataPersistenceManager dataManager;
    private UIManager uiManager;
    public GameObject[] mainMenuButtons;

    private void Awake()
    {
        dataManager = GameObject.Find("DataPersistenceManager").GetComponent<DataPersistenceManager>();
        uiManager = GameObject.Find("UIManager").GetComponent<UIManager>();
        mainMenuButtons[0].GetComponent<Button>().onClick.AddListener(() => StartCoroutine(StartNewGame()));
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public IEnumerator StartNewGame()
    {
        Debug.Log("StartNewGame");
        dataManager.NewGame();
        uiManager.StartFadeIn();
        yield return new WaitForSeconds(1.5f);
        SceneManager.LoadScene("GameScene");
    }

    public IEnumerator LoadSavedGame()
    {
        Debug.Log("LoadSavedGame");
        // dataManager.LoadGame();
        uiManager.StartFadeIn();
        yield return new WaitForSeconds(1.5f);
        SceneManager.LoadScene("GameScene");
    }


}
