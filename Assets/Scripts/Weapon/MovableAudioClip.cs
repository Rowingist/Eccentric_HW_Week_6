using UnityEngine;

public class MovableAudioClip : MonoBehaviour
{
    public AudioClip AudioClip { get; private set; }

    public void Init(AudioClip audioClip)
    {
        AudioClip = audioClip;
    }
}