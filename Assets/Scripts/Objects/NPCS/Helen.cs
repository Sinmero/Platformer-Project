using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Helen : NPC
{
    [SerializeField] private GameObject _doorGO;


    public override void Init()
    {
        base.Init();
        var startDialogue = new List<string> {
            "James! I'm Helen. Your dad asked me to take care of you for the summer.",
            "We are going to my farm kid! Lots of cool stuff to do there!",
            "Pack your things, we are leaving today.",
            "Go throu the <color=#ffee00>yellow</color> the door to the left when you are ready.",
            "Use youe 'Right Arrow' key for the <color=#1747c2>blue</color> platform.{StartDialogueEnd}"
        };
        dialoguesDictionary["startDialogue"] = startDialogue;
        _dialoguesList = startDialogue;
    }



    public void StartDialogueEnd () {
        _doorGO.SetActive(true);
    }
}