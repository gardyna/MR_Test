using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public static SoundManager Instance;

    [SerializeField] private GameObject audioPrefab;
    
    // Doing this rather than making it an own class for effectiveness.
    [SerializeField] private AudioClip[] audioLibrary;
    private List<AudioClipPlayer> clipsToManage = new List<AudioClipPlayer>();

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
    }
    
    private void Update() => ManageClips();

    /// <summary>
    /// Play AudioClip at index n in audioLibrary.
    /// </summary>
    public void Play(float volume = 1f, bool loop = false, int clipIndex = -1)
    {
        GameObject audioToPlay = Instantiate(audioPrefab, transform.position, transform.rotation);
        var audiClipPlayer = audioToPlay.GetComponent<AudioClipPlayer>();
        audiClipPlayer.SetClipSettings(volume, loop, audioLibrary[clipIndex]);
        clipsToManage.Add(audiClipPlayer);
    }
    
    // Destroy instantiated AudioClipPlayers if finished playing.
    private void ManageClips()
    {
        if (clipsToManage.Count > 0)
        {
            foreach (var clip in clipsToManage)
            {
                if (!clip.AudioSource.isPlaying)
                {
                    Destroy(clip.gameObject);

                    if (clipsToManage.Contains(clip))
                    {
                        clipsToManage.Remove(clip);
                    }
                }
            }
        }
    }

    /// <summary>
    /// Stop playing sounds. Unsure if we actually need this here rather than on the objects themselves.
    /// </summary>
    public void Stop()
    {
        throw new NotImplementedException();
    }
}