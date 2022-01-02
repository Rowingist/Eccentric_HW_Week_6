
using UnityEngine;

public class TakeDamageOnCollision : MonoBehaviour
{
    [SerializeField] private EnemyHealth _enemyHealth;
    [SerializeField] private bool DieOnAnyCollision;
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.rigidbody)
        {
            if (collision.rigidbody.TryGetComponent(out Bullet bullet))
            {
                _enemyHealth.TakeDamage(1);
            }
        }
        if(DieOnAnyCollision == true)
        {
            _enemyHealth.TakeDamage(int.MaxValue);
        }
    }
}