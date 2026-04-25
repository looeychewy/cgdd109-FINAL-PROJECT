using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    public static Inventory instance;
    public List<Item> items = new List<Item>();

    void Awake()
    {
        instance = this;
    }

    public void AddItem(Item item)
    {
        items.Add(item);
        Debug.Log($"Picked up {item.itemName}");
    }

    public bool HasItem(string itemName)
    {
        return items.Exists(i => i.itemName == itemName);
    }

    public void RemoveItem(string itemName)
    {
        Item found = items.Find(i => i.itemName == itemName);
        if (found != null) items.Remove(found);
    }
}