using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameSettings
{
    public float masterVolume;
    public float bgmVolume;
    public float sfxVolume;
    public float captionSpeed;

    public GameSettings()
    {
        this.captionSpeed = -0.0725f;
        this.masterVolume = 1.0f;
        this.bgmVolume = 1.0f;
        this.sfxVolume = 1.0f;
    }
}
