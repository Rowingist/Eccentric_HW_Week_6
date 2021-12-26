using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] private GameObject _effectPrefab;
    [SerializeField] private MovableAudioClip _hitSound;

    private void Start()
    {
        Destroy(gameObject, 4f);
    }

    private void OnCollisionEnter(Collision collision)
    {
        GameObject newFlash = Instantiate(_effectPrefab, transform.position, Quaternion.identity);
        newFlash.GetComponent<SelfDestruct>().Init(_hitSound.AudioClip);
        Destroy(gameObject);
    }
}