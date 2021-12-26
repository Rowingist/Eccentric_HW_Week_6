using UnityEngine;

public class PlayerMover : MonoBehaviour
{
    [SerializeField] private Rigidbody _rigidbody;
    [SerializeField] private float _moveSpeed;
    [SerializeField] private float _jumpSpeed;
    [SerializeField] private float _friction;
    [SerializeField] private bool _isGrounded;
    [SerializeField] private float _angleLetJump = 45f;
    [SerializeField] private float _maxSpeed = 5f;
    [SerializeField] private Transform _colliderTransform;
    [SerializeField] private float _sittingSpeed = 15f;

    private float _currentScaleY = 1f, _sitScaleY = 0.5f, _stayScaleY = 1f;
    private Vector3 _scaleToChange = Vector3.one;

    private void Update()
    {
        _currentScaleY = Input.GetKey(KeyCode.LeftControl) || Input.GetKey(KeyCode.S) || !_isGrounded ? _sitScaleY : _stayScaleY;
        Sit(_currentScaleY);
        if (Input.GetKeyDown(KeyCode.Space) && _isGrounded)
        {
            Jump(_jumpSpeed);
        }
    }

    private void Sit(float scaleY)
    {
        _scaleToChange.y = scaleY;
        _colliderTransform.localScale = Vector3.Lerp(_colliderTransform.localScale, _scaleToChange, Time.deltaTime * _sittingSpeed);
    }

    private void Jump(float speed)
    {
        _rigidbody.AddForce(0f, speed, 0f, ForceMode.VelocityChange);
    }


    private void FixedUpdate()
    {
        float speedMultiplier = 1f;

        if (_isGrounded == false)
        {
            speedMultiplier = 0.2f;
            if (_rigidbody.velocity.x > _maxSpeed && Input.GetAxis("Horizontal") > 0)
            {
                speedMultiplier = 0;
            }
            if (_rigidbody.velocity.x < -_maxSpeed && Input.GetAxis("Horizontal") < 0)
            {
                speedMultiplier = 0;
            }
        }
        _rigidbody.AddForce(Input.GetAxis("Horizontal") * _moveSpeed * speedMultiplier, 0f, 0f, ForceMode.VelocityChange);
        if (_isGrounded)
        {
            _rigidbody.AddForce(-_rigidbody.velocity.x * _friction, 0f, 0f, ForceMode.VelocityChange);
        }
    }

    private void OnCollisionStay(Collision collision)
    {
        CheckIfGroundedByCollisionsCount(collision);
    }

    private void CheckIfGroundedByCollisionsCount(Collision collision)
    {
        for (int i = 0; i < collision.contactCount; i++)
        {
            float stayAngle = Vector3.Angle(collision.contacts[i].normal, Vector3.up);
            _isGrounded = stayAngle < _angleLetJump;
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        _isGrounded = false;
    }
}