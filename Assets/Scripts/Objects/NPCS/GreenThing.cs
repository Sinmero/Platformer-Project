using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GreenThing : NPC
{
    [SerializeField] private Transform 
    _pos1,
    _pos2;
    [SerializeField] private GameObject
    _gnome1,
    _gnome2;



    public override void Init()
    {
        base.Init();
        var startDialogue = new List<string> {
            "Don't do through the <color=#ffee00>yellow</color> door James.",
            "It will take you places you don't want to go.",
            "{SecondDialogue}"
        };
        dialoguesDictionary["startDialogue"] = startDialogue;
        _dialoguesList = startDialogue;
    }



    public void SecondDialogue() {
        var secondDialogue = new List<string> {
            "You will be better off here.",
            "Trust me James.",
            "{ThirdDialogue}"
        };
        _gnome1.SetActive(false);
        transform.position = _pos1.position;
        dialoguesDictionary.Add("secondDialogue", secondDialogue);
        _dialoguesList = secondDialogue;
    }



    public void ThirdDialogue() {
        var thirdDialogue = new List<string> {
            "<color=#009900>Last chance James.</color>",
            "<color=#009900>Don't say i didn't warn you.</color>",
            "{RemoveGreen}"
        };
        ChangeName("<color=#009900>Green</color>");
        _gnome2.SetActive(false);
        transform.position = _pos2.position;
        dialoguesDictionary.Add("thirdDiaogue", thirdDialogue);
        _dialoguesList = thirdDialogue;
    }



    public void RemoveGreen(){
        gameObject.SetActive(false);
    }
}
