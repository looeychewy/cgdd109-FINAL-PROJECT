using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class InventoryUI : MonoBehaviour
{
    [SerializeField] Transform slotContainer;
    [SerializeField] GameObject slotPrefab;
    [SerializeField] KeyCode toggleKey = KeyCode.Tab;

    GameObject panel;
    List<GameObject> spawnedSlots = new List<GameObject>();

    void Awake()
    {
        panel = gameObject;
        panel.SetActive(false);
    }

    public void RefreshUI()
    {
        foreach (GameObject slot in spawnedSlots)
            Destroy(slot);
        spawnedSlots.Clear();

        foreach (Item item in PlayerInventory.instance.items)
        {
            GameObject slot = Instantiate(slotPrefab, slotContainer);

            // icon
            slot.GetComponent<Image>().sprite = item.icon;

            // label underneath
            TextMeshProUGUI label = slot.GetComponentInChildren<TextMeshProUGUI>();
            if (label != null)
                label.text = item.itemName;

            spawnedSlots.Add(slot);
        }
    }
}