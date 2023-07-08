using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FMOD;
using FMODUnity;
using UnityEngine.Events;
using System;

public class AudioManager : Game.GameSystem.Singleton.Singleton<AudioManager>
{
    public Action OnDoorOpen;
    public void OnDoorOpenSound()
    {
        OnDoorOpen?.Invoke();
    }
}
