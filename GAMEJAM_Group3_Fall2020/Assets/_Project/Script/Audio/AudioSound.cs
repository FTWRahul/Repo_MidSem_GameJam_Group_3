using UnityEngine.Audio;
using UnityEngine;

[System.Serializable]
public class AudioSound
{
    public string audioName;

    public AudioClip audioClipName;

    [Range(0f, 1f)]
    public float volume;
    [Range(0f, 5f)]
    public float pitch;
    
    public bool loop;


    [HideInInspector]
    public AudioSource source;
}
