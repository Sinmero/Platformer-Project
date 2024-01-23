using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckPoint : NPC
{
    public override void OnInteract(Interactor interactor)
    {
        base.OnInteract(interactor);
        PlayerController playerController = interactor._parentGO.GetComponent<PlayerController>();
        GameplayLogger.instance.Log($"{playerController.name} interated with {transform.name} at {transform.position}", this);
        if(playerController._checkpointReturning == null) playerController._checkpointReturning = new CheckpointReturning(playerController);
        playerController._checkpointReturning._lastCheckpointPosition = transform.position;
    }
}
