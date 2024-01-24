using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class audioAmbienceTrigger : MonoBehaviour
{

    [SerializeField] private AudioManager _audioManager;

    private void OnTriggerEnter2D(Collider2D collider)
    {
        //Debug.Log("Ambience: Collision trigger");
        //Debug.Log(collider.gameObject.name);

        if (collider.gameObject.name != "Char") { return; }

        _audioManager.TriggerAmbienceFalloff(collider.gameObject);

    }
}
