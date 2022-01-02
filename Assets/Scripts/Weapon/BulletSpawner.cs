using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletSpawner : MonoBehaviour
{
    [SerializeField] private Bullet _bulletTemplate;
    [SerializeField] private Transform _spawnPoint;
    [SerializeField] private float _bulletSpeed = 10f;
    [SerializeField] private float _shootPeriod = 0.2f;
    [SerializeField] private AudioSource _shootSound;
    [SerializeField] private GameObject _flash;
    [SerializeField] private Sound _hitSounds;
    [SerializeField] private ParticleSystem _smokeTrail;

    private float _elapsedTime;

    private void Update()
    {
        _elapsedTime += Time.deltaTime;
        Spawn();
    }

    private void Spawn()
    {
        if (_elapsedTime > _shootPeriod && Input.GetMouseButton(0))
        {
            _smokeTrail.Play();
            _elapsedTime = 0;
            Bullet newBullet = Instantiate(_bulletTemplate, _spawnPoint.position, _spawnPoint.rotation);
            newBullet.gameObject.GetComponent<Rigidbody>().velocity = _spawnPoint.forward * _bulletSpeed;
            newBullet.gameObject.GetComponent<MovableAudioClip>().Init(_hitSounds.GetHitSound());
            _shootSound.Play();
            _flash.SetActive(true);
            Invoke("HideFlash", 0.12f);
        }
    }

    private void HideFlash()
    {
        _flash.SetActive(false);
    }
}