using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class attack
{
    public bool isFromAlly;
    public bool isTowardsAlly;
    public int skillID;
    public int from;
    public int towards;
    public attack(bool _isFromAlly, bool _isTowardsAlly, int _skillID, int _from, int _towards)
    {
        isFromAlly = _isFromAlly;
        isTowardsAlly = _isTowardsAlly;
        skillID = _skillID;
        from = _from;
        towards = _towards;
    }
}
    
