using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(BoxCollider2D))]
public class Interactable : MonoBehaviour
{
    public string _interactableName = "Generic Name";
    public string _actionName = "interact with";
    [HideInInspector] public string _interactKey;
    private BoxCollider2D _boxCollider2D;


    void Start()
    {
        Init();
    }



    public virtual void Interact(Interactor interactor)
    {
        if (Input.GetKeyDown(Controls.keys._interact))
        {
            GameplayLogger.instance.Log($"{interactor._parentGO.name} interacted with {_interactableName}", this);
            interactor._midScreenText.text = "";
            OnInteract(interactor);
        }
    }



    public virtual void OnInteract(Interactor interactor) { }



    public virtual void OnEnter(Interactor interactor)
    {
        interactor._midScreenText.text = GetPopupMessage();
        PhysicsLogger.instance.Log($"{name} trigger enter", this);
    }



    public virtual void OnLeave(Interactor interactor)
    {
        interactor._interactableList.Remove(this);
        if (interactor._interactableList.Count == 0)
        {
            interactor._midScreenText.text = "";
        }
        else
        {
            interactor._midScreenText.text = GetPopupMessage();
        }
    }



    private string GetPopupMessage()
    {
        return $"Press {_interactKey} to {_actionName} {_interactableName}";
    }



    public virtual void Init()
    {
        _interactKey = Controls.keys._interact.ToString();
        _boxCollider2D = GetComponent<BoxCollider2D>();
        _boxCollider2D.isTrigger = true;
    }
}
