using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UnitController : MonoBehaviour
{
    public int index;
    public bool isAlly;
    public unit _unit;
    public Text infoText;
    public Text statusText;
    private Manager gameManager;
    private BattleManager battleManager;
    private string unitName;
    private string unitLevel;

    public GameObject hpFill;
    public Text hpText;
    private float hpMax;
    private float hpNow;
    private float hpColor_red;
    private float hpColor_green;
    private float hpRatio;

    public GameObject mpFill;
    public Text mpText;
    private float mpMax;
    private float mpNow;
    private float mpRatio;

    private void Awake()
    {
        gameManager = GameObject.Find("Manager").GetComponent<Manager>();
        battleManager = GameObject.FindGameObjectWithTag("BattleManager").GetComponent<BattleManager>();
    }

    void Start()
    {
        if (!isAlly)
        {
            Vector3 pos = infoText.transform.parent.gameObject.GetComponent<RectTransform>().anchoredPosition;
            infoText.transform.parent.GetComponent<RectTransform>().anchoredPosition = new Vector3(pos.x * -1, pos.y);
            Quaternion angle = infoText.transform.parent.gameObject.GetComponent<RectTransform>().rotation;
            infoText.transform.parent.GetComponent<RectTransform>().rotation = new Quaternion(angle.x, angle.y, angle.z * -1, angle.w);
        }
    }
    void Update()
    {
        _unit = battleManager.tempUnits[index].unit;
        
        if (_unit.id == 1) unitName = gameManager.playerName;
        else unitName = Database.names[_unit.id];
        unitLevel = _unit.level.ToString();
        infoText.text = unitName + " Lv." + unitLevel;

        SetHP();
        SetMP();
        SetStatus();
        CheckNotBelow0();


        if (Input.GetKeyDown(KeyCode.Space))
        {
            _unit.hp_now -= 1;
            _unit.mp_now -= 1;
        }
        if (Input.GetKeyDown(KeyCode.F))
        {
            unit.hpRecover(_unit);
            unit.mpRecover(_unit);
            unit.statusRecover(_unit);
        }
    }

    private void SetHP()
    {
        hpMax = _unit.Stats.hp;
        hpNow = _unit.hp_now;
        hpText.text = hpNow.ToString() + "/" + hpMax.ToString();

        hpRatio = hpNow / hpMax;
        hpFill.transform.parent.GetComponent<RectTransform>().localScale = new Vector3(hpRatio, hpFill.transform.localScale.y);

        if (hpRatio > 0.5)
        {
            hpColor_red = 1.0f - (hpRatio - 0.5f) / 0.5f;
            hpColor_green = 1.0f;
        }
        else if (hpRatio <= 0.5 && hpRatio > 0.2)
        {
            hpColor_red = 1.0f;
            hpColor_green = (hpRatio - 0.2f) / 0.3f;
        }
        else
        {
            hpColor_red = 1.0f;
            hpColor_green = 0f;
        }
        hpFill.GetComponent<Image>().color = new Color(hpColor_red, hpColor_green, 0f, 1.0f);
    }

    private void SetMP()
    {
        mpMax = _unit.Stats.mp;
        mpNow = _unit.mp_now;
        mpText.text = mpNow.ToString() + "/" + mpMax.ToString();

        mpRatio = mpNow / mpMax;

        if (mpRatio >= 0)
        {
            mpFill.GetComponent<Image>().color = new Color(0, 0.75f, 1);
            mpFill.transform.parent.GetComponent<RectTransform>().anchoredPosition = new Vector2(-300, 0);
        }
        else
        {
            mpFill.GetComponent<Image>().color = new Color(0.5f, 0.75f, 1);
            mpFill.transform.parent.GetComponent<RectTransform>().anchoredPosition = new Vector2(300, 0);
        }
        mpFill.transform.parent.GetComponent<RectTransform>().localScale = new Vector2(mpRatio, 1);
    }

    private void SetStatus()
    {
        if (_unit.status == unit.unitStatus.Normal)
        {
            statusText.color = Color.white;
            statusText.text = "";
        }
        else if (_unit.status == unit.unitStatus.Fainted)
        {
            statusText.color = Color.red;
            statusText.text = "きぜつ";
            _unit.hp_now = 0;
        }
        else if (_unit.status == unit.unitStatus.Poisoned)
        {
            statusText.color = Color.magenta;
            statusText.text = "どく";
        }
        else if (_unit.status == unit.unitStatus.Paralyzed)
        {
            statusText.color = Color.yellow;
            statusText.text = "まひ";
        }
        else if (_unit.status == unit.unitStatus.Asleep)
        {
            statusText.color = new Color(0.5f, 0f, 0f, 1f);
            statusText.text = "ねむり";
        }
    }

    private void CheckNotBelow0()
    {
        if (_unit.hp_now <= 0)
        {
            _unit.hp_now = 0;
            _unit.status = unit.unitStatus.Fainted;
        }
        else if (_unit.hp_now > _unit.Stats.hp)
        {
            _unit.hp_now = _unit.Stats.hp;
        }

        if (_unit.mp_now <= _unit.Stats.mp * -1)
        {
            _unit.mp_now = _unit.Stats.mp * -1;
        }
        else if (_unit.mp_now > _unit.Stats.mp)
        {
            _unit.mp_now = _unit.Stats.mp;
        }
    }
}
