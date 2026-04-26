using UnityEngine;

public class CraftingStation : MonoBehaviour
{
    [SerializeField] GameObject craftingUI;
    [SerializeField] GameObject dimOverlay;

    bool playerNearby = false;

    void Update()
    {
        if (playerNearby && Input.GetKeyDown(KeyCode.E))
        {
            bool isOpen = craftingUI.activeSelf;
            craftingUI.SetActive(!isOpen);
            dimOverlay.SetActive(!isOpen);
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            playerNearby = true;
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            playerNearby = false;
            craftingUI.SetActive(false);
            dimOverlay.SetActive(false);
        }
    }
}