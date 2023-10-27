using UnityEngine;
using UnityEngine.Audio;

[System.Serializable]
public class CustomSound : MonoBehaviour
{
    public string soundName;
    public AudioClip clip;

    public bool mute;

    [Range(0f, 1f)]
    public float volume;
    [Range(.1f, 3f)]
    public float pitch;

    public bool loop;

    [HideInInspector]
    public AudioSource source;
}
