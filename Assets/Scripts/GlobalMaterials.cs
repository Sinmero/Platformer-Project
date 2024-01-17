using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlobalMaterials : MonoBehaviour
{
    private static GlobalMaterials _globalMaterials;
    public static GlobalMaterials instance { get { return _globalMaterials; } }
    public Material
    _red,
    _green,
    _blue,
    _colorSplitter;
    private List<Coroutine> _coloutineList =  new List<Coroutine>();


    void Awake()
    {
        if (_globalMaterials != null && this != _globalMaterials)
        {
            Destroy(this);
        }
        else
        {
            _globalMaterials = this;
        }

        _blue.SetFloat("_OutlineTransition", 1);
        _green.SetFloat("_OutlineTransition", 1);
        _red.SetFloat("_OutlineTransition", 1);
        _colorSplitter.SetFloat("_Red", 0);
        _colorSplitter.SetFloat("_Green", 0);
        _colorSplitter.SetFloat("_Blue", 0);
    }



    public void SmoothShaderTransition(Material mat, string valueName, float value, bool addToClearList = true, float speed = 0.1f)
    {
        var coroutine = StartCoroutine(Transition(mat, valueName, value, speed));
        if(addToClearList) _coloutineList.Add(coroutine);
    }



    private IEnumerator Transition(Material mat, string valueName, float value, float speed = 0.1f)
    {
        float matStartVal = mat.GetFloat(valueName);
        float t = 0;
        while (t < 1)
        {
            t += speed;
            float lerp = Mathf.Lerp(matStartVal, value, t);
            yield return new WaitForSeconds(0.05f);
            mat.SetFloat(valueName, lerp);
        }
    }



     public void ClearCoroutines() {
        int count = _coloutineList.Count;
        if(count == 0) return;
        for(int i = 0; i < count; i++) {
            Debug.Log(i);
            StopCoroutine(_coloutineList[0]);
            _coloutineList.Remove(_coloutineList[0]);
        }

        // foreach(var obj in _coloutineList) {
        //     StopCoroutine(obj);
        //     _coloutineList.Remove(obj);
        // }
     }
}
