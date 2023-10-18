using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour, ISettingsPersistence
{
    private Manager gameManager;

    public int currentPanel = 0;
    public List<GameObject> panels;
    private Canvas canvas;

    public GameObject mainPanel;
    public GameObject loadPanel;
    public GameObject optionPanel;
    public GameObject creditsPanel;
    public GameObject captionPanel;
    public GameObject gameMenuPanel;

    public bool isClicked = false;
    public bool isBlacked = false;

    public GameObject blackOutPanel;

    private static float pi = 3.1415926535f;
    private static float panelSpeed = 16.7551608192f;

    public float captionSpeed;
    public float masterVolume;
    public float bgmVolume;
    public float sfxVolume;

    public static UIManager instance { get; private set; }

    private void Awake()
    {
        if (instance != null)
        {
            Debug.LogError("Found more than one Data Persistence Manager in the scene.");
        }
        instance = this;
        this.canvas = GameObject.Find("Canvas").GetComponent<Canvas>();
        if (SceneManager.GetActiveScene().name == "MenuScene")
        {
            this.panels.Add(Instantiate(mainPanel, canvas.transform));
            this.panels[0].transform.SetParent(canvas.transform);
        }
        else if (SceneManager.GetActiveScene().name == "GameScene")
        {
            this.gameManager = GameObject.Find("Manager").GetComponent<Manager>();
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        StartFadeOut();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Backspace))
        {
            // if (!isBlacked) StartFadeInOut();
        }
    }

    

    public GameObject InstantiatePanel(GameObject _panel)
    {
        GameObject panelObject = Instantiate(_panel, canvas.transform);
        this.panels.Add(panelObject);
        this.currentPanel = panels.Count - 1;
        return panelObject;
    }

    public void RemovePanel(GameObject _panel)
    {
        this.panels.Remove(_panel);
        Destroy(_panel);
        this.currentPanel--;
    }

    public void startPlusX1920()
    {
        StartCoroutine(plusX1920());
        RoundTo1920();
    }

    public void startMinusX1920()
    {
        StartCoroutine(minusX1920());
        RoundTo1920();
    }

    public void RoundTo1920()
    {
        this.panels[0].GetComponent<RectTransform>().anchoredPosition = new Vector2(Mathf.Round(panels[0].GetComponent<RectTransform>().anchoredPosition.x / 1920) * 1920, 0f);
        this.panels[1].GetComponent<RectTransform>().anchoredPosition = new Vector2(Mathf.Round(panels[1].GetComponent<RectTransform>().anchoredPosition.x / 1920) * 1920, 0f);
    }

    public float RoundToNumber(float num, float roundTo)
    {
        return Mathf.Round(num / roundTo) * roundTo;
    }


    public void StartFadeIn()
    {
        GameObject insBlackOutPanel = Instantiate(blackOutPanel, canvas.transform);
        StartCoroutine(insBlackOutPanel.GetComponent<BlackOutPanelController>().FadeBlackOut(true));
    }

    public void StartFadeOut()
    {
        GameObject insBlackOutPanel = Instantiate(blackOutPanel, canvas.transform);
        StartCoroutine(insBlackOutPanel.GetComponent<BlackOutPanelController>().FadeBlackOut(false));
    }

    public void StartFadeInOut()
    {
        StartCoroutine(FadeInOut());
    }

    public void playFromCaptionPanel(int index)
    {
        gameManager.mode = Manager.gameMode.Talking;
        CaptionPanelController captionPanelCon = Instantiate(captionPanel, canvas.transform).GetComponent<CaptionPanelController>();
        captionPanelCon.gameObject.transform.SetParent(canvas.transform);
        captionPanelCon.playLine(index);
    }

    public void openMenu()
    {
        gameManager.mode = Manager.gameMode.OnMenu;
        GameObject menuObject = Instantiate(gameMenuPanel, canvas.transform);
        StartCoroutine(plusY(menuObject, menuObject.GetComponent<RectTransform>().sizeDelta.y, null));
    }

    public void closeMenu()
    {
        gameManager.mode = Manager.gameMode.Normal;
        GameObject menuObject = GameObject.FindGameObjectWithTag("GameMenuPanel");
        StartCoroutine(plusY(menuObject, -1 * menuObject.GetComponent<RectTransform>().sizeDelta.y, () => CloseButtonController.CloseButtonAction(GameObject.FindGameObjectWithTag("CloseMenuButton"))));
    }

    public void QuitApp()
    {
        Application.Quit();
    }


    private IEnumerator plusX1920()
    {
        float counter = 0;
        while (counter <= 180)
        {
            foreach (GameObject j in panels) j.GetComponent<RectTransform>().anchoredPosition += new Vector2(panelSpeed * Mathf.Sin((counter * pi) / 180f), 0f);
            counter++;
            yield return null;
        }
    }

    private IEnumerator minusX1920()
    {
        float counter = 0;
        while (counter <= 180)
        {
            foreach (GameObject j in panels) j.GetComponent<RectTransform>().anchoredPosition -= new Vector2(panelSpeed * Mathf.Sin((counter * pi) / 180f), 0f);
            counter++;
            yield return null;
        }
    }

    public IEnumerator plusY(GameObject _object, float y, System.Action action)
    {
        float counter = 0;
        float sum = 2 / pi * 181;
        float speed = y / sum;
        while (counter <= 180)
        {
            Vector3 pos = _object.GetComponent<RectTransform>().anchoredPosition;
            _object.GetComponent<RectTransform>().anchoredPosition += new Vector2(pos.x, speed * Mathf.Sin((counter * pi) / 180f));
            counter++;
            yield return null;
        }
        Vector3 _pos = _object.GetComponent<RectTransform>().anchoredPosition;
        _object.GetComponent<RectTransform>().anchoredPosition = new Vector2(_pos.x, RoundToNumber(_pos.y, 1));
        if (action != null) action();
    }

    public IEnumerator FadeInOut()
    {
        isBlacked = true;
        GameObject insBlackOutPanel = Instantiate(blackOutPanel, canvas.transform);
        insBlackOutPanel.transform.SetParent(canvas.transform);
        StartCoroutine(insBlackOutPanel.GetComponent<BlackOutPanelController>().FadeBlackOut(true));
        yield return new WaitForSeconds(2f);
        StartCoroutine(insBlackOutPanel.GetComponent<BlackOutPanelController>().FadeBlackOut(false));
        yield return new WaitForSeconds(2f);
        Destroy(insBlackOutPanel);
        isBlacked = false;
    }

    public void LoadSettings(GameSettings data)
    {
        this.captionSpeed = data.captionSpeed;
        this.masterVolume = data.masterVolume;
        this.bgmVolume = data.bgmVolume;
        this.sfxVolume = data.sfxVolume;
    }
    public void SaveSettings(ref GameSettings data)
    {
        data.captionSpeed = this.captionSpeed;
        data.masterVolume = this.masterVolume;
        data.bgmVolume = this.bgmVolume;
        data.sfxVolume = this.sfxVolume;
    }
}
