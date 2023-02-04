using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class WaveSpawner : MonoBehaviour
{
    public static int Round;
    public static int enemiesAlive = 0;

    public Transform spawnPoint;
    public Wave[] waves;
    public Text WaveTimer;
    public Text Money;
    public Text Health;
    
    public float timeBtwnWaves = 6f;
    private float timer = 4f;
    public int waveNum = 0;
    public GameManager gameMng;

    // Start is called before the first frame update
    private void Start()
    {
        Round = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if(timer <= 0f && waveNum <= 22)
        {
            StartCoroutine(Spawn());
            timer = timeBtwnWaves;
        }
        if (waveNum == waves.Length && enemiesAlive == 0)
        {
            gameMng.Succeed();
            return;
        }

        timer -= Time.deltaTime;

        timer = Mathf.Clamp(timer, 0, Mathf.Infinity);
        WaveTimer.text = string.Format("{0:00.00}", timer);

        Money.text = PlayerStats.money.ToString();
        Health.text = PlayerStats.live.ToString();
    }
    IEnumerator Spawn()
    {
        if (waveNum != waves.Length)
        {
            Round++;
            Wave wave = waves[waveNum];

            for (int i = 0; i < wave.enemyCount; i++)
            {
                SpawnEnemy(wave.enemy);
                yield return new WaitForSeconds(1f / wave.spawnRate);
            }
            waveNum++;
        }
    }
    void SpawnEnemy(GameObject enemy)
    {
        if(SceneManager.GetActiveScene().buildIndex == 4)
        {
            Instantiate(enemy, spawnPoint.position, Quaternion.Euler(0, 270, 0));
        }
        else if(SceneManager.GetActiveScene().buildIndex == 5)
        {
            Instantiate(enemy, spawnPoint.position, Quaternion.Euler(0, 270, 0));
        }
        else
        {
            Instantiate(enemy, spawnPoint.position, spawnPoint.rotation);
        }
        enemiesAlive++;
    }
}
