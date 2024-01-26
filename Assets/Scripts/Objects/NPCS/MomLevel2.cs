using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MomLevel2 : NPC
{
    public override void Init()
    {
        base.Init();
        var startDialogue = new List<string> {
            "James, come here for a second. I need to speak with you.",
            "Let's take a seat.",
            "Jamie, I want to tell you something important about me and dad.",
            "You see.|Pause(0,3)|.|Pause(0,3)|.|Pause(0,3)| Your father and I|Pause(1)| are going to live apart for a while.",
            "It's nobody's fault. Things are just complicated.",
            "You're all grown up now, and I'm sure you understand - this is for the best.{SecondDialogue}"
        };
        dialoguesDictionary["startDialogue"] = startDialogue;
        _dialoguesList = startDialogue;
    }



    public void SecondDialogue() {
        var secondDialogue = new List<string>{
            "{ChangeName(James)}..."
        };
        dialoguesDictionary.Add("secondDialogue", secondDialogue);
        _dialoguesList = secondDialogue;
    }
}
