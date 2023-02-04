using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turret : MonoBehaviour
{
    private Transform target;
    private Enemy enemy;

    public float range = 8;
    public float fireRate = 1;
    private float fireCountdown = 0;

    public bool useLaser = false;
    public LineRenderer linerender;
    public ParticleSystem Impact;
    public Light ImpactLight;
    public int dmgOverTime = 30;
    public float slow = .5f;

    public string enemyTag = "Enemy";
    public Transform partToRotate;
    public float turnSpeed = 10;

    public GameObject bullet;
    public Transform muzzle;

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("FindTarget", 0f, 0.5f);
    }

    void FindTarget() 
    {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag(enemyTag);
        float shortestDistance = Mathf.Infinity;
        GameObject nearestEnemy = null;

        foreach(GameObject enemy in enemies)
        {
            float distanceToEnemy = Vector3.Distance(transform.position, enemy.transform.position);
            if(distanceToEnemy < shortestDistance)
            {
                shortestDistance = distanceToEnemy;
                nearestEnemy = enemy;
            }
        }
        if(nearestEnemy != null && shortestDistance <= range)
        {
            target = nearestEnemy.transform;
            enemy = nearestEnemy.GetComponent<Enemy>();
        }
        else
        {
            target = null;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (target == null)
        {
            if (useLaser)
            {
                if (linerender.enabled)
                {
                    linerender.enabled = false;
                    Impact.Stop();
                    ImpactLight.enabled = false;
                }
            }
            return;
        }

        LockTarget();

        if (useLaser)
        {
            Laser();
        }
        else
        {
            if (fireCountdown <= 0)
            {
                Shoot();
                fireCountdown = 1 / fireRate;
            }
            fireCountdown -= Time.deltaTime;
        }
    }
    void Shoot()
    {
        GameObject bulletObj = (GameObject)Instantiate(bullet, muzzle.position, muzzle.rotation);
        Bullet bulletcs = bulletObj.GetComponent<Bullet>();

        if(bulletcs != null)
        {
            bulletcs.Look(target);
        }
    }
    void Laser()
    {
        enemy.GetDamage(dmgOverTime * Time.deltaTime);
        enemy.Slow(slow);

        if (!linerender.enabled)
        {
            enemy.speed *= slow;
            linerender.enabled = true;
            Impact.Play();
            ImpactLight.enabled = true;
        }

        linerender.SetPosition(0, muzzle.position);
        linerender.SetPosition(1, target.position);

        Vector3 dir = muzzle.position - target.position;
        
        Impact.transform.position = target.position + dir.normalized * 1.0f;
        Impact.transform.rotation = Quaternion.LookRotation(dir);
    }

    void LockTarget()
    {
        Vector3 dir = target.position - transform.position;
        Quaternion look = Quaternion.LookRotation(dir);
        Vector3 rotation = Quaternion.Lerp(partToRotate.rotation, look, Time.deltaTime * turnSpeed).eulerAngles;
        partToRotate.rotation = Quaternion.Euler(0, rotation.y, 0);
    }

}
