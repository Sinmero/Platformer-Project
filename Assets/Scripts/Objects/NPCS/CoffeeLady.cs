using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoffeeLady : NPC
{
    public override void Init()
    {
        base.Init();
        var startDialogue = new List<string> {
            "You are Paul's boy aren't you? Helen has been looking for you.",
            "She is upstairs.",
            "To get there use your 'Up Arrow' key to <color=#AAAAAA>activate</color> <color=#009900>green</color> platform.{StartDialogueEnd}"
        };
        dialoguesDictionary["startDialogue"] = startDialogue;
        _dialoguesList = startDialogue;
    }



    public void StartDialogueEnd () {
        var platformController = _interactor._parentGO.GetComponent<PlatformController>();
        platformController._greenPlatform.onGreen += GreenActivated;
    }



    public void GreenActivated () {
        var secondDialogue = new List<string> {
            "<color=#990000>Red</color> platform? It wasn't there last time.",
        };
        dialoguesDictionary.Add("secondDiaogue", secondDialogue);
        _dialoguesList = secondDialogue;


        var platformController = _interactor._parentGO.GetComponent<PlatformController>();
        platformController._greenPlatform.onGreen -= GreenActivated;
    }
}
