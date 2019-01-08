using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCharacter : MonoBehaviour
{
	void Start ()
    {

	}
	
	void Update ()
    {
		
	}

    public void Hurt(int damage)
    {
        Managers.Player.ChangeHealth(-damage);
    }
}
