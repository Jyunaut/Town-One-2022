using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraPan : MonoBehaviour
{
    [SerializeField, Range(0f, 10f)] private float _panSpeed;

    private Coroutine _panCoroutine;

    public void StartPan()
    {
        _panCoroutine = StartCoroutine(Pan());

        IEnumerator Pan()
        {
            while (true)
            {
                transform.position = new Vector3(transform.position.x + _panSpeed * Time.deltaTime, transform.position.y);
                yield return null;
            }
        }
    }

    public void StopPan()
    {
        StopCoroutine(_panCoroutine);
    }
}
