using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface ISettingsPersistence
{
    void LoadSettings(GameSettings data);
    void SaveSettings(ref GameSettings data);
}
