using System;
using UnityEngine;

public class AlarmDetector : MonoBehaviour
{
    public event Action PlayerEntered;
    public event Action PlayerExited;
    
    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out Player player))
        {
            PlayerEntered?.Invoke();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.TryGetComponent(out Player player))
        {
            PlayerExited?.Invoke();
        }
    }
}