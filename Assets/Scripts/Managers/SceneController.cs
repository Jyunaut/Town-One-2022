using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SceneController : MonoBehaviour
{
    public static SceneController Instance { get; private set; }

    private void Awake()
    {
        if (Instance != null || Instance != this)
        {
            Destroy(gameObject);
        }
        else
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }

    public static void LoadScene(int index)
    {
        Image img = GameObject.FindGameObjectWithTag("TransitionScreen").GetComponent<Image>();
        img.rectTransform.sizeDelta = new Vector2(Screen.width + 20f, Screen.height + 20f);
        Instance.StartCoroutine(Instance.SceneTransition(img, index));
    }

    private IEnumerator SceneTransition(Image img, int index)
    {
        for (float i = 0f; i < 1f; i += Time.deltaTime / 0.25f)
        {
            img.color = new Color(0f, 0f, 0f, Mathf.Lerp(0f, 1f, i));
            yield return null;
        }

        AsyncOperation ao = SceneManager.LoadSceneAsync(index);

        for (float i = 0f; i < 1f; i += Time.deltaTime / 0.25f)
        {
            img.color = new Color(0f, 0f, 0f, Mathf.Lerp(1f, 0f, i));
            yield return null;
        }
    }
}
