using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SaveDataButtonController : MonoBehaviour
{
    private Button button;
    private Canvas canvas;
    public GameObject saveDataPanel;
    private void Awake()
    {
        button = GetComponent<Button>();
        canvas = GameObject.Find("Canvas").GetComponent<Canvas>();
    }
    // Start is called before the first frame update
    void Start()
    {
        button.onClick.AddListener(() => SaveDataButtonAction());
    }

    private void SaveDataButtonAction()
    {
        Instantiate(saveDataPanel, canvas.transform);
    }

}
