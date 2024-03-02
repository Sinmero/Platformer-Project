using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class SettingsMenu : MonoBehaviour
{
    public GameSettings _gameSettings;
    public Slider 
    _musicSlider,
    _effectsSlider;
    [SerializeField] private GameObject _settingsGO;



    private void Start() {
        _musicSlider.value = _gameSettings._musicVolume;
        _effectsSlider.value = _gameSettings._soundEffectsVolume;
        _settingsGO.SetActive(false);
    }


    private void Update() {
        if(Input.GetKeyDown(Controls.keys._settingsMenu)) {
            _settingsGO.SetActive(!_settingsGO.activeSelf);
        }
    }



    public void ChangeMusicVolume() {
        SoundLogger.instance.Log($"Changed music volume from {_gameSettings._musicVolume} to {_musicSlider.value}", this);
        _gameSettings._musicVolume = _musicSlider.value;
    }



    public void ChangeEffectsVolume () {
        SoundLogger.instance.Log($"Changed effects volume from {_gameSettings._soundEffectsVolume} to {_effectsSlider.value}", this);
        _gameSettings._soundEffectsVolume = _effectsSlider.value;
    }
}
