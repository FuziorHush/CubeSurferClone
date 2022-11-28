using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class PlayerSounds : MonoBehaviour
{
    private AudioSource _audioSource;

    private bool _clipPlayedThisFrame;

    private void Awake()
    {
        _audioSource = GetComponent<AudioSource>();
    }

    private void LateUpdate()
    {
        if (_clipPlayedThisFrame)
            _clipPlayedThisFrame = false;
    }

    public void Play(AudioClip clip, float volume = 1f) {
        _audioSource.PlayOneShot(clip, volume);
    }

    public void PlayOneInFrame(AudioClip clip, float volume = 1f)
    {
        if (!_clipPlayedThisFrame)
        {
            _audioSource.PlayOneShot(clip, volume);
            _clipPlayedThisFrame = true;
        }
    }
}
