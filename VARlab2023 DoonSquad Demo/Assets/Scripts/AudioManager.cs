using System;
using UnityEngine;
using UnityEngine.Audio;

public class AudioManager : MonoBehaviour
{
    public Sound[] music, sfx;
    public AudioSource musicSource, sfxSource;

    public static AudioManager instance;

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
            return;
        }
    }

    public void PlayMusic (string name)
    {
        Sound s = Array.Find(music, sound => sound.soundName == name);
        if (s == null)
            Debug.LogWarning("Sound:" + name + " not found");
        else
        {
            musicSource.clip = s.clip;
            musicSource.Play();
            Debug.Log(name + " played");
        }
    }

    public void ToggleMusic()
    {
        if (musicSource.mute)
            musicSource.mute = false;
        else
            musicSource.mute = true;
    }

    public void PlaySFX(string name)
    {
        Sound s = Array.Find(sfx, sound => sound.soundName == name);
        if (s == null)
            Debug.LogWarning("Sound:" + name + " not found");
        else
        {
            sfxSource.clip = s.clip;
            sfxSource.PlayOneShot(s.clip);
            Debug.Log(name + " played");
        }
    }

    public void ToggleSFX()
    {
        if (sfxSource.mute)
            sfxSource.mute = false;
        else
            sfxSource.mute = true;
    }
}
