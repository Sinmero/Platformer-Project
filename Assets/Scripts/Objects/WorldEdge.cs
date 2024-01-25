using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorldEdge : MonoBehaviour
{
    [SerializeField] private Transform _onCollisionTeleport;

    private void OnCollisionEnter2D(Collision2D other) {
        var playerController = other.gameObject.GetComponent<PlayerController>();
        if(playerController == null) return;
        other.gameObject.transform.position = _onCollisionTeleport.position;
        PhysicsLogger.instance.Log($"{other.gameObject.name} collided with world edge", this);
    }
}
