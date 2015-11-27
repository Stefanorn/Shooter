using UnityEngine;
using System.Collections;
using System;

public class DamageHandler : MonoBehaviour {

    public float health = 1f;
    public float RespawnTimer = 10f;

    private float initialHealth;

    void Start()
    {
        initialHealth = health;
    }

    void WasShoot(int damage)
    {
        health -= damage;
        if (health <= 0)
        {
            gameObject.SetActive(false);
            DestroyTheEnemy();
        }
    }

    private void DestroyTheEnemy()
    {
        gameObject.SetActive(false);
        Invoke("Respawn", RespawnTimer);
    }
    private void Respawn()
    {
        health = initialHealth;
        gameObject.SetActive(true);
    }
}
