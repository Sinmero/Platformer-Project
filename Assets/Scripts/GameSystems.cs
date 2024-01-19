using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class GameSystems : MonoBehaviour
{
    private static GameSystems _gameSystems;
    public static GameSystems instance {get {return _gameSystems;}}



    void Awake()
    {
        Screen.SetResolution(1920, 1080, false);

        if(_gameSystems != null && this == _gameSystems) {
            Destroy(this);
        } else {
            _gameSystems = this;
        }
    }



    private IEnumerator Coroutine(Action beforeTimer, float timer, Action afterTimer = null) {
        yield return new WaitForEndOfFrame();
        beforeTimer();
        yield return new WaitForSeconds(timer);
        afterTimer();
    }



    public void CoroutineStart (Action beforeTimer, float timer, Action afterTimer = null) {
        StartCoroutine(Coroutine(beforeTimer, timer, afterTimer));
    }
}
