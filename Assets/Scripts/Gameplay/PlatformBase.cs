using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class PlatformBase : MonoBehaviour
{
    [HideInInspector] public BoxCollider2D _boxCollider2D;
    private LayerMask _layerMask;



    private void Awake()
    {
        _boxCollider2D = GetComponent<BoxCollider2D>();
        _layerMask = LayerMask.GetMask("Player");

    }



    public virtual void OnEnable()
    {
        StartCoroutine(PreventCollisionOverlap());
    }



    public virtual void OnDisable()
    {
        _boxCollider2D.enabled = false;
    }



    public IEnumerator PreventCollisionOverlap() //this will prevent tile collider from pushing the player inside other collider on collider overlap case
    {
        RaycastHit2D[] collisions = Physics2D.BoxCastAll(transform.position, _boxCollider2D.size * 0.8f, 0, Vector2.zero, 0, _layerMask);
        if (collisions.Length == 0)
        {
            _boxCollider2D.enabled = true;
        }
        else
        {
            PhysicsLogger.instance.Log($"Player is overlapping with {transform.name} at {transform.position}", this); //
            yield return new WaitForSeconds(0.05f);
            StartCoroutine(PreventCollisionOverlap());
        }
    }



    public virtual void OnLanded(State state) { }
}
