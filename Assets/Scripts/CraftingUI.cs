using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CraftingUI : MonoBehaviour
{
    [Header("Recipe - items needed to craft the key")]
    [SerializeField] string[] requiredItems; // fill in Inspector e.g. "Iron", "Wood"

    [Header("Slots")]
    [SerializeField] Image[] ingredientSlots;   // UI Image slots showing placed items
    [SerializeField] Sprite emptySlotSprite;

    [Header("Output")]
    [SerializeField] Image outputSlot;
    [SerializeField] Sprite keySprite;
    [SerializeField] TextMeshProUGUI craftButtonText;

    bool[] slotFilled;

    void OnEnable()
    {
        slotFilled = new bool[ingredientSlots.Length];
        RefreshSlots();
        CheckAutoFill();
    }

    // Auto-fills slots with items the player already has
    void CheckAutoFill()
    {
        for (int i = 0; i < requiredItems.Length; i++)
        {
            if (i >= ingredientSlots.Length) break;

            if (Inventory.instance.HasItem(requiredItems[i]))
            {
                Item item = Inventory.instance.items.Find(x => x.itemName == requiredItems[i]);
                ingredientSlots[i].sprite = item.icon;
                ingredientSlots[i].color = Color.white;
                slotFilled[i] = true;
            }
        }
        UpdateCraftButton();
    }

    void RefreshSlots()
    {
        foreach (var slot in ingredientSlots)
        {
            slot.sprite = emptySlotSprite;
            slot.color = new Color(1, 1, 1, 0.3f);
        }
        outputSlot.sprite = emptySlotSprite;
        outputSlot.color = new Color(1, 1, 1, 0.3f);
    }

    void UpdateCraftButton()
    {
        bool allFilled = System.Array.TrueForAll(slotFilled, s => s);
        craftButtonText.text = allFilled ? "Craft Key!" : "Missing ingredients";
    }

    public void OnCraftPressed()
    {
        bool allFilled = System.Array.TrueForAll(slotFilled, s => s);
        if (!allFilled) return;

        // Consume items
        foreach (string itemName in requiredItems)
            Inventory.instance.RemoveItem(itemName);

        // Show key in output slot
        outputSlot.sprite = keySprite;
        outputSlot.color = Color.white;

        // Add key to inventory
        Debug.Log("Key crafted! Add key to inventory or trigger door unlock here.");

        // Clear slots
        slotFilled = new bool[ingredientSlots.Length];
        RefreshSlots();
    }

    public void OnClosePressed()
    {
        gameObject.SetActive(false);
    }
}