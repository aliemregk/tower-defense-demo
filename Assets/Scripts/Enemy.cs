using UnityEngine;
using UnityEngine.UI;

public class Enemy : MonoBehaviour
{
    public float speed = 10f;
    public static int money;
    public int Money;

    public GameObject deathEffect;
    public Image healthBar;
    public float health;
    private float startHealth;

    [HideInInspector]
    public float baseSpeed;
    public bool isSlowed = false;
    private void Start()
    {
        baseSpeed = speed;
        startHealth = health;
    }
    private void Update()
    {
        money = Money;
    }
    public void GetDamage(float amount)
    {
        health -= amount;
        healthBar.fillAmount = health / startHealth;

        if (health <= 0)
        {
            Die();
        }
    }
    void Die()
    {
        PlayerStats.money += Enemy.money;

        GameObject eDE = (GameObject)Instantiate(deathEffect, transform.position, Quaternion.identity);
        Destroy(eDE, 3);
        Destroy(gameObject);
        WaveSpawner.enemiesAlive--;
    }
    public void Slow(float slowRate)
    {
        if(isSlowed == false)
        {
            speed *= slowRate;
            isSlowed = true;
        }
        
    }
}
