using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattlePanelController : MonoBehaviour
{
    private BattleManager battleManager;

    public GameObject unitPrefab;
    public GameObject battleManagerPrefab;

    private void Awake()
    {
        battleManager = Instantiate(battleManagerPrefab, transform).GetComponent<BattleManager>();
    }

    // Start is called before the first frame update
    void Start()
    {
        int allyCounter = 0;
        int enemyCounter = 0;
        foreach(BattleManager.tempUnit _tempUnit in battleManager.tempUnits)
        {
            if (_tempUnit.isAlly)
            {
                InstantiateUnit(battleManager.tempUnits.IndexOf(_tempUnit), allyCounter);
                allyCounter++;
            }
            else
            {
                InstantiateUnit(battleManager.tempUnits.IndexOf(_tempUnit), enemyCounter);
                enemyCounter++;
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void InstantiateUnit(int index, int counter)
    {
        GameObject _object = Instantiate(unitPrefab, transform);
        UnitController unitController = _object.GetComponent<UnitController>();
        if (battleManager.tempUnits[index].isAlly) _object.GetComponent<RectTransform>().anchoredPosition = new Vector3(-500, 325 - counter * 275f);
        else _object.GetComponent<RectTransform>().anchoredPosition = new Vector3(500, 325 - counter * 275f);
        unitController.index = index;
        unitController.isAlly = battleManager.tempUnits[index].isAlly;
    }

}
