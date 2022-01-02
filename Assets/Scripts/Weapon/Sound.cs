using UnityEngine;

public class Sound : MonoBehaviour
{
    [SerializeField] private AudioClip[] _sounds;

    public AudioClip GetHitSound()
    {
        int random = Random.Range(0, _sounds.Length);
        return _sounds[random];
    }
}