using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class SettingsPopup : MonoBehaviour
{
    [SerializeField]
    private Slider speedSlide;

	void Start ()
    {
        speedSlide.value = PlayerPrefs.GetFloat("speed", 1);
	}
	
	void Update ()
    {
		
	}

    public void Open()
    {
        gameObject.SetActive(true);
    }

    public void Close()
    {
        gameObject.SetActive(false);
    }

    public void OnSubmitName(string name)
    {
        Debug.Log(name);
    }

    public void OnSpeedValue(float speed)
    {
        PlayerPrefs.SetFloat("speed", speed);
        Messenger<float>.Broadcast(GameEvent.SPEED_CHANGED, speed);
    }
}
