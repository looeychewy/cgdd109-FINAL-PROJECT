using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelComplete : MonoBehaviour
{
    [SerializeField] GameObject levelCompletePanel;
    [SerializeField] ConfettiEffect confetti;
    [SerializeField] string nextLevelName; // Set this in the Inspector per scene

    public static LevelComplete instance;

    void Awake()
    {
        instance = this;
        levelCompletePanel.SetActive(false);
    }

    public void ShowLevelComplete()
    {
        foreach (AudioSource audio in FindObjectsOfType<AudioSource>())
            audio.Stop();

        AudioListener.pause = true;

        if (confetti != null) confetti.Play();
        levelCompletePanel.SetActive(true);
        StartCoroutine(FreezeAfterDelay());
    }

    IEnumerator FreezeAfterDelay()
    {
        yield return new WaitForSecondsRealtime(0.5f);
        Time.timeScale = 0f;
    }

    public void OnRestartPressed()
    {
        AudioListener.pause = false;
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void OnMainMenuPressed()
    {
        AudioListener.pause = false;
        Time.timeScale = 1f;
        SceneManager.LoadScene("MainMenu");
    }

    public void OnNextLevelPressed()
    {
        AudioListener.pause = false;
        Time.timeScale = 1f;
        SceneManager.LoadScene(nextLevelName);
    }
}