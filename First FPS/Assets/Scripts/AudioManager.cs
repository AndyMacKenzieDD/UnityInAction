using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour, IGameManager
{
    [SerializeField]
    private AudioSource soundSource;
    [SerializeField]
    private AudioSource music1Source;
    [SerializeField]
    private string introBGMusic;
    [SerializeField]
    private string levelBGMusic;

    public ManagerStatus status { get; private set; }

    public float soundVolume
    {
        get
        {
            return AudioListener.volume;
        }
        set
        {
            AudioListener.volume = value;
        }
    }

    public bool soundMute
    {
        get
        {
            return AudioListener.pause;
        }
        set
        {
            AudioListener.pause = value;
        }
    }

    public float musicVolume
    {
        get
        {
            return _musicVolume;
        }
        set
        {
            _musicVolume = value;

            if(music1Source != null)
            {
                music1Source.volume = _musicVolume;
            }
        }
    }

    public bool musicMute
    {
        get
        {
            if(music1Source != null)
            {
                return music1Source.mute;
            }
            return false;
        }
        set
        {
            if(music1Source != null)
            {
                music1Source.mute = value;
            }
        }
    }

    private float _musicVolume;
    private NetworkService _network;

    public void Startup(NetworkService service)
    {
        Debug.Log("Audio manager strarting...");

        _network = service;
        music1Source.ignoreListenerVolume = true;
        music1Source.ignoreListenerPause = true;

        soundVolume = 1f;

        status = ManagerStatus.Started;
    }

    public void PlaySound(AudioClip clip)
    {
        soundSource.PlayOneShot(clip);
    }

    public void PlayIntroMusic()
    {
        PlayMusic(Resources.Load("Music/" + introBGMusic) as AudioClip);
    }

    public void PlayLevelMusic()
    {
        PlayMusic(Resources.Load("Music/" + levelBGMusic) as AudioClip);
    }

    private void PlayMusic(AudioClip clip)
    {
        music1Source.clip = clip;
        music1Source.Play();
    }

    public void StopMusic()
    {
        music1Source.Stop();
    }

    void Start ()
    {
		
	}
	

	void Update ()
    {
		
	}
}
