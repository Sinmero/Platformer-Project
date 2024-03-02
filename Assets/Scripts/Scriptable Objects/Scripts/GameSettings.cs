using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.SceneManagement;


[CreateAssetMenu(fileName = "GameSettings", menuName = "ScriptableObjects/GameSettings")]
public class GameSettings : ScriptableObject
{
    [SerializeField] private float 
    musicVolume,
    effectsVolume;

    public float _musicVolume {set{musicVolume = value; OnMusicVolumeChange?.Invoke();} get{return musicVolume;}}
    public float _soundEffectsVolume {set{effectsVolume = value; OnSoundEffectChange?.Invoke();} get{return effectsVolume;}}
    public Action 
    OnMusicVolumeChange,
    OnSoundEffectChange;
}
