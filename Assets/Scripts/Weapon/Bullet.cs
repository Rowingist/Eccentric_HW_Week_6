using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] private GameObject _effectPrefab;
    [SerializeField] private MovableAudioClip _hitSound;
    [SerializeField] private AudioClip _henAudioSource;

    private Renderer _renderer;
    private void Start()
    {
        _renderer = GetComponent<Renderer>();
        Destroy(gameObject, 4f);
    }

    private void OnCollisionEnter(Collision collision)
    {
        GameObject newFlash = Instantiate(_effectPrefab, transform.position, Quaternion.identity);
        if (collision.gameObject.TryGetComponent(out Hen hen))
        {
            newFlash.GetComponent<SelfDestruct>().Init(_henAudioSource);
        }
        else
        {
            newFlash.GetComponent<SelfDestruct>().Init(_hitSound.AudioClip);
        }
        _renderer.enabled = false;
        Destroy(gameObject, 0.06f);
    }
}