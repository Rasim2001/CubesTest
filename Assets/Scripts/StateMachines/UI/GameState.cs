using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameState : IStateUI
{
    private GameView gameView;
    private CurrentSettingsView currentSettingsView;
    public GameState(ResourceLoaderService resourceLoaderService, Transform containerUI)
    {
        gameView = GameObject.Instantiate(resourceLoaderService.Prefabs.GAME_VIEW.GetComponent<GameView>(), containerUI);
        gameView.Init();

        currentSettingsView = GameObject.Instantiate(resourceLoaderService.Prefabs.CURRENT_SETTINGS_VIEW.GetComponent<CurrentSettingsView>(), gameView.transform);
        currentSettingsView.Init();
    }

    public void Enter()
    {
        EventManager.Instance.SendStartSpawnCoroutineEvent();

        gameView.gameObject.SetActive(true);
        gameView.OnBackButtonEvent += EventManager.Instance.SendMenuStateEvent;
        gameView.OnCurrentMenuButtonEvent += currentSettingsView.Enable;
        
        currentSettingsView.OnTimeSpawnChangedEvent += EventManager.Instance.SendTimeSpawnChangedEvent;
        currentSettingsView.OnSpeedChangedEvent += EventManager.Instance.SendSpeedCubeChangedEvent;
        currentSettingsView.OnDistanceChangedEvent += EventManager.Instance.SendDistanceCubeChangedEvent;
    }

    public void Exit()
    {
        EventManager.Instance.SendStopSpawnCoroutineEvent();

        gameView.gameObject.SetActive(false);
        gameView.OnBackButtonEvent -= EventManager.Instance.SendMenuStateEvent;
        gameView.OnCurrentMenuButtonEvent -= currentSettingsView.Enable;

        currentSettingsView.Disable();
        currentSettingsView.OnTimeSpawnChangedEvent -= EventManager.Instance.SendTimeSpawnChangedEvent;
        currentSettingsView.OnSpeedChangedEvent -= EventManager.Instance.SendSpeedCubeChangedEvent;
        currentSettingsView.OnDistanceChangedEvent -= EventManager.Instance.SendDistanceCubeChangedEvent;
    }
}
