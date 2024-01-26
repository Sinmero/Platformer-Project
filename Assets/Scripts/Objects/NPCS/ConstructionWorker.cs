using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConstructionWorker : NPC
{
    public override void Init()
    {
        base.Init();
        var startDialogue = new List<string> {
            "See that <color=#990000>red</color> platform, little guy?",
            "We use 'Left Arrow' key to <color=#AAAAAA>activate</color> <color=#990000>red</color> platforms.",
            "Give it a try, kid!{StartDialogueEnd}"
        };
        dialoguesDictionary["startDialogue"] = startDialogue;
        _dialoguesList = startDialogue;

    }



    public void StartDialogueEnd () {
        var platformerController = _interactor._parentGO.GetComponent<PlatformController>();
        platformerController._redPlatform.onRed += RedActivated;
    }



    public void RedActivated () {
        var secondDialogue = new List<string> {
            "Impressive.",
        };
        dialoguesDictionary.Add("secondDialogue", secondDialogue);
        _dialoguesList = secondDialogue;

        var platformerController = _interactor._parentGO.GetComponent<PlatformController>();
        platformerController._redPlatform.onRed -= RedActivated;
    }
}
