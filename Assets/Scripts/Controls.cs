using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controls : MonoBehaviour
{
    public bool _isArrowControls = true;
    private static Controls _controls;
    public static Controls instance { get { return _controls; } }
    private static controlKeys _keys;
    public static controlKeys keys { get { return _keys; } }
    private static controlKeys _defaultKeys = new controlKeys(KeyCode.W, KeyCode.A, KeyCode.D, KeyCode.Z, KeyCode.X, KeyCode.C, KeyCode.V, KeyCode.E, KeyCode.LeftShift, KeyCode.R);
    private static controlKeys _customkeys = new controlKeys(KeyCode.W, KeyCode.A, KeyCode.D, KeyCode.LeftArrow, KeyCode.UpArrow, KeyCode.RightArrow, KeyCode.DownArrow, KeyCode.E, KeyCode.Space, KeyCode.R);
    private static controlKeys _lockedControls = new controlKeys(KeyCode.None, KeyCode.None, KeyCode.None, KeyCode.None, KeyCode.None, KeyCode.None, KeyCode.None, KeyCode.E, KeyCode.None, KeyCode.None);



    private void Awake()
    {
        _keys = _defaultKeys;

        if (_controls == null) _controls = this;

        if (_isArrowControls) _keys = _customkeys;
    }



    public static void LockControls()
    {
        _keys = _lockedControls;
        SystemLogger.instance.Log($"Controls locked.", null);
    }



    public static void UnlockControls() {
        _keys = _customkeys;
        SystemLogger.instance.Log($"Controls unlocked.", null);
    }
}




public struct controlKeys
{
    public controlKeys(KeyCode jump, KeyCode left, KeyCode right, KeyCode red, KeyCode green, KeyCode blue, KeyCode grey, KeyCode interact, KeyCode dash, KeyCode returnToCheckpoint)
    {
        _jump = jump;
        _left = left;
        _right = right;
        _red = red;
        _green = green;
        _blue = blue;
        _interact = interact;
        _grey = grey;
        _dash = dash;
        _returnToCheckpoint = returnToCheckpoint;
    }

    public KeyCode _jump;
    public KeyCode _left;
    public KeyCode _right;
    public KeyCode _red;
    public KeyCode _green;
    public KeyCode _blue;
    public KeyCode _grey;
    public KeyCode _interact;
    public KeyCode _dash;
    public KeyCode _returnToCheckpoint;
}