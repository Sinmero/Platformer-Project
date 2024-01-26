using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dad : NPC
{
    public override void Init()
    {
        base.Init();
        var startDialogue = new List<string>{
            "Hey James. How is school?",
            "Summer break, huh? When I was your age, I was unloading trucks at the train station after school.",
            "Instead of lazing around, how about you look for a summer job?",
            "Go find Helen at the town mall. She owns a farm not far from here and has plenty of work available.",
            "Don't worry - I've already arranged everything.{SecondDialogue}"
        };
        dialoguesDictionary["startDialogue"] = startDialogue;
        _dialoguesList = startDialogue;
    }



    public void SecondDialogue()
    {
        var secondDialogue = new List<string> {
            "Dont be lazy son.",
            "Go find Helen, she is waiting for you at the town mall."
        };
        dialoguesDictionary.Add("secondDialogue", secondDialogue);
        _dialoguesList = secondDialogue;
    }
}
