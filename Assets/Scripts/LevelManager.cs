using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    int sceneNum;
    public SceneFader sceneFader;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        sceneNum = SceneManager.GetActiveScene().buildIndex + 1;
    }
    public void NextLevel()
    {
        sceneFader.Fade();
        SceneManager.LoadScene(sceneNum);
        Time.timeScale = 1;
    }
    public void Menu()
    {
        SceneManager.LoadScene(0);
        sceneFader.Fade();
    }
}
