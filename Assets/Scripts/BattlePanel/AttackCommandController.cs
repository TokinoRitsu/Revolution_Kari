using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AttackCommandController : MonoBehaviour
{
    public int skillID;
    public Text skillName;
    public Text skillInfo;
    public GameObject choosePanel;

    private Button button;
    private BattleManager battleManager;
    private AttackPanelController attackPanelController;
    private Canvas canvas;
    private void Awake()
    {
        button = GetComponent<Button>();
        battleManager = GameObject.FindGameObjectWithTag("BattlePanel").GetComponent<BattleManager>();
        attackPanelController = GameObject.FindGameObjectWithTag("AttackCommandPanel").GetComponent<AttackPanelController>();
        canvas = GameObject.Find("Canvas").GetComponent<Canvas>();
    }
    private void Start()
    {
        skill _skill = Database.skill_data[skillID];
        skillName.text = _skill.Name;
        skillInfo.text = "コスト" + _skill.Cost + " いりょく" + _skill.Power;
        button.onClick.AddListener(() => attackAction());
    }
    public void attackAction()
    {
        GameObject choosePanelObject = Instantiate(choosePanel, canvas.transform);
        choosePanelObject.transform.SetParent(attackPanelController.gameObject.transform);
        ChoosePanelController choosePanelController = choosePanelObject.GetComponent<ChoosePanelController>();
        choosePanelController.skillID = skillID;
        choosePanelController.from = attackPanelController.index;
        choosePanelController.isChoosingEnemy = true;
    }

    
}
