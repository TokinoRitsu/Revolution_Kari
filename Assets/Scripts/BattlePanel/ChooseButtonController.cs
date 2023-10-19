using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChooseButtonController : MonoBehaviour
{
    private Manager gameManager;
    private BattleManager battleManager;
    private ChoosePanelController choosePanelController;
    private GameObject battleCommandPanel;
    private unit _unit;
    private Button button;

    public bool isChoosingEnemy;
    public int index;

    public Text nameText;
    public Text infoText;
    private void Awake()
    {
        gameManager = GameObject.FindGameObjectWithTag("Manager").GetComponent<Manager>();
        battleManager = GameObject.FindGameObjectWithTag("BattleManager").GetComponent<BattleManager>();
        choosePanelController = GameObject.FindGameObjectWithTag("ChoosePanel").GetComponent<ChoosePanelController>();
        battleCommandPanel = GameObject.FindGameObjectWithTag("BattleCommandPanel");

        button = GetComponent<Button>();
        isChoosingEnemy = choosePanelController.isChoosingEnemy;
    }
    void Start()
    {
        _unit = battleManager.tempUnits[index].unit;
        if (_unit.id == 1) nameText.text = gameManager.playerName;
        else nameText.text = Database.names[_unit.id];
        infoText.text = "Lv." + _unit.level;

        button.onClick.AddListener(() => chooseButtonAction());
    }

    public void chooseButtonAction()
    {
        if (isChoosingEnemy)
        {
            battleManager.actions.Add(new attack(choosePanelController.skillID, choosePanelController.from, index));
            battleManager.finishedChoosing = true;
            Destroy(battleCommandPanel.gameObject);
        }
    }
}
