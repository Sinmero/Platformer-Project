using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialDoor : CheckPoint
{
    public override void Init()
    {
        base.Init();
        List<string> startDialogue = new List<string>{"Leaving so soon? Remeber, you can always come back by pressing 'R'!{StartDialogue}"};
        List<string> secondDialogue = new List<string>{"Back already?|Pause(1)| Take your time, kid."};
        dialoguesDictionary.Add("secondDialogue", secondDialogue);
        dialoguesDictionary["startDialogue"] = startDialogue;
        _dialoguesList = startDialogue;
    }


    public void StartDialogue(){
        _dialoguesList = dialoguesDictionary["secondDialogue"];
    }

}
