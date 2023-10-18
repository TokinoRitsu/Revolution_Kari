using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AttackPanelController : MonoBehaviour
{
    private Canvas canvas;
    private BattleManager battleManager;

    public int index;

    public GameObject closeButton;
    public GameObject skillButton;
    private void Awake()
    {
        canvas = GameObject.Find("Canvas").GetComponent<Canvas>();
        battleManager = GameObject.FindGameObjectWithTag("BattleManager").GetComponent<BattleManager>();
    }

    // Start is called before the first frame update
    void Start()
    {
        List<int> skillIDs = battleManager.tempUnits[index].unit.learnt_skills;
        int count = skillIDs.Count;
        for (int i = 0; i < count; i++)
        {
            GameObject _skillButton = Instantiate(skillButton, canvas.transform);
            _skillButton.transform.SetParent(transform);
            float xPos = -442.5f + Mathf.Floor(i / 6) * 885;
            float yPos = 400 - (i % 6) * 160;
            _skillButton.GetComponent<RectTransform>().anchoredPosition = new Vector3(xPos, yPos);
            _skillButton.GetComponent<AttackCommandController>().skillID = skillIDs[i];
        }
        GameObject closeButtonObject = Instantiate(closeButton, canvas.transform);
        closeButtonObject.transform.SetParent(transform);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    
}
