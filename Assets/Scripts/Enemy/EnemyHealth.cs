using UnityEngine;
using UnityEngine.Events;

public class EnemyHealth : MonoBehaviour
{
    [SerializeField] private int _health = 1;

    public UnityEvent EventOnTakeDamage;
    public void TakeDamage(int damage)
    {
        _health -= damage;
        if(_health <= 0)
        {
            Die();
        }
        EventOnTakeDamage.Invoke();
    }

    public void Die()
    {
        Destroy(gameObject);
    }
}
