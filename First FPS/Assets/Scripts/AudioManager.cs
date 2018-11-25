using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour, IGameManager
{
    [SerializeField]
    private AudioSource soundSource;

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

    private NetworkService _network;

    public void Startup(NetworkService service)
    {
        Debug.Log("Audiomanager strarting...");

        _network = service;

        soundVolume = 1f;

        status = ManagerStatus.Started;
    }

    public void PlaySound(AudioClip clip)
    {
        soundSource.PlayOneShot(clip);
    }

	void Start ()
    {
		
	}
	

	void Update ()
    {
		
	}
}
