using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class BattleManager : MonoBehaviour
{
    public enum State
    {
        Encounter,
        WaitForAction,
        Processing,
        End
    }
    public class tempUnit
    {
        public bool isAlly;
        public unit unit;
        public stats statsLevel;
        public stats tempStats;
        public bool isFlinched;
        public bool isConfused;
        public int confuseTurn;
        public tempUnit(bool _isAlly, unit _unit)
        {
            isAlly = _isAlly;
            unit = _unit;
            statsLevel = new stats();
            tempStats = new stats();
            isFlinched = false;
            isConfused = false;
            confuseTurn = 0;
        }
    }

    public State state;

    private Manager gameManager;

    private BattleCaptionController battleCaption;
    private Canvas canvas;

    public GameObject battleCommandPanel;
    public GameObject battleCaptionPanel;
    public GameObject backButton;

    public List<tempUnit> tempUnits;

    public List<attack> actions;

    private bool nextStep = false;
    public bool finishedChoosing;
    public int counter;
    public int round;

    private void Awake()
    {
        gameManager = GameObject.Find("Manager").GetComponent<Manager>();
        canvas = GameObject.Find("Canvas").GetComponent<Canvas>();
        tempUnits = new List<tempUnit>();
        actions = new List<attack>();
        finishedChoosing = false;
        counter = 0;
        round = 1;
    }

    // Start is called before the first frame update
    void Start()
    {
        calculateAllUnitStats();
        battleCaption = Instantiate(battleCaptionPanel, transform.parent).GetComponent<BattleCaptionController>();
        state = State.Encounter;
        StartCoroutine(TurnOperator());
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.J))
        {
            calculateAllUnitStats();
        }
        else if (Input.GetKeyDown(KeyCode.K))
        {
            StartCoroutine(OnEncounter());
        }
    }

    public void arrangeActionOrder()
    {
        Dictionary<float, attack> speedActionPairs = new Dictionary<float, attack>();
        foreach(attack _attack in actions) speedActionPairs.Add(tempUnits[_attack.from].tempStats.speed, _attack);
        var sortedPairs = speedActionPairs.OrderByDescending(pair => pair.Key);
        actions.Clear();
        foreach (var pair in sortedPairs) actions.Add(pair.Value);
    }

    public void calculateAllUnitStats()
    {
        for (int i = 0; i < tempUnits.Count; i++) tempUnits[i].tempStats = unit.statusCalculation(tempUnits[i].unit, tempUnits[i].statsLevel);
    }

    public GameObject InstantiateCommandPanel(int index)
    {
        GameObject commandPanel = Instantiate(battleCommandPanel, transform);
        commandPanel.transform.SetParent(canvas.transform);
        commandPanel.GetComponent<BattleCommandController>().index = index;
        return commandPanel;
    }



    private void UpdateAllyUnits()
    {
        foreach (tempUnit _tempUnit in tempUnits)
        {
            if (_tempUnit.isAlly)
            {
                for (int i = 0; i < gameManager.allies.Count; i++)
                {
                    if (_tempUnit.unit.unit_id == gameManager.allies[i].unit_id)
                    {
                        gameManager.allies[i] = new unit(_tempUnit.unit, false);
                    }
                }
            }
        }
    }

    private void OnDestroy()
    {
        gameManager.mode = 0;
        UpdateAllyUnits();
    }

    private IEnumerator TurnOperator()
    {
        if (state == State.Encounter)
        {
            StartCoroutine(OnEncounter());
            yield return new WaitUntil(() => nextStep);
            state = State.WaitForAction;
        }
        while (state != State.End)
        {
            Debug.Log(state);
            if (state == State.WaitForAction)
            {
                nextStep = false;
                StartCoroutine(OnWaitingForAction());
                yield return new WaitUntil(() => nextStep);
                state = State.Processing;
            }
            else if (state == State.Processing)
            {
                nextStep = false;
                StartCoroutine(OnProcessing());
                yield return new WaitUntil(() => nextStep);
                actions = new List<attack>();
                round++;
            }
        }

        if (state == State.End)
        {
            nextStep = false;
            Destroy(transform.parent);
        }
        yield return null;
    }

    private IEnumerator OnEncounter()
    {
        List<string> namesOfEnemies = new List<string>();
        foreach (tempUnit _tempUnit in tempUnits) if (!_tempUnit.isAlly) namesOfEnemies.Add(Database.names[_tempUnit.unit.id]);

        string line = String.Join("と", namesOfEnemies);
        battleCaption.playLine(line + "があらわれた！");
        yield return new WaitUntil(() => battleCaption.isNextLine);
        battleCaption.isNextLine = false;

        nextStep = true;
        yield return null;
    }

    private IEnumerator OnWaitingForAction()
    {
        counter = 0;
        while (counter < tempUnits.Count)
        {
            if (tempUnits[counter].isAlly)
            {
                string name = "";
                if (tempUnits[counter].unit.id == 1) name = gameManager.playerName;
                else name = Database.names[tempUnits[counter].unit.id];
                battleCaption.playLine(name + "はなにをする？");
                yield return new WaitUntil(() => battleCaption.isNextLine);
                battleCaption.isNextLine = false;

                GameObject commandPanel = InstantiateCommandPanel(tempUnits.IndexOf(tempUnits[counter]));
                BattleCommandController commandControl = commandPanel.GetComponent<BattleCommandController>();
                if (counter > 0)
                {
                    GameObject backButtonObject = Instantiate(backButton, canvas.transform);
                    backButtonObject.transform.SetParent(commandPanel.transform);
                }
                yield return new WaitUntil(() => finishedChoosing);
                finishedChoosing = false;
            }
            else
            {
                int skillIndex = UnityEngine.Random.Range(0, tempUnits[counter].unit.learnt_skills.Count);
                int _towards = 0;
                if (Database.skill_data[tempUnits[counter].unit.learnt_skills[skillIndex]].Class == skill.skillClass.STATUS)
                {
                    _towards = getRandomIndex(false);
                }
                else
                {
                    _towards = getRandomIndex(true);
                }
                actions.Add(new attack(tempUnits[counter].unit.learnt_skills[skillIndex], tempUnits.IndexOf(tempUnits[counter]), _towards));
            }
            counter++;
        }
        nextStep = true;
        yield return null;
    }

    private int getRandomIndex(bool isAlly)
    {
        List<int> indexes = new List<int>();
        for (int i = 0; i < tempUnits.Count; i++)
        {
            if ((isAlly && tempUnits[i].isAlly) || (!isAlly && !tempUnits[i].isAlly))
            {
                indexes.Add(i);
            }
        }
        return indexes[UnityEngine.Random.Range(0, indexes.Count)];
    }



    private IEnumerator OnProcessing()
    {
        while (actions.Count > 0)
        {
            arrangeActionOrder();

            attack _attack = actions[0];
            unit _attacker = null;
            unit _defender = null;
            string line = "";
            string attackerName = "";
            string defenderName = "";

            line = "";
            float damage = 0f;
            float level = 0f;
            float attackStat = 0f;
            float defenseStat = 0f;
            skill _skill = Database.skill_data[_attack.skillID];
            skill.skillClass _skillClass = _skill.Class;
            skill.skillType _skillType = _skill.Type;
            float skillPower = _skill.Power;
            float skillAcc = _skill.Accuracy;
            float skillCost = _skill.Cost;
            List<float> skillEffectSuccessRate = _skill.SuccessRate;
            List<skill.effect> effects = _skill.Effect;
            List<float> skillEffectValues = _skill.Value;
            float multiple = 1;
            bool hit = false;


            _attacker = tempUnits[_attack.from].unit;
            _defender = tempUnits[_attack.towards].unit;

            string skillName = Database.skill_data[_attack.skillID].Name;

            if (_attacker.id == 1) attackerName = gameManager.playerName;
            else attackerName = Database.names[_attacker.id];

            if (_defender.id == 1) defenderName = gameManager.playerName;
            else defenderName = Database.names[_defender.id];

            _attacker.mp_now -= (int)skillCost;

            line = attackerName + " の " + skillName + "!";

            battleCaption.playLine(line);
            yield return new WaitUntil(() => battleCaption.isNextLine);
            battleCaption.isNextLine = false;

            if (effects.Contains(skill.effect.AlwaysHit)) hit = true;
            else if (UnityEngine.Random.Range(0, 100) < skillAcc) hit = true;

            if (hit)
            {
                if (skillPower > 0)
                {
                    level = _attacker.level;
                    if (_skillClass == skill.skillClass.PHYSICAL)
                    {
                        attackStat = _attacker.Stats.attack;
                        defenseStat = _defender.Stats.defense;
                    }
                    else
                    {
                        attackStat = _attacker.Stats.m_attack;
                        defenseStat = _defender.Stats.m_defense;
                    }
                    List<skill.skillType> weaknesses = Database.weakTypes[_defender.id];
                    List<skill.skillType> resistances = Database.resistanceTypes[_defender.id];
                    if (weaknesses.Contains(_skillType)) multiple *= 2;
                    else if (resistances.Contains(_skillType)) multiple *= 0.5f;
                    damage = Mathf.Floor(Mathf.Floor((Mathf.Floor(Mathf.Floor(Mathf.Floor(level * 2 / 5 + 2) * skillPower * attackStat / defenseStat) / 50 + 2) * UnityEngine.Random.Range(218, 257) / 256)) * multiple);
                    _defender.hp_now -= (int)damage;

                    line = defenderName + "が" + damage + "のダメージをうけた！";
                    if (multiple > 1) line += "\nこうかばつぐん！";
                    else if (multiple < 1) line += "\nこうかはいまひとつのようだ…";
                }
                else
                {

                }

                battleCaption.isNextLine = false;
                battleCaption.playLine(line);
                yield return new WaitUntil(() => battleCaption.isNextLine);
                battleCaption.isNextLine = false;

                if (effects.Count > 0) foreach (skill.effect _effect in effects) { }
            }
            else
            {
                line = "でも当たらなかった！";
                battleCaption.isNextLine = false;
                battleCaption.playLine(line);
                yield return new WaitUntil(() => battleCaption.isNextLine);
                battleCaption.isNextLine = false;
            }
            actions.Remove(actions[0]);

            if (_defender.hp_now == 0)
            {
                line = defenderName + "がきぜつした！";
                battleCaption.isNextLine = false;
                battleCaption.playLine(line);
                yield return new WaitUntil(() => battleCaption.isNextLine);
                battleCaption.isNextLine = false;
                // きぜつ処理
                
            }


        }
        nextStep = true;
        state = State.WaitForAction;
        yield return null;
    }

    public int getEnemyCount()
    {
        int count = 0;
        foreach (tempUnit _tempUnit in tempUnits) if (!_tempUnit.isAlly) count++;
        return count;
    }

}
