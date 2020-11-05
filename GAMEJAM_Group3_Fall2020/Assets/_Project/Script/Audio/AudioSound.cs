using UnityEngine.Audio;
using UnityEngine;

[System.Serializable]
public class AudioSound
{
    public string audioName;

    public AudioClip audioClipName;

    [Range(0f, 1f)]
    public float volume;
    [Range(0.1f, 3f)]
    public float pitch; //pitch is speed
    
    public bool loop;


    [HideInInspector]
    public AudioSource source;
}
