﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryManager : MonoBehaviour, IGameManager
{
    public ManagerStatus status { get; private set; }

    private Dictionary<string, int> _items;
    public string  equippedItem { get; private set; }

    public List<string> GetItemList()
    {
        List<string> list = new List<string>(_items.Keys);
        return list;
    }

    public int GetItemCount(string name)
    {
        if(_items.ContainsKey(name))
        {
            return _items[name];
        }
        return 0;
    }

    public void StartUp()
    {
        Debug.Log("Inventory manager starting...");

        _items = new Dictionary<string, int>();

        status = ManagerStatus.Started;
    }

    public void DisplayItems()
    {
        string itemDistplay = "Items: ";
        foreach(KeyValuePair<string, int> item in _items)
        {
            itemDistplay += item.Key + "(" + item.Value + ") ";
        }

        Debug.Log(itemDistplay);
    }

    public void AddItem(string name)
    {
        if(_items.ContainsKey(name))
        {
            _items[name] += 1;
        }
        else
        {
            _items[name] = 1;
        }

        DisplayItems();
    }

    public bool EquipItem(string name)
    {
        if(_items.ContainsKey(name) && equippedItem != name)
        {
            equippedItem = name;
            Debug.Log("Equipped: " + name);

            return true;
        }

        equippedItem = null;
        Debug.Log("Unequipped");
        return false;
    }
}
