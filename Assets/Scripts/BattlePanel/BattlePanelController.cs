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
        for (int i = 0; i < 3; i++)
        {
            if (i < battleManager.tempAllies.Count) InstantiateUnit(i, true);
        }

        for (int i = 0; i < 3; i++)
        {
            if (i < battleManager.enemies.Count) InstantiateUnit(i, false);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void InstantiateUnit(int index, bool isAlly)
    {
        GameObject _object = Instantiate(unitPrefab, transform);
        UnitController unitController = _object.GetComponent<UnitController>();
        if (isAlly) _object.GetComponent<RectTransform>().anchoredPosition = new Vector3(-500, 325 - index * 275f);
        else _object.GetComponent<RectTransform>().anchoredPosition = new Vector3(500, 325 - index * 275f);
        unitController.index = index;
        unitController.isAlly = isAlly;
    }

}
