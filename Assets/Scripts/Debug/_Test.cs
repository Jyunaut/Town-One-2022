using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class _Test : MonoBehaviour
{
    [SerializeField] private CameraPan _cameraPan;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Z))
        {
            _cameraPan.StartPan();
        }
    }
}
