using UnityEngine;

public class MakeDamageOnCollision : MonoBehaviour
{
    [SerializeField] private int damageValue = 1;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.rigidbody)
        {
            if (collision.rigidbody.GetComponent<PlayerHealth>())
            {
                collision.rigidbody.GetComponent<PlayerHealth>().TakeDamage(damageValue);
            }
        }
    }
}
