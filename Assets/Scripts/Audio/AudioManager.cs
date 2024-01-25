using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager instance;

    [SerializeField] private AudioSource soundObject;
    [SerializeField] private AudioSource levelAmbience;
    [SerializeField] float AmbienceFadeOffsetX;
    [SerializeField] private AudioSource levelSoundtrack;
    [SerializeField] private BoxCollider2D collider_triggerAmbienceFade;
    [SerializeField] private BoxCollider2D collider_triggerSoundtrack;

    //trigger related
    private float levelAmbience_initVolume;
    private GameObject CharacterRef;
    private Vector3 AmbienceTriggerEventLocation;
    private bool IsAmbienceFading = false;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            levelAmbience_initVolume = levelAmbience.volume;
        }
    }

    private void Update()
    {
        if (!IsAmbienceFading) { return; }

        float AbsOffset = AmbienceTriggerEventLocation.x + AmbienceFadeOffsetX;
        float newVolume = Mathf.InverseLerp(AbsOffset, AmbienceTriggerEventLocation.x, CharacterRef.transform.position.x);
        levelAmbience.volume = Mathf.Lerp(0.0f, levelAmbience_initVolume, newVolume);

        if (newVolume <= 0) {
            IsAmbienceFading = false;
            levelAmbience.Stop();
        }
        
    }

    public void PlaySoundClip(AudioClip audioClip, float volume = 1.0f)
    {
        SoundLogger.instance.Log(audioClip, this);
        if (audioClip != null)
        {
            AudioSource audioSource = Instantiate(soundObject);
            audioSource.clip = audioClip;
            audioSource.volume = volume;
            audioSource.Play();

            float clipLength = audioSource.clip.length;
            Destroy(audioSource.gameObject, clipLength);
        }
        
    }

    public void TriggerAmbienceFalloff(GameObject character)
    {
        //Debug.Log("AudioManager: Ambience falloff triggered");

        if (!levelAmbience.isPlaying) { return; }

        CharacterRef = character;
        AmbienceTriggerEventLocation = character.transform.position;
        IsAmbienceFading = true;
    }

    public void TriggerPlaySoundtrack()
    {
        //Debug.Log("AudioManager: PlaySountrack triggered");

        if (levelSoundtrack.isPlaying) { return; }
        levelSoundtrack.Play();
    }

}
