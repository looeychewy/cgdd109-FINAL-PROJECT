using UnityEngine;

public class Item : MonoBehaviour
{
    public string itemName;
    public Sprite icon;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            Inventory.instance.AddItem(this);
            GetComponent<TargetInteractable>().Trigger(); // hooks into your existing system
        }
    }
}