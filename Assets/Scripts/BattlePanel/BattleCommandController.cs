using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BattleCommandController : MonoBehaviour
{
    public int index;
    public int towards;
    public int skillID;

    private Canvas canvas;
    private BattleManager battleManager;

    public Button attackButton;
    public Button itemButton;
    public Button switchButton;
    public Button fleeButton;

    public GameObject attackCommandPanel;

    public enum commandType
    {
        Null,
        Attack,
        Item,
        Switch,
        Flee
    }

    void Awake()
    {
        canvas = GameObject.Find("Canvas").GetComponent<Canvas>();
        battleManager = GameObject.FindGameObjectWithTag("BattleManager").GetComponent<BattleManager>();
    }

    // Start is called before the first frame update
    void Start()
    {
        attackButton.onClick.AddListener(OnAttack);
        itemButton.onClick.AddListener(OnItem);
        switchButton.onClick.AddListener(OnSwitch);
        fleeButton.onClick.AddListener(OnFlee);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    

    public void OnAttack()
    {
        GameObject commandPanel = Instantiate(attackCommandPanel, canvas.transform);
        commandPanel.transform.SetParent(GameObject.FindGameObjectWithTag("BattleCommandPanel").transform);
        commandPanel.GetComponent<AttackPanelController>().index = index;
    }
    public void OnItem()
    {
        
    }
    public void OnSwitch()
    {
        
    }
    public void OnFlee()
    {

    }



    
}
