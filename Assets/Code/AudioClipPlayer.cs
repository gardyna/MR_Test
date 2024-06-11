using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class AudioClipPlayer : MonoBehaviour
{
    public AudioSource AudioSource => _audioSource;
    private AudioSource _audioSource;

    private void OnEnable() => _audioSource = GetComponent<AudioSource>();
    

    public void SetClipSettings(float volume = 1f, bool loop = false, AudioClip clip = null)
    {
        if (clip == null)
        {
            Debug.LogError("No AudioClip attached to call.");
            return;
        }
        
        _audioSource.volume = volume;
        _audioSource.loop = loop;
        _audioSource.clip = clip;
        
        _audioSource.Play();
    }
}