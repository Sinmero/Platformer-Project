using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneChanger : Interactable
{
    [SerializeField] private string _sceneName;



    public override void OnInteract(Interactor interactor)
    {
        base.OnInteract(interactor);
        if(_sceneName == null) return;
        GameSystems.instance.ChangeScene(_sceneName);
    }
}
