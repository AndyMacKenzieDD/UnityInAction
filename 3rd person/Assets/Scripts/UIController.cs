using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class UIController : MonoBehaviour
{
    [SerializeField]
    private Text healthLabel;
    [SerializeField]
    private InventoryPopup popup;

    private void Awake()
    {
        Messenger.AddListener(GameEvent.HEALTH_UPDATED, OnHealthUpdated);
    }

    private void OnDestroy()
    {
        Messenger.RemoveListener(GameEvent.HEALTH_UPDATED, OnHealthUpdated);
    }

    void Start()
    {
        OnHealthUpdated();
        popup.gameObject.SetActive(false);
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.M))
        {
            popup.gameObject.SetActive(!popup.gameObject.activeSelf);
            popup.Refresh();
        }
    }

    private void OnHealthUpdated()
    {
        healthLabel.text = "Health: " + Managers.Player.health + "/" + Managers.Player.maxHealth;
    }
}
