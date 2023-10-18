using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class skill
{
    public enum skillClass
    {
        PHYSICAL,
        MAGICAL,
        STATUS
    }
    public enum skillType
    {
        BLUDGEONING,
        PIERCING,
        POISON,
        SLASHING,
        ACID,
        COLD,
        ELECTRIC,
        FIRE,
        FORCE,
        PSYCHIC,
    }


    public enum effect
    {
        FixedDamage,
        RaiseAttack,
        RaiseDefence,
        RaiseMagicAttack,
        RaiseMagicDefense,
        RaiseSpeed,
        LowerAttack,
        LowerDefense,
        LowerMagicAttack,
        LowerMagicDefense,
        LowerSpeed,
        Posion,
        Paralysis,
        HealHP,
        HealMP,
        HealSpecialConditions,
        AlwaysHit,
    }

    public int ID;
    public skillClass Class;
    public string Name;
    public skillType Type;
    public float Cost;
    public float Power;
    public float Accuracy;
    public List<effect> Effect;
    public List<float> Value;
    public List<float> SuccessRate;
    
    public skill(int _ID, skillClass _class, string _name, skillType _type, float _cost, float _power, float _acc, List<effect> _effects, List<float> _effectValue, List<float> _successRate)
    {
        ID = _ID;
        Class = _class;
        Name = _name;
        Type = _type;
        Cost = _cost;
        Power = _power;
        Accuracy = _acc;
        Effect = _effects;
        Value = _effectValue;
        SuccessRate = _successRate;
    }
}
