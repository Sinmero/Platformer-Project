using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChanger : Interactable
{
    [SerializeField] private string _sceneName;



    public override void OnInteract(Interactor interactor)
    {
        base.OnInteract(interactor);
        if(_sceneName == null) return;
        SceneManager.LoadScene(_sceneName);
    }
}
