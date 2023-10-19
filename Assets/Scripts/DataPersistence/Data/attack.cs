using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class attack
{
    public int skillID;
    public int from;
    public int towards;
    public attack(int _skillID, int _from, int _towards)
    {
        skillID = _skillID;
        from = _from;
        towards = _towards;
    }
}
    
