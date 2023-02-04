using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private Transform target;
    public float bulletSpeed = 70;
    public float expRadius = 0;
    public GameObject bulletEffect;
    public int damage = 50;

    public void Look(Transform _target)
    {
        target = _target;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(target == null)
        {
            Destroy(gameObject);
            return;
        }

        Vector3 dir = target.position - transform.position;
        float distance = bulletSpeed * Time.deltaTime;

        if (dir.magnitude <= distance)
        {
            HitTarget();
            return;
        }
        transform.Translate(dir.normalized * distance, Space.World);
        transform.LookAt(target);
    }

    void HitTarget()
    {
        GameObject bEff = (GameObject)Instantiate(bulletEffect, transform.position, transform.rotation);
        Destroy(bEff, 6);

        if(expRadius > 0)
        {
            Explode();
        }
        else
        {
            Damage(target);
        }
        Destroy(gameObject);
    }

    void Explode()
    {
        Collider[] colliders = Physics.OverlapSphere(transform.position, expRadius);
        foreach (Collider collider in colliders)
        {
            if (collider.tag == "Enemy")
            {
                Damage(collider.transform);
            }
        } 
    }

    void Damage(Transform enemy)
    {
        Enemy e = enemy.GetComponent<Enemy>();

        if(e != null)
            e.GetDamage(damage);
    }
}
