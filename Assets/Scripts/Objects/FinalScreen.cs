using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class FinalScreen : MonoBehaviour
{
    [SerializeField] private Material _fadeMat;
    [SerializeField] private TextMeshProUGUI _titleText;

    


    void Start()
    {
        _fadeMat.SetFloat("_Radius", 9);
        StartCoroutine(Transition(_fadeMat, "_Radius", 12.5f));
        StartCoroutine(PrintTitle());
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



    private IEnumerator PrintTitle() {
        var title = "<color=#ffee00>THE YELLOW DOOR</color>";

        yield return new WaitForSeconds(1);
        Speech.instance.PrintText(title, _titleText, 0.2f);
    }
}
