using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] private GameObject _effectPrefab;
    [SerializeField] private MovableAudioClip _hitSound;

    private Renderer _renderer;
    private Rigidbody _rigidbody;

    private void Start()
    {
        _renderer = GetComponent<Renderer>();
        _rigidbody = GetComponent<Rigidbody>();
        Destroy(gameObject, 4f);
    }

    private void OnCollisionEnter(Collision collision)
    {
        GameObject newFlash = Instantiate(_effectPrefab, transform.position, Quaternion.identity);
        newFlash.GetComponent<SelfDestruct>().Init(_hitSound.AudioClip);
        _renderer.enabled = false;
        _rigidbody.isKinematic = true;
        Destroy(gameObject, 0.5f);
    }
}