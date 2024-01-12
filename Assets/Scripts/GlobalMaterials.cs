using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlobalMaterials : MonoBehaviour
{
    private static GlobalMaterials _globalMaterials;
    public static GlobalMaterials instance {get {return _globalMaterials;}}
    public Material 
    _red,
    _green,
    _blue;


    void Awake()
    {
        _blue.SetFloat("_OutlineTransition", 1);
        _green.SetFloat("_OutlineTransition", 1);
        _red.SetFloat("_OutlineTransition", 1);

        if(_globalMaterials == null) _globalMaterials = this;
    }

}
