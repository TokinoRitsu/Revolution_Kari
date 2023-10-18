using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class unit
{
    public enum unitStatus
    {
        Normal,
        Fainted,
        Poisoned,
        Paralyzed,
        Asleep,
    }
    public string unit_id;
    public int id;
    public unitStatus status;
    public stats Stats, Individual, Effort;
    public int hp_now, mp_now, level, exp, exp_type;
    public List<int> learnt_skills;
    /* exp_type => the exp required to reach a level
     * 0 => 4 * (level ^ 3) / 5
     * 1 => level ^ 3
     * 2 => 5 * (level ^ 3) / 4
     */
    public unit(int _id, int _level, int[] _Individual = null, List<int> _learnt_skills = null)
    {
        unit_id = System.Guid.NewGuid().ToString();
        id = _id;
        level = _level;
        if (_Individual == null)
        {
            _Individual = new int[7];
            for (int i = 0; i < _Individual.Length; i++) _Individual[i] = Random.Range(0, 32);
        }
        Individual = intToStats(_Individual);
        Effort = new stats();
        Stats = statusCalculation(this);
        exp = 0;
        exp_type = Database.exp_types[id];
        hpRecover(this);
        mpRecover(this);
        if (_learnt_skills == null)
        {
            learnt_skills = new List<int>();
            foreach (int[] learnableSkill in Database.learnable_skills[this.id])
            {
                if (level >= learnableSkill[0])
                {
                    learnt_skills.Add(learnableSkill[1]);
                }
            }
        }
        else
        {
            learnt_skills = _learnt_skills;
        }
    }
    public unit(unit _unit, bool isNew)
    {
        unit_id = _unit.unit_id;
        id = _unit.id;
        level = _unit.level;
        Individual = _unit.Individual;
        Effort = _unit.Effort;
        Stats = statusCalculation(this);
        exp = _unit.exp;
        exp_type = Database.exp_types[id];
        if (isNew)
        {
            hpRecover(this);
            mpRecover(this);
            statusRecover(this);
        }
        else
        {
            hp_now = _unit.hp_now;
            mp_now = _unit.mp_now;
            status = _unit.status;
        }
        learnt_skills = _unit.learnt_skills;
    }

    static public stats intToStats(int[] _i)
    {
        return new stats(_i[0], _i[1], _i[2], _i[3], _i[4], _i[5], _i[6]);
    }

    static public int[] statsToInt(stats _s)
    {
        return new int[] { _s.hp, _s.mp, _s.attack, _s.defense, _s.m_attack, _s.m_defense, _s.speed };
    }

    static public stats statusCalculation(unit _unit, stats multiple = null)
    {
        if (multiple == null) multiple = new stats();
        int[] temp_stats_level = statsToInt(multiple);
        float[] temp_multiple = new float[7];
        for (int i = 0; i < 7; i++)
        {
            if (temp_stats_level[i] >= 0) temp_multiple[i] = (2f + (float)temp_stats_level[i]) / 2f;
            else temp_multiple[i] = 2f / (2f - (float)temp_stats_level[i]);
        }

        int[] temp_stats = new int[7];
        int l = _unit.level;
        int[] _b = statsToInt(Database.base_stats[_unit.id]);
        int[] _i = statsToInt(_unit.Individual);
        int[] _e = statsToInt(_unit.Effort);
        int addition = 0;

        for (int i = 0; i < temp_stats.Length; i++)
        {
            if (i == 0) addition = l + 10;
            else addition = 5;
            temp_stats[i] = (int)(Mathf.Floor(Mathf.Floor((_b[i] * 2 + _i[i] + Mathf.Floor(_e[i] / 4)) * l / 100) + addition) * temp_multiple[i]);
        }

        return intToStats(temp_stats);
    }

    static public void hpRecover(unit _unit, int mode = 0, int amount = 0)
    {
        if (mode == 0)
        {
            _unit.hp_now = _unit.Stats.hp;
        }
        else if (mode == 1)
        {
            if (_unit.hp_now == _unit.Stats.hp)
            {

            }
            else if (_unit.hp_now + amount > _unit.Stats.hp)
            {
                _unit.hp_now = _unit.Stats.hp;
            }
            else
            {
                _unit.hp_now += amount;
            }
        }
    }

    static public void mpRecover(unit _unit, int mode = 0, int amount = 0)
    {
        if (mode == 0)
        {
            _unit.mp_now = _unit.Stats.mp;
        }
        else if (mode == 1)
        {
            if (_unit.mp_now == _unit.Stats.mp)
            {

            }
            else if (_unit.mp_now + amount > _unit.Stats.mp)
            {
                _unit.mp_now = _unit.Stats.mp;

            }
            else
            {
                _unit.mp_now += amount;

            }
        }
    }

    static public void statusRecover(unit _unit)
    {
        _unit.status = 0;
    }

}
