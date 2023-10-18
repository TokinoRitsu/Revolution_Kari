using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChoosePanelController : MonoBehaviour
{
    private Canvas canvas;
    private BattleManager battleManager;
    public bool isChoosingEnemy;
    public GameObject closeButton;
    public GameObject chooseButton;
    public int skillID;
    public int from;
    private void Awake()
    {
        canvas = GameObject.Find("Canvas").GetComponent<Canvas>();
        battleManager = GameObject.FindGameObjectWithTag("BattleManager").GetComponent<BattleManager>();
    }
    // Start is called before the first frame update
    void Start()
    {
        GameObject closeButtonObject = Instantiate(closeButton, canvas.transform);
        closeButtonObject.GetComponent<RectTransform>().anchoredPosition = new Vector3(160, 360);
        closeButtonObject.transform.SetParent(transform);
        if (isChoosingEnemy)
        {
            for (int i = 0; i < battleManager.enemies.Count; i++)
            {
                GameObject chooseButtonObject = Instantiate(chooseButton, canvas.transform);
                chooseButtonObject.GetComponent<RectTransform>().anchoredPosition = new Vector3(0, 100 - i * 200);
                chooseButtonObject.transform.SetParent(transform);
                ChooseButtonController chooseButtonController = chooseButtonObject.GetComponent<ChooseButtonController>();
                chooseButtonController.index = i;
            }
        }
    }
}
