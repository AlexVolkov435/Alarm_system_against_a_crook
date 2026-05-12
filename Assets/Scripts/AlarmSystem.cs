using System.Collections;
using UnityEngine;

public class AlarmSystem : MonoBehaviour
{
    [SerializeField] private AudioSource _audioSource;
    [SerializeField] private AlarmDetector _alarmDetector;
   
    [SerializeField] private float _maxVolume = 1f;
    [SerializeField] private float _minVolume = 0f;
    [SerializeField] private float _volumeChangeSpeed = 0.5f;

    private bool _isThiefInside;
    private Coroutine _volumeCoroutine;
    
    private void OnEnable()
    {
        _alarmDetector.OnAlarmDetected += TurnAlarm;
        _alarmDetector.OffAlarmDetected += TurnOffAlarm;
    }

    private void OnDisable()
    {
        _alarmDetector.OnAlarmDetected -= TurnAlarm;
        _alarmDetector.OffAlarmDetected -= TurnOffAlarm;
    }

    private void Start()
    {
        _audioSource = GetComponent<AudioSource>();
        _audioSource.volume = _minVolume;
    }

    private void TurnAlarm()
    {
        _isThiefInside = true;
        StartVolumeChange();
    }
    
    private void TurnOffAlarm()
    {
        _isThiefInside = false;
    }
    
   private void Update()
   {
        float targetVolume = _isThiefInside ? _maxVolume : _minVolume;
        
        _audioSource.volume = Mathf.MoveTowards(
            _audioSource.volume, targetVolume, _volumeChangeSpeed * Time.deltaTime);
   }

   private void StartVolumeChange()
   {
       if (_volumeCoroutine != null)
           StopCoroutine(_volumeCoroutine);
       
       _volumeCoroutine = StartCoroutine(ChangeVolumeRoutine());
   }
   
   private IEnumerator ChangeVolumeRoutine()
   {
       float targetVolume = _isThiefInside ? _maxVolume : _minVolume;

       while (!Mathf.Approximately(_audioSource.volume, targetVolume))
       {
           _audioSource.volume = Mathf.MoveTowards
               (_audioSource.volume, targetVolume, _volumeChangeSpeed * Time.deltaTime);
           
           yield return null;
       }
   }
}