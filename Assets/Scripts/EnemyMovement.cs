using UnityEngine;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(Enemy))]
public class EnemyMovement : MonoBehaviour
{
    private Transform target;
    private int wavePointIndex = 0;
    private Enemy enemysc;

    public Transform rotatingPart;
    public Transform healthBar;

    // Start is called before the first frame update
    void Start()
    {
        enemysc = GetComponent<Enemy>();
        target = Waypoints.waypoints[0];
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 direction = target.position - transform.position;
        transform.Translate(direction.normalized * enemysc.speed * Time.deltaTime, Space.World);

        enemysc.speed = enemysc.baseSpeed;
        enemysc.isSlowed = false;

        if (Vector3.Distance(transform.position, target.position) <= 0.4f)
        {
            if (SceneManager.GetActiveScene().buildIndex == 0)
            {
                switch (wavePointIndex)
                {
                    case 0:
                    case 3:
                        Turn2();
                        break;

                    case 1:
                    case 2:
                        Turn1();
                        break;

                    default:
                        break;
                }

            }
            if (SceneManager.GetActiveScene().buildIndex == 1)
            {
                switch (wavePointIndex)
                {
                    case 0:
                    case 1:
                    case 4:
                    case 7:
                    case 8:
                        Turn2();
                        break;

                    case 2:
                    case 3:
                    case 5:
                    case 6:
                        Turn1();
                        break;

                    default:
                        break;
                }
                
            }
            if (SceneManager.GetActiveScene().buildIndex == 2)
            {
                switch (wavePointIndex)
                {
                    case 2:
                    case 3:
                    case 4:
                        Turn2();
                        break;

                    case 0:
                    case 1:
                    case 5:
                        Turn1();
                        break;

                    default:
                        break;
                }
            }
            if (SceneManager.GetActiveScene().buildIndex == 3)
            {
                switch (wavePointIndex)
                {
                    case 2:
                    case 3:
                    case 4:
                    case 7:
                        Turn2();
                        break;

                    case 0:
                    case 1:
                    case 5:
                    case 6:
                        Turn1();
                        break;

                    default:
                        break;
                }
            }
            if (SceneManager.GetActiveScene().buildIndex == 4)
            {
                switch (wavePointIndex)
                {
                    case 2:
                    case 3:
                    case 4:
                        Turn2();
                        break;

                    case 0:
                    case 1:
                    case 5:
                    case 6:
                        Turn1();
                        break;

                    default:
                        break;
                }
            }
            if (SceneManager.GetActiveScene().buildIndex == 5)
            {
                switch (wavePointIndex)
                {
                    case 3:
                    case 4:
                    case 6:
                    case 7:
                    case 8:
                        Turn2();
                        break;

                    case 0:
                    case 1:
                    case 2:
                    case 5:
                    case 9:
                    case 10:
                    case 11:
                        Turn1();
                        break;

                    default:
                        break;
                }
            }
            GetNextWaypoint();
        }
    }

    void GetNextWaypoint()
    {
        if (wavePointIndex >= Waypoints.waypoints.Length - 1)
        {
            GiveDamage();
            return;
        }

        wavePointIndex++;
        target = Waypoints.waypoints[wavePointIndex];
    }
    void Turn1()
    {
        rotatingPart.Rotate(0, 90, 0);
    }
    void Turn2()
    {
        rotatingPart.Rotate(0, -90, 0);
    }
    public void GiveDamage()
    {
        PlayerStats.live -= 1;
        Destroy(gameObject);
    }
}
