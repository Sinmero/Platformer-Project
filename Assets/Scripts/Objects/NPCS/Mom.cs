using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mom : NPC
{
    public override void Init()
    {
        base.Init();
        var startDialogue = new List<string> {
            "I'll be stuck at work until late tomorrow.|Pause(0,5)| What a mess.",
            "Don't forget to brush your teeth and don't stay up late.",
            "There's pizza in the fridge.{SecondDialogue}"
        };

        dialoguesDictionary["startDialogue"] = startDialogue;
        _dialoguesList = startDialogue;
    }



    public void SecondDialogue() {
        var secondDialogue = new List<string> {
            "Jamie, I'm a little bit busy right now."
        };
        dialoguesDictionary.Add("secondDialogue", secondDialogue);
        _dialoguesList = secondDialogue;
    }
}
