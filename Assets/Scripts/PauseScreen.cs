using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseScreen : MonoBehaviour
{
    public GameObject pauseScreen;
    bool isPaused = false;
    public SceneFader sceneFader;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && !isPaused)
        {
            Pause();
            isPaused = true;
            return;
        }
        if (Input.GetKeyDown(KeyCode.Escape) && isPaused)
        {
            Resume();
            isPaused = false;
            return;
        }
    }
    public void Retry()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        Time.timeScale = 1;
        sceneFader.Fade();
    }
    public void Menu()
    {
        SceneManager.LoadScene(0);
        sceneFader.Fade();
    }
    public void Resume()
    {
        pauseScreen.SetActive(false);
        Time.timeScale = 1;
        isPaused = false;
    }
    public void Pause()
    {
        pauseScreen.SetActive(true);
        Time.timeScale = 0;
        isPaused = true;
    }
}
