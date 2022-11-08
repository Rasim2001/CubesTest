using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameView : MonoBehaviour
{
    [SerializeField]
    private Button _backButton;

    [SerializeField]
    private Button _currentMenuButton;

    public event Action OnBackButtonEvent;
    public event Action OnCurrentMenuButtonEvent;

    public void Init()
    {
        _backButton.onClick.AddListener(() => OnBackButtonEvent?.Invoke());
        _currentMenuButton.onClick.AddListener(() => OnCurrentMenuButtonEvent?.Invoke());
    }
}
