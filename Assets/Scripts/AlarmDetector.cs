using UnityEngine;

public class AlarmDetector : MonoBehaviour
{
    [SerializeField] private AlarmSystem _alarmSystem;
    
    private int _counter;
    private Animator _animator;

    private void Awake()
    {
        _animator = GetComponent<Animator>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.TryGetComponent(out PlayerController playerController))
        {
            _counter++;
            _alarmSystem.SetThiefStatus(true);
            _animator.SetBool("isOpen", true);
        }

        CountPenetrations();
    }

    private void CountPenetrations()
    {
        if (_counter % 2 == 0)
        {
            _alarmSystem.SetThiefStatus(false);
        }
    }
}