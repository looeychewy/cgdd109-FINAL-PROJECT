using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    [SerializeField] string gameSceneName = "LevelOne"; 

    public void OnPlayPressed()
    {
        SceneManager.LoadScene(gameSceneName);
    }

}