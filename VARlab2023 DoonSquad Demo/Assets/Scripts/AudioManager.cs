using System;
using UnityEngine;
using UnityEngine.Audio;

public class AudioManager : MonoBehaviour
{
    public Sound[] music, sfx;
    public AudioSource musicSource, sfxSource;

    public static AudioManager instance;

    //string for the song
    public string song;

    //list of audio clips for songs
    public AudioClip[] songs;

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

    //set music
    void SetMusic()
    {
            song = UnityEngine.SceneManagement.SceneManager.GetActiveScene().name;
            musicSource.clip = Array.Find(songs, sound => sound.name == song);
            if(musicSource.clip == null)
            {
                Debug.LogWarning("Song:" + song + " not found");
            }
            else
            {
                Debug.Log(song + " set" + musicSource.clip);
            }
    }

    //update
    void Update()
    {
        if(song != UnityEngine.SceneManagement.SceneManager.GetActiveScene().name)
        {
            //stop the music 
            musicSource.Stop();
            //set the music
            SetMusic();
            //play the music
            musicSource.Play();
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
