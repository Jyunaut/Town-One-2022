using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameIntroButton : MonoBehaviour
{
    [SerializeField] private GameObject _introScreen;
    [SerializeField] private GameObject _hud;

    private Button _button;

    private void Awake()
    {
        _button = GetComponent<Button>();
        _button.onClick.AddListener(SwapCanvas);
        _button.onClick.AddListener(GameEvent.StartGame);
    }

    private void SwapCanvas()
    {
        _introScreen.SetActive(false);
        _hud.SetActive(true);
    }
}
