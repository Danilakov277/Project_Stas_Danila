using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
public class Enemy : MonoBehaviour
{
    [SerializeField] float health, maxHealth = 3f;
    // Start is called before the first frame update
    private void Start()
    {
        health = maxHealth;
    }

    public void TakeDamage(float damageAmount)
    {
        health -= damageAmount;
        if (health <= 0) {
            Destroy(gameObject);
        }
    }
}
