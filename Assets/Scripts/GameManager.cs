using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    [SerializeField] TMP_Text scoreText;
    int score = 0;
    int totalTargets = 0;

    void Start()
    {
        totalTargets = FindObjectsOfType<TargetInteractable>().Length;
        scoreText.text = "Parts collected: 0/" + totalTargets;
    }

    public void TargetCollected()
    {
        score += 1;
        
        if (score >= totalTargets)
            scoreText.text = "All parts collected!";
        else
            scoreText.text = "Parts collected: " + score + " / " + totalTargets;
    }
}
