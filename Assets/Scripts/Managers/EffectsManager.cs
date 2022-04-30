using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EffectsManager : MonoBehaviour
{
    public static EffectsManager Instance { get; private set; }

    private Camera _camera;

    private void Awake()
    {
        if (Instance != null && Instance != this)
            Destroy(this);
        else
            Instance = this;

        _camera = FindObjectOfType<Camera>();
    }

    public Coroutine ScreenShake(float xMagnitude, float yMagnitude, float frequency, float duration)
    {
        if (duration <= 0f || (xMagnitude == 0f && yMagnitude == 0f) || frequency <= 0f)
            return null;

        return StartCoroutine(Shake());

        IEnumerator Shake()
        {
            float time = 0;
            while (time < duration)
            {
                float x = xMagnitude * Mathf.Sin(frequency * time + Mathf.PI * time / duration);
                float y = yMagnitude * Mathf.Sin(frequency * time - Mathf.PI * time / duration);
                _camera.transform.position = new Vector3(x, y, 0);
                time += Time.unscaledDeltaTime;
                yield return null;
            }
            _camera.transform.localPosition = Vector3.zero;
        }
    }
}
