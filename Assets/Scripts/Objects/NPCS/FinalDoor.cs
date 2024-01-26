using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class FinalDoor : NPC
{
    [SerializeField] string _sceneName;



    public override void Init()
    {
        base.Init();
        var startDialogue = new List<string> {
            "It's time to go, James.",
            "Ready?",
            "{FinishGame}"
        };
        dialoguesDictionary["startDialogue"] = startDialogue;
        _dialoguesList = startDialogue;
    }



    public void FinishGame() {
        if(_sceneName == null) return;
        SceneManager.LoadScene(_sceneName);
    }
}
