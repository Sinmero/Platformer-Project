using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OldMan : NPC
{
    private PlayerController _playerController;



    public override void Init()
    {
        base.Init();
        var startDialogue = new List<string> {
            "What's wrong, young man? You're sulking, on a such beautiful day?",
            "Look at all the nature around you!|Pause(0,5)| Smell that fresh air!",
            "You won't get this in the city.",
            "No, no!|Pause(1)| You are doing it wrong. Take a deep breath and look.",
            "Deep breath...",
            ".|Pause(0,3)|.|Pause(0,3)|.|Pause(0,5)|{AddDoubleJump}", //World gains green color here!
            "Now you understand!",
            "{ChangeName()}<color=#AAAAAA>Double jump ability was unlocked.</color>",
            "{ChangeName()}<color=#AAAAAA>You gain a single double jump charge by landing on a </color><color=#009900>green</color><color=#AAAAAA> platform.</color>",
            "{ChangeName()}</color><color=#AAAAAA>Use 'W' key to double jump. Upon landing on other objects the charge is lost.</color>{SecondDialogue}"
        };

        dialoguesDictionary["startDialogue"] = startDialogue;
        _dialoguesList = startDialogue;
    }



    public override void OnInteract(Interactor interactor)
    {
        base.OnInteract(interactor);
        _playerController = interactor._parentGO.GetComponent<PlayerController>();
    }



    public void AddDoubleJump(){
        var doubleJump = new DoubleJump(_playerController, _playerController._audioClips[2]);
        _playerController._doubleJump = doubleJump;
        AudioManager.instance.TriggerPlaySoundtrack();

        GlobalMaterials.instance.SmoothShaderTransition(GlobalMaterials.instance._greenGlobal, "_ShiftSlider", 1, false , 0.01f);
    }



    public void SecondDialogue() {
        var secondDialogue = new List<string> {
            "{ChangeName(Old man)}Take care kid."
        };
        dialoguesDictionary.Add("secondDialogue", secondDialogue);
        _dialoguesList = secondDialogue;
    }
}
