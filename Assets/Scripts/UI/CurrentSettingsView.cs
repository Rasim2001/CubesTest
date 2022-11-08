using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
public class CurrentSettingsView : MonoBehaviour
{
    [SerializeField]
    private TMP_InputField _timeSpawnInputField;

    [SerializeField]
    private TMP_InputField _speedInputField;

    [SerializeField]
    private TMP_InputField _distanceInputField;

    [SerializeField]
    private Button _hideButton;

    public float TimeSpawn { get { return float.Parse(_timeSpawnInputField.text); } }
    public float Speed { get { return float.Parse(_speedInputField.text); } }
    public float Distance { get { return float.Parse(_distanceInputField.text); } }

    public event Action<float> OnTimeSpawnChangedEvent;
    public event Action<float> OnSpeedChangedEvent;
    public event Action<float> OnDistanceChangedEvent;

    private const float TimeSpawnDefault = 1;
    private const float SpeedDefault = 5;
    private const float DistanceDefault = 20;

    private const float TimeSpawnMaxValue = 5;
    private const float SpeedMaxValue = 100;
    private const float DistanceMaxValue = 100;

    private const float TimeSpawnMinValue = 0.1f;
    private const float SpeedMinValue = 1f;
    private const float DistanceMinValue = 2f;

    public void Enable() => gameObject.SetActive(true);
    public void Disable() => gameObject.SetActive(false);

    public void Init()
    {
        _timeSpawnInputField.onEndEdit.AddListener((string a) => SetTimeSpawn());
        _speedInputField.onEndEdit.AddListener((string a) => SetSpeed());
        _distanceInputField.onEndEdit.AddListener((string a) => SetDistance());

        _hideButton.onClick.AddListener(Disable);
    }
    
    private void SetTimeSpawn()
    {
        if(TimeSpawn >= TimeSpawnMinValue && TimeSpawn <= TimeSpawnMaxValue)
        {
            OnTimeSpawnChangedEvent?.Invoke(TimeSpawn);
        }
        else if(TimeSpawn < TimeSpawnMinValue)
        {
            OnTimeSpawnChangedEvent?.Invoke(TimeSpawnMinValue);
            _timeSpawnInputField.text = TimeSpawnMinValue.ToString();
        }else
        {
            OnTimeSpawnChangedEvent?.Invoke(TimeSpawnMaxValue);
            _timeSpawnInputField.text = TimeSpawnMaxValue.ToString();
        }

    }

    private void SetSpeed()
    {
        if(Speed >= SpeedMinValue && Speed <= SpeedMaxValue)
        {
            OnSpeedChangedEvent?.Invoke(Speed);
        }
        else if(Speed < SpeedMinValue)
        {
            OnSpeedChangedEvent?.Invoke(SpeedMinValue);
            _speedInputField.text = SpeedMinValue.ToString();
        }
        else
        {
            OnSpeedChangedEvent?.Invoke(SpeedMaxValue);
            _speedInputField.text = SpeedMaxValue.ToString();
        }
    }

    private void SetDistance()
    {
        if(Distance >= DistanceMinValue && Distance <= DistanceMaxValue)
        {
            OnDistanceChangedEvent?.Invoke(Distance);
        }
        else if(Distance < DistanceMinValue)
        {
            OnDistanceChangedEvent?.Invoke(DistanceMinValue);
            _distanceInputField.text = DistanceMinValue.ToString();
        }
        else
        {
            OnDistanceChangedEvent?.Invoke(DistanceMaxValue);
            _distanceInputField.text = DistanceMaxValue.ToString();
        }
    }
}
