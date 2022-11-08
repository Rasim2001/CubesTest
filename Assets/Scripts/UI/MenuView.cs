using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuView : MonoBehaviour
{
    [SerializeField]
    private Button _playButton;

    [SerializeField]
    private Button _quitButton;

    public event Action OnPlayButtonEvent;

    public void Init()
    {
        _playButton.onClick.AddListener(() => OnPlayButtonEvent?.Invoke());
        _quitButton.onClick.AddListener(() => Application.Quit());
    }
}
