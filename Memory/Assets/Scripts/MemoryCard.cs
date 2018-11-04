using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MemoryCard : MonoBehaviour
{
    [SerializeField]
    private GameObject cardBack;

    [SerializeField]
    private SceneController controller;

    public int Id;

	void Start ()
    {

	}
	
	void Update ()
    {
		
	}

    private void OnMouseDown()
    {
        if(cardBack.activeSelf && controller.canReveal)
        {
            cardBack.SetActive(false);
            controller.CardRevealed(this);
        }
    }
    
    public void Unreveal()
    {
        cardBack.SetActive(true);
    }

    public void SetCard(int id, Sprite image)
    {
        Id = id;
        GetComponent<SpriteRenderer>().sprite = image;
    }

}
