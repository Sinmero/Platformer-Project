using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamerFollowObject : MonoBehaviour
{
    [SerializeField] private GameObject _cameraFollowGO;

    void Update()
    {
        transform.position = _cameraFollowGO.transform.position;
    }
}
