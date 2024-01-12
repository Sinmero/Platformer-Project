using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class PlatformBase : MonoBehaviour
{
    [HideInInspector] public BoxCollider2D _boxCollider2D;



    private void Awake() {
        _boxCollider2D = GetComponent<BoxCollider2D>();
    }



    public virtual void OnEnable() {
        _boxCollider2D.enabled = true;
    } 



    public virtual void OnDisable() {
        _boxCollider2D.enabled = false;
    }
}
