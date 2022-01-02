using UnityEngine;

public class Hen : MonoBehaviour
{
    [SerializeField] private Rigidbody _rigidBody;
    [SerializeField] private PlayerMover _player;
    [SerializeField] private float _speedMovement = 3f;
    [SerializeField] private float _timeToreachSpeed = 1f;

    private void Start()
    {
        
    }

    private void FixedUpdate()
    {
        Vector3 toPlayer = (_player.transform.position - transform.position).normalized;
        Vector3 force = _rigidBody.mass * (toPlayer * _speedMovement - _rigidBody.velocity) / _timeToreachSpeed;

        _rigidBody.AddForce(force);
    }
}