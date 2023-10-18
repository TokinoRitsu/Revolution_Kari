using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OptionPanelController : MonoBehaviour
{
    private UIManager uiManager;

    public GameObject[] optionPanels;

    public Button textOptionButton;
    public Button audioOptionButton;

    public Slider captionSpeedSlider;

    public Slider masterVolumeSlider;
    public Slider bgmVolumeSlider;
    public Slider sfxVolumeSlider;


    private void Awake()
    {
        uiManager = GameObject.Find("UIManager").GetComponent<UIManager>();

        textOptionButton.onClick.AddListener(() => activePanel(0));
        audioOptionButton.onClick.AddListener(() => activePanel(1));

        GetVariables();
        SaveCaptionSpeed();
        captionSpeedSlider.onValueChanged.AddListener(i => SaveCaptionSpeed());
        masterVolumeSlider.onValueChanged.AddListener(i => SaveMasterVolume());
        bgmVolumeSlider.onValueChanged.AddListener(i => SaveBGMVolume());
        sfxVolumeSlider.onValueChanged.AddListener(i => SaveSFXVolume());
    }
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    private void activePanel(int i)
    {
        foreach (GameObject _object in optionPanels) _object.SetActive(false);
        optionPanels[i].SetActive(true);
    }

    private void GetVariables()
    {
        captionSpeedSlider.value = uiManager.captionSpeed;
        masterVolumeSlider.value = uiManager.masterVolume;
        bgmVolumeSlider.value = uiManager.bgmVolume;
        sfxVolumeSlider.value = uiManager.sfxVolume;
    }

    public void SaveCaptionSpeed()
    {
        uiManager.captionSpeed = captionSpeedSlider.value;
    }
    public void SaveMasterVolume()
    {
        uiManager.masterVolume = masterVolumeSlider.value;
    }
    public void SaveBGMVolume()
    {
        uiManager.bgmVolume = bgmVolumeSlider.value;
    }
    public void SaveSFXVolume()
    {
        uiManager.sfxVolume = sfxVolumeSlider.value;
    }
}
