using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HelenDivorce : NPC
{
    PlayerController _playerController;


    public override void Init()
    {
        base.Init();
        var startDialogue = new List<string> {
            "What's the matter?|Pause(0,5)| You've been quiet.",
            "I know you're used to the city life, but there's plenty of fun stuff to do here too!",
            "I know! We can go to the lake tomorrow. The water... |Pause(0,5)| ..Oh.",
            "So your parents... |Pause(0,3)|You poor guy.",
            "Do you want to talk about it?|Pause(0,5)| You'll feel better if you talk to someone.",
            "Just don't bottle it all up, ok?",
            ".|Pause(0,5)|.|Pause(0,5)|.{AddDash}", //world gains red color here
            "Everything's going to be okay, kid.",
            "{ChangeName()}<color=#AAAAAA>Dash ability was unlocked.</color>",
            "<color=#AAAAAA>You gain a single dash charge when landing on a </color><color=#990000>red</color> <color=#AAAAAA>platform.</color>",
            "<color=#AAAAAA>Use 'Space' key to dash while in mid air. Upon landing on other objects the charge is lost.</color>{SecondDialogue}"
        };

        dialoguesDictionary["startDialogue"] = startDialogue;
        _dialoguesList = startDialogue;
    }



    public override void OnInteract(Interactor interactor)
    {
        base.OnInteract(interactor);
        _playerController = interactor._parentGO.GetComponent<PlayerController>();
    }



    public void AddDash () {
        var dashing = new Dashing(_playerController, _playerController._audioClips[0]);
        _playerController._dashing = dashing;

        GlobalMaterials.instance.SmoothShaderTransition(GlobalMaterials.instance._redGlobal, "_ShiftSlider", 1, false , 0.01f);
    }



    public void SecondDialogue(){
        var secondDialogue = new List<string> {
            "{ChangeName(Helen)}Everything's going to be okay, kid."
        };
        dialoguesDictionary.Add("secondDialogue", secondDialogue);
        _dialoguesList = secondDialogue;
    }
}
