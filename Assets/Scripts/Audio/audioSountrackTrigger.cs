using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class audioSountrackTrigger : MonoBehaviour
{

    [SerializeField] private AudioManager _audioManager;

    private void OnTriggerEnter2D(Collider2D collider)
    {
        //Debug.Log("audioSountrack: Collision trigger");
        //Debug.Log(collider);

        if (collider.gameObject.name != "Char") { return; }

        _audioManager.TriggerPlaySoundtrack();

    }
}
