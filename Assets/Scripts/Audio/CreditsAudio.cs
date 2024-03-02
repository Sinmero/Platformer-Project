using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreditsAudio : MonoBehaviour
{
    [SerializeField] private AudioSource _creditsSong;
    [SerializeField] private GameSettings _gameSettings;

    void Start()
    {
        _creditsSong.volume = _gameSettings._musicVolume;
        _creditsSong.Play();
    }
}
