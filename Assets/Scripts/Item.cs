using UnityEngine;

public class Item : MonoBehaviour
{
    public string itemName;
    public Sprite icon;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            PlayerInventory.instance.AddItem(this);

            InventoryUI ui = FindObjectOfType<InventoryUI>();
            if (ui != null) ui.RefreshUI();

            GetComponent<TargetInteractable>().Trigger();
        }
    }
}