using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraPan : MonoBehaviour
{
    [SerializeField, Range(0f, 30f)] private float _panSpeed;

    private Coroutine _panCoroutine;

    public void OnEnable()
    {
        GameEvent.OnGameStart += StartPan;
    }

    public void OnDisable()
    {
        GameEvent.OnGameStart -= StartPan;
    }

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
        if (_panCoroutine != null)
            StopCoroutine(_panCoroutine);
    }
}
