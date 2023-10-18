using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class stats
{
    public int hp, mp, attack, defense, m_attack, m_defense, speed;
    public stats(int _hp = 0, int _mp = 0, int _attack = 0, int _defense = 0, int _m_attack = 0, int _m_defense = 0, int _speed = 0)
    {
        hp = _hp;
        mp = _mp;
        attack = _attack;
        defense = _defense;
        m_attack = _m_attack;
        m_defense = _m_defense;
        speed = _speed;
    }
}