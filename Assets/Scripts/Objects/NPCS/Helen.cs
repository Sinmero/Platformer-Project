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
            "James! I've been waiting for you. Your dad asked me to take care of you for the summer.",
            "We're going to the farm, kid! Lots of cool stuff to do there!",
            "Pack your things - we leave today.",
            "Go through the <color=#ffee00>yellow</color> door to the left when you are ready.",
            "Use your 'Right Arrow' key for the <color=#1747c2>blue</color> platform.{SecondDialogue}"
        };
        dialoguesDictionary["startDialogue"] = startDialogue;
        _dialoguesList = startDialogue;
    }



    public void SecondDialogue () {
        _doorGO.SetActive(true);
        var secondDialogue = new List<string> {
            "Go through the <color=#ffee00>yellow</color> door to the left when you are ready.",
            "Use your 'Right Arrow' key for the <color=#1747c2>blue</color> platform."
        };
        dialoguesDictionary.Add("secondDialogue", secondDialogue);
        _dialoguesList = secondDialogue;
    }
}
