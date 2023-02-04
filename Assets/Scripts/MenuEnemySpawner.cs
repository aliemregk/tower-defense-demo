using System.Collections;
using UnityEngine;

public class MenuEnemySpawner : MonoBehaviour
{
    public Transform spawnPoint;
    public Transform enemy;
    public float timeBtwnWaves = 4f;
    private float timer = 2f;
    public int waveNum = 0;

    // Start is called before the first frame update
    private void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (timer <= 0f)
        {
            StartCoroutine(Spawn());
            timer = timeBtwnWaves;
        }

        timer -= Time.deltaTime;
        timer = Mathf.Clamp(timer, 0, Mathf.Infinity);
    }
    IEnumerator Spawn()
    {
        SpawnEnemy();
        yield return new WaitForSeconds(0.6f);
    }
    void SpawnEnemy()
    {
        Instantiate(enemy, spawnPoint.position, spawnPoint.rotation);
    }
}
