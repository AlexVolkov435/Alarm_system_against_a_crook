using UnityEngine;

public class AlarmSystem : MonoBehaviour
{
    [SerializeField] private AudioSource _audioSource;
    [SerializeField] private float _maxVolume = 1f;
    [SerializeField] private float _minVolume = 0f;
    [SerializeField] private float _volumeChangeSpeed = 0.5f;

    private bool _isThiefInside;

    private void Start()
    {
        _audioSource = GetComponent<AudioSource>();
        _audioSource.volume = _minVolume;
    }

    public void SetThiefStatus(bool inside)
    {
        _isThiefInside = inside;
    }

   private void Update()
   {
        float targetVolume = _isThiefInside ? _maxVolume : _minVolume;
        
        _audioSource.volume = Mathf.MoveTowards(
            _audioSource.volume, targetVolume, _volumeChangeSpeed * Time.deltaTime);
   }
}