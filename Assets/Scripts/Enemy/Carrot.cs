using UnityEngine;

public class Carrot : MonoBehaviour
{
    [SerializeField] private Rigidbody _rigidbody;
    [SerializeField] private float _movementSpeed;

    private void Start()
    {
        Transform playerTransform = FindObjectOfType<PlayerMover>().transform;
        Vector3 toPlayer = (playerTransform.position - transform.position).normalized;
        _rigidbody.velocity = toPlayer * _movementSpeed;
    }
}