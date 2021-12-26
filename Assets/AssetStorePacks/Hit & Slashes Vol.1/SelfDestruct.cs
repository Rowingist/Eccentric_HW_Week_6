using UnityEngine;
using System.Collections;


public class SelfDestruct : MonoBehaviour {
	public float selfdestruct_in = 4; // Setting this to 0 means no selfdestruct.

    private AudioClip _hitsound;
    private AudioSource _audioSource;

    void Start () {
        _audioSource = GetComponent<AudioSource>();
        _audioSource.clip = _hitsound;
        if ( selfdestruct_in != 0){
            _audioSource.Play();
            Destroy (gameObject, selfdestruct_in);
		}
	}

    public void Init(AudioClip hitSound)
    {
        _hitsound = hitSound;
    }
}