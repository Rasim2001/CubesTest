using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class EventManager 
{
    public static EventManager Instance;
    public EventManager() => Instance = this;

    public UnityEvent OnGameStateEvent = new UnityEvent();
    public UnityEvent OnMenuStateEvent = new UnityEvent();
    public UnityEvent OnStartSpawnCoroutineEvent = new UnityEvent();
    public UnityEvent OnStopSpawnCoroutineEvent = new UnityEvent();

    public UnityEvent<float> OnTimeSpawnChangedEvent = new UnityEvent<float>();
    public UnityEvent<float> OnSpeedCubeChangedEvent = new UnityEvent<float>();
    public UnityEvent<float> OnDistanceCubeChangedEvent = new UnityEvent<float>();


    public void SendDistanceCubeChangedEvent(float distance)
    {
        OnDistanceCubeChangedEvent?.Invoke(distance);
    }

    public void SendSpeedCubeChangedEvent(float speed)
    {
        OnSpeedCubeChangedEvent?.Invoke(speed);
    }

    public void SendTimeSpawnChangedEvent(float timeSpawn)
    {
        OnTimeSpawnChangedEvent?.Invoke(timeSpawn);
    }
    public void SendStopSpawnCoroutineEvent()
    {
        OnStopSpawnCoroutineEvent?.Invoke();
    }
    public void SendStartSpawnCoroutineEvent()
    {
        OnStartSpawnCoroutineEvent?.Invoke();
    }

    public void SendGameStateEvent()
    {
        OnGameStateEvent?.Invoke();
    }

    public void SendMenuStateEvent()
    {
        OnMenuStateEvent?.Invoke();
    }
}
