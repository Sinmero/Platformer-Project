using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HelenSky : NPC
{
    private PlayerController _playerController;


    public override void Init()
    {
        base.Init();
        var startDialogue = new List<string> {
            "There you are.|Pause(0,5)| Come, have a sit.",
            "Time flies damn quickly when you get older.|Pause(0,5)| Summer goes by in a blink of an eye.",
            "Don't worry you have plenty of time before that happens.",
            ".|Pause(0,3)|.|Pause(0,3)|.",
            "Ready for the new school year?",
            "Your dad called me this morning. He told me that he will pick you up in two days so you better get your things packed and ready.",
            "Take your time to enjoy the stars while you are here. You can't see them very well in the city.",
            ".|Pause(0,5)|.|Pause(0,5)|.{AddLowGrav}", //world gains blue color here
            "{ChangeName()}<color=#AAAAAA>Low gravity ability was unlocked.</color>",
            "<color=#AAAAAA>You gain low gravity when standing on a </color><color=#1747c2>blue</color> <color=#AAAAAA>platform.</color>",
            "<color=#AAAAAA>Use Low gravity is lost upon landing on other objects.</color>{SecondDialogue}"
        };
        dialoguesDictionary["startDialogue"] = startDialogue;
        _dialoguesList = startDialogue;
    }



    public override void OnInteract(Interactor interactor)
    {
        base.OnInteract(interactor);
        _playerController = interactor._parentGO.GetComponent<PlayerController>();
    }



    public void AddLowGrav() {
        var lowGrav = new LowGravity(_playerController, null, null, _playerController._audioClips[4]);
        _playerController._lowGravity = lowGrav;

        GlobalMaterials.instance.SmoothShaderTransition(GlobalMaterials.instance._blueGlobal, "_ShiftSlider", 1, false , 0.01f);
        GlobalMaterials.instance.SmoothShaderTransition(GlobalMaterials.instance._water, "_ShiftSlider", 1, false , 0.01f);
    }



    public void SecondDialogue() {
        var secondDialogue = new List<string> {
            "{ChangeName(Helen)}Take your time."
        };
        dialoguesDictionary.Add("secondDialogue", secondDialogue);
        _dialoguesList = secondDialogue;
    }
}
