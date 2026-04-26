using UnityEngine;

public class CraftingStation : MonoBehaviour
{
    [SerializeField] GameObject craftingUI;
    bool playerNearby = false;

    void Update()
    {
        if (playerNearby && Input.GetKeyDown(KeyCode.E))
        {
            bool isOpen = craftingUI.activeSelf;
            craftingUI.SetActive(!isOpen);
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
            playerNearby = true;
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            playerNearby = false;
            craftingUI.SetActive(false);
        }
    }
}