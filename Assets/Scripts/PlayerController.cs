using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(CapsuleCollider))]
public class PlayerController : MonoBehaviour
{
    [SerializeField] private float _rotationeSpeed;
    [SerializeField] private float _speed;
    
    private Rigidbody _rigidbody;
    private Animator _animator;
    private int _maxLength = 1;

    private void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
        _animator = GetComponent<Animator>();
    }
    
    private void Update()
    {
        Move();
    }
    
    private void Move()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        Vector3 directionVector = new Vector3(horizontal, 0, vertical);
       
        if (directionVector.magnitude > Mathf.Abs(0.05f))
        {
 
            transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.LookRotation(directionVector), Time.deltaTime * _rotationeSpeed);
        }
        
        _animator.SetFloat("speed", Vector3.ClampMagnitude(directionVector, _maxLength).magnitude);

        Vector3 moveDir = Vector3.ClampMagnitude(directionVector, _maxLength) * _speed;
        _rigidbody.linearVelocity = new Vector3(moveDir.x, _rigidbody.linearVelocity.y, moveDir.z);

        _rigidbody.angularVelocity = Vector3.zero;
    }
}
