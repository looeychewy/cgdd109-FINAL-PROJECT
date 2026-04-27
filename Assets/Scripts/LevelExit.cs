using UnityEngine;

public class LevelExit : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            if (PlayerInventory.instance.HasItem("Key"))
                LevelComplete.instance.ShowLevelComplete();
            else
                Debug.Log("Need the key to exit!");
        }
    }
}