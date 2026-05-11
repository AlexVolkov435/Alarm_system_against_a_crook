using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] private Transform _playerTransform;
    [SerializeField] private Vector3 _offset;

    [SerializeField] private float _cameraRotationSpeed = 5f;

    private void Start()
    {
        float angleX = 8.5f;

        transform.Rotate(angleX, 0, 0);
    }
    
    private void FixedUpdate()
    {
        Vector3 newCamPosition = new Vector3(_playerTransform.position.x + _offset.x, _playerTransform.position.y + _offset.y,
            _playerTransform.position.z + _offset.z);

        transform.position = Vector3.Lerp(transform.position, newCamPosition, _cameraRotationSpeed * Time.deltaTime);
    }
}
