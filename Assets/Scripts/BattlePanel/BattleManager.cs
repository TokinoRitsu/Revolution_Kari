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
        WaitForOpponent,
        Processing,
        End
    }
    public State state;

    private Manager gameManager;

    private BattleCaptionController battleCaption;
    private Canvas canvas;

    public GameObject battleCommandPanel;
    public GameObject battleCaptionPanel;
    public GameObject backButton;

    public List<unit> tempAllies;
    public List<stats> allyStatsLevel;
    public List<stats> allyTemporaryStats;
    public List<unit> enemies;
    public List<stats> enemyStatsLevel;
    public List<stats> enemyTemporaryStats;

    public List<attack> actions;

    private bool nextStep = false;
    public bool finishedChoosing;
    public int counter;
    public int round;

    private void Awake()
    {
        gameManager = GameObject.Find("Manager").GetComponent<Manager>();
        canvas = GameObject.Find("Canvas").GetComponent<Canvas>();
        allyStatsLevel = new List<stats>();
        allyTemporaryStats = new List<stats>();
        enemyStatsLevel = new List<stats>();
        enemyTemporaryStats = new List<stats>();
        actions = new List<attack>();
        finishedChoosing = false;
        counter = 0;
        round = 1;
    }

    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < tempAllies.Count; i++)
        {
            if (i < 3)
            {
                allyStatsLevel.Add(new stats());
                allyTemporaryStats.Add(new stats());
            }
        }
        for (int i = 0; i < enemies.Count; i++)
        {
            if (i < 3)
            {
                enemyStatsLevel.Add(new stats());
                enemyTemporaryStats.Add(new stats());
            }
        }
        calculateAllUnitStats();
        battleCaption = Instantiate(battleCaptionPanel, transform.parent).GetComponent<BattleCaptionController>();
        state = State.Encounter;
        StartCoroutine(TurnOperator());
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.O))
        {
            allyStatsLevel[0].attack += 1;
        }
        else if (Input.GetKeyDown(KeyCode.P))
        {
            allyStatsLevel[0].attack -= 1;
        }
        else if (Input.GetKeyDown(KeyCode.J))
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
        List<stats> battleStats = new List<stats>();
        List<float> speedList = new List<float>();
        List<float> arrangedSpeedList = new List<float>();
        foreach (stats i in allyTemporaryStats) battleStats.Add(i);
        foreach (stats i in enemyTemporaryStats) battleStats.Add(i);
        foreach (stats i in battleStats) speedList.Add(i.speed);
        while (speedList.Count > 0)
        {
            int a = speedList.IndexOf(speedList.Max());
            arrangedSpeedList.Add(speedList[a]);
            Debug.Log(speedList[a]);
            speedList.Remove(speedList[a]);
        }
        
    }

    public void calculateAllUnitStats()
    {
        for (int i = 0; i < tempAllies.Count; i++) if (i < 3) allyTemporaryStats[i] = unit.statusCalculation(tempAllies[i], allyStatsLevel[i]);
        for (int i = 0; i < enemies.Count; i++) if (i < 3) enemyTemporaryStats[i] = unit.statusCalculation(enemies[i], enemyStatsLevel[i]);
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
        foreach (unit tempAlly in tempAllies)
        {
            for (int i = 0; i < gameManager.allies.Count; i++)
            {
                if (tempAlly.unit_id == gameManager.allies[i].unit_id)
                {
                    gameManager.allies[i] = new unit(tempAlly, false);
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
                state = State.WaitForOpponent;
            }
            else if (state == State.WaitForOpponent)
            {
                nextStep = false;
                StartCoroutine(OnWaitingForOpponent());
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
        foreach (unit _unit in enemies) namesOfEnemies.Add(Database.names[_unit.id]);

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
        int numberOfAllies = tempAllies.Count;
        while ((counter < numberOfAllies) && (counter < 3))
        {
            string name = "";
            if (tempAllies[counter].id == 1) name = gameManager.playerName;
            else name = Database.names[tempAllies[counter].id];
            battleCaption.playLine(name + "はなにをする？");
            yield return new WaitUntil(() => battleCaption.isNextLine);
            battleCaption.isNextLine = false;

            GameObject commandPanel = InstantiateCommandPanel(counter);
            BattleCommandController commandControl = commandPanel.GetComponent<BattleCommandController>();
            if (counter > 0)
            {
                GameObject backButtonObject = Instantiate(backButton, canvas.transform);
                backButtonObject.transform.SetParent(commandPanel.transform);
            }
            yield return new WaitUntil(() => finishedChoosing);
            finishedChoosing = false;
            counter++;
        }
        nextStep = true;
        yield return null;
    }

    private IEnumerator OnWaitingForOpponent()
    {
        foreach (unit _unit in enemies)
        {
            int skillIndex = UnityEngine.Random.Range(0, _unit.learnt_skills.Count);
            bool _isTowardsAlly = true;
            int _towards = 0;
            if (Database.skill_data[_unit.learnt_skills[skillIndex]].Class == skill.skillClass.STATUS)
            {
                _isTowardsAlly = false;
                _towards = UnityEngine.Random.Range(0, enemies.Count);
            }
            else
            {
                _isTowardsAlly = true;
                _towards = UnityEngine.Random.Range(0, tempAllies.Count);
            }
            actions.Add(new attack(false, _isTowardsAlly, _unit.learnt_skills[skillIndex], enemies.IndexOf(_unit), _towards));
        }
        yield return new WaitForEndOfFrame();
        yield return new WaitForEndOfFrame();
        battleCaption.isNextLine = false;

        nextStep = true;
        yield return null;
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


            if (_attack.isFromAlly) _attacker = tempAllies[_attack.from];
            else _attacker = enemies[_attack.from];
            if (_attack.isTowardsAlly) _defender = tempAllies[_attack.towards];
            else _defender = enemies[_attack.towards];

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
        }
        nextStep = true;
        state = State.WaitForAction;
        yield return null;
    }

}
