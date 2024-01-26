using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlobalMaterials : MonoBehaviour
{
    private static GlobalMaterials _globalMaterials;
    public static GlobalMaterials instance { get { return _globalMaterials; } }
    public Material
    _redPlatform,
    _greenPlatform,
    _bluePlatform,
    _dashing,
    _lowGrav,
    _redGlobal,
    _greenGlobal,
    _blueGlobal,
    _water,
    _cameraFade;
    private List<Coroutine> _coloutineList =  new List<Coroutine>();


    void Awake()
    {
        _cameraFade.SetFloat("_Radius", 9);
        SmoothShaderTransition(_cameraFade, "_Radius", 12.5f, false, 0.1f);


        if (_globalMaterials != null && this != _globalMaterials)
        {
            Destroy(this);
        }
        else
        {
            _globalMaterials = this;
        }

        //reset all shaders

        SetFloat(_redPlatform, "_OutlineTransition", 1);
        SetFloat(_greenPlatform, "_OutlineTransition", 1);
        SetFloat(_bluePlatform, "_OutlineTransition", 1);
        SetFloat(_redGlobal,"_ShiftSlider", -0.1f);
        SetFloat(_blueGlobal, "_ShiftSlider", -0.1f);
        SetFloat(_greenGlobal, "_ShiftSlider", -0.1f);
        SetFloat(_water, "_ShiftSlider", -0.1f);
        SetFloat(_lowGrav, "_Alpha", 0);
    }



    private void SetFloat(Material mat, string valueName, float f){
        if(mat == null) return;
        mat.SetFloat(valueName, f);
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
            StopCoroutine(_coloutineList[0]);
            _coloutineList.Remove(_coloutineList[0]);
        }
     }
}
