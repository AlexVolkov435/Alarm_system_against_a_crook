using System;
using UnityEngine;

public class AlarmDetector : MonoBehaviour
{
    [SerializeField] private AlarmSystem _alarmSystem;
    
    public event Action OnAlarmDetected;
    public event Action OffAlarmDetected;
    
    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out Player player))
        {
            OnAlarmDetected?.Invoke();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        OffAlarmDetected?.Invoke();
    }
}