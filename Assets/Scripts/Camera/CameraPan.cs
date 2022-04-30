using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraPan : MonoBehaviour
{
    [SerializeField, Range(0f, 10f)] private float _panSpeed;

    public bool ReachedEnd { get; set; }

    private void Start()
    {
        ReachedEnd = false;
        StartPan();
    }

    public Coroutine StartPan()
    {
        return StartCoroutine(Pan());

        IEnumerator Pan()
        {
            while (!ReachedEnd)
            {
                transform.position = new Vector3(transform.position.x + _panSpeed * Time.deltaTime, transform.position.y);
                yield return null;
            }
        }
    }
}
