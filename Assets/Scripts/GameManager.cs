using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static bool IsOver;
    public GameObject gameOverUI;
    public GameObject levelPassedUI;
    public GameObject endGame;

    // Start is called before the first frame update
    void Start()
    {
        IsOver = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (PlayerStats.live <= 0 && !IsOver)
        {
            EndGame();
        }

        // DELETE ****************************
        if (Input.GetKeyDown("e"))
        {
            EndGame();
        }
        if (Input.GetKeyDown("r"))
        {
            Succeed();
        }
        // DELETE ****************************
    }
    private void EndGame()
    {
        IsOver = true;
        Time.timeScale = 0;
        gameOverUI.SetActive(true);
    }
    public void Succeed()
    {
        if (SceneManager.GetActiveScene().buildIndex == 5)
        {
            Time.timeScale = 0;
            endGame.SetActive(true);
            IsOver = true;
        }
        else
        {
            IsOver = true;
            Time.timeScale = 0;
            levelPassedUI.SetActive(true);
        }
    }
}
