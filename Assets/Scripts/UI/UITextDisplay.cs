using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UITextDisplay : MonoBehaviour
{
    private static UITextDisplay _uiTextDisplay;
    public static UITextDisplay uITextDisplay {get {return _uiTextDisplay;}}


    private void Awake() {
        if(_uiTextDisplay != null && this != _uiTextDisplay) Destroy(this);
        _uiTextDisplay = this;
    }



    public void SetText (TextMesh textMesh, string str) {
        textMesh.text = str;
    }


}
