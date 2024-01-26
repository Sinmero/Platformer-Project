using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialWisp : NPC
{
    [SerializeField] private Trigger _trigger;
    [SerializeField] private GameObject _target;


    public override void Init()
    {
        base.Init();
        List<string> startDialogue = new List<string> {
            "Hello Jamie!",
            "Quite a climb ahead huh?",
            "You can use 'W' key to jump!|Pause(1)| Wait what am i talking! Surely you already knew that.{SecondInteraction}"
        };
        dialoguesDictionary["startDialogue"] = startDialogue;
        _dialoguesList = startDialogue;
    }



    public void SecondInteraction() {
        var secondDialogue = new List<string> {
            "You can do it! I believe in you!"
        };
        dialoguesDictionary.Add("secondDialogue", secondDialogue);
        _dialoguesList = secondDialogue;
        _trigger.trigger += OnTrigger;
    }



    private void OnTrigger() {
        transform.position = _target.transform.position;

        var triggerDialogue  = new List<string> {
        "Welcome to the top!",
        "I knew you had it in you!",
        "Welp, good luck!"};

        dialoguesDictionary.Add("triggerDialogue", triggerDialogue);
        _dialoguesList = triggerDialogue;

        _trigger.gameObject.SetActive(false);
        _target.SetActive(false);
    }
}
