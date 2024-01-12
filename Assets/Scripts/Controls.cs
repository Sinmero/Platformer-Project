using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controls : MonoBehaviour
{
    public bool _isMouseControl = true;
    private static Controls _controls;
    public static Controls instance { get { return _controls; } }
    private static controlKeys _keys;
    public static controlKeys keys {get {return _keys;}}
    private static controlKeys _defaultKeys = new controlKeys(KeyCode.W, KeyCode.A, KeyCode.D, KeyCode.Z, KeyCode.X, KeyCode.C);
    private static controlKeys _customkeys = new controlKeys(KeyCode.W, KeyCode.A, KeyCode.D, KeyCode.Mouse0, KeyCode.Mouse2, KeyCode.Mouse1);



    private void Awake()
    {
        _keys = _defaultKeys;

        if(_controls == null) _controls = this;

        if (_isMouseControl) _keys = _customkeys;
    }
}


public struct controlKeys 
{
    public controlKeys(KeyCode jump, KeyCode left, KeyCode right, KeyCode red, KeyCode green, KeyCode blue) {
        _jump = jump;
        _left = left;
        _right = right;
        _red = red;
        _green = green;
        _blue = blue;
    }

    public KeyCode _jump;
    public KeyCode _left;
    public KeyCode _right;
    public KeyCode _red;
    public KeyCode _green;
    public KeyCode _blue;
}