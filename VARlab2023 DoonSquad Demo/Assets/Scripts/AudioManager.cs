using System;
using UnityEngine;
using UnityEngine.Audio;

public class AudioManager : MonoBehaviour
{
    public CustomSound[] sounds;

    public static AudioManager instance;

    void Awake()
    {
        if (instance == null)
            instance = this;
        else
        {
            Destroy(gameObject);
            return;
        }

        DontDestroyOnLoad(gameObject);

        foreach(CustomSound s in sounds)
        {
            s.source = gameObject.AddComponent<AudioSource>();
            s.source.clip = s.clip;

            s.source.mute = s.mute;
            s.source.volume = s.volume;
            s.source.pitch = s.pitch;
            s.source.loop = s.loop;
        }
    }

    public void Play (string name)
    {
        CustomSound s = Array.Find(sounds, sound => sound.soundName == name);
        Debug.Log(name + " played");
        if (s == null)
        {
            Debug.LogWarning("Sound:" + name + " not found");
            return;
        }
        s.source.Play();
    }
}
