using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[RequireComponent(typeof(BoxCollider2D))]
public class Trigger : MonoBehaviour
{
    public Action trigger;
    private BoxCollider2D _boxCollider2D;


    void Awake()
    {
        _boxCollider2D = GetComponent<BoxCollider2D>();
        _boxCollider2D.isTrigger = true;
    }

    private void OnTriggerEnter2D(Collider2D other) {
        trigger();
    }
}
