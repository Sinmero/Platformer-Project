using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mom : NPC
{
    public override void Init()
    {
        base.Init();
        var startDialogue = new List<string> {
            "I will be stuck at work until late tomorrow.|Pause(1)| What a mess.",
            "Don't forget to brush your teeth and don't stay up late.",
            "There is some pizza in the fridge.{SecondDialogue}"
        };

        dialoguesDictionary["startDialogue"] = startDialogue;
        _dialoguesList = startDialogue;
    }



    public void SecondDialogue() {
        var secondDialogue = new List<string> {
            "Jamie, im a little bit busy right now."
        };
        dialoguesDictionary.Add("secondDialogue", secondDialogue);
        _dialoguesList = secondDialogue;
    }
}
