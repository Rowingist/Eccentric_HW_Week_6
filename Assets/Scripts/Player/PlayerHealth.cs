using UnityEngine;
using UnityEngine.Events;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] private int _health = 5;
    [SerializeField] private int _maxHealth = 8;
    [SerializeField] private AudioSource _addHealth;
    [SerializeField] private HealthUI _healthUI;

    private bool _invulnerable = false;

    public UnityEvent EventOntakeDamage;
    private void Start()
    {
        _healthUI.SetUp(_maxHealth);
        _healthUI.DysplayHealth(_health);
    }
    public void TakeDamage(int damageValue)
    {
        if (_invulnerable == false)
        {
            _health -= damageValue;
            if (_health <= 0)
            {
                _health = 0;
                Die();
            }
        }
        _invulnerable = true;
        Invoke("StopInvulnerable", 1f);
        _healthUI.DysplayHealth(_health);
        EventOntakeDamage.Invoke();
    }

    private void StopInvulnerable()
    {
        _invulnerable = false;
    }

    public void AddHealth(int healthValue)
    {
        _health += healthValue;
        if(_health > _maxHealth)
        {
            _health = _maxHealth;
        }
        _addHealth.Play();
        _healthUI.DysplayHealth(_health);
    }

    private void Die()
    {
        print("You Lost!");
    }
}
