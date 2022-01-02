using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rabbit : MonoBehaviour
{
    [SerializeField] private float _attackPeriod = 7f;
    [SerializeField] private Animator _animator;

    private float _timer;
    private int _attackTriggerHash;

    private void Start()
    {
        _attackTriggerHash = Animator.StringToHash("Attack");
    }
    private void Update()
    {
        _timer += Time.deltaTime;
        if(_timer > _attackPeriod)
        {
            _timer = 0;
            _animator.SetTrigger(_attackTriggerHash);
        }
    }
}
