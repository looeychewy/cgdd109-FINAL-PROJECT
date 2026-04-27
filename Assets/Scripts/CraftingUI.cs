using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CraftingUI : MonoBehaviour
{
    [Header("Recipe - items needed to craft the key")]
    [SerializeField] string[] requiredItems; 

    [Header("Slots")]
    [SerializeField] Image[] ingredientSlots;   // UI Image slots showing placed items
    [SerializeField] Sprite emptySlotSprite;

    [Header("Output")]
    [SerializeField] Image outputSlot;
    [SerializeField] Sprite keySprite;
    [SerializeField] TextMeshProUGUI craftButtonText;
    [SerializeField] Item keyItem;  

    [SerializeField] GameObject dimOverlay;

    bool[] slotFilled;

    void OnEnable()
    {
        slotFilled = new bool[ingredientSlots.Length];
        RefreshSlots();
        CheckAutoFill();
    }

    // Autofills slots with items player already has
    void CheckAutoFill()
    {
        for (int i = 0; i < requiredItems.Length; i++)
        {
            if (i >= ingredientSlots.Length) break;

            if (PlayerInventory.instance.HasItem(requiredItems[i]))
            {
                Item item = PlayerInventory.instance.items.Find(x => x.itemName == requiredItems[i]);
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

    // Consume ingredients
    foreach (string itemName in requiredItems)
        PlayerInventory.instance.RemoveItem(itemName);

    // Add key to inventory\
    PlayerInventory.instance.AddItem(keyItem);

    // Show key in output slot
    outputSlot.sprite = keySprite;
    outputSlot.color = Color.white;

    // Clear slots
    slotFilled = new bool[ingredientSlots.Length];
    RefreshSlots();
}

    public void OnClosePressed()
    {
        gameObject.SetActive(false);
        dimOverlay.SetActive(false);
    }
}