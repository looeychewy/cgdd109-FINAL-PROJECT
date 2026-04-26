using UnityEngine;

public class InventoryToggle : MonoBehaviour
{
    [SerializeField] GameObject inventoryPanel;
    [SerializeField] KeyCode toggleKey = KeyCode.Tab;

    void Update()
    {
        if (Input.GetKeyDown(toggleKey))
        {
            bool isOpen = inventoryPanel.activeSelf;
            inventoryPanel.SetActive(!isOpen);

            if (!isOpen)
                inventoryPanel.GetComponent<InventoryUI>().RefreshUI();
        }
    }
}