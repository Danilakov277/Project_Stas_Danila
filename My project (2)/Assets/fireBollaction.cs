using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fireBollaction : MonoBehaviour
{
    public GameObject explo;
    public int damage = 8;
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.TryGetComponent<Enemy>(out Enemy enemyComponent))
        {
            explo.SetActive(true);
            enemyComponent.TakeDamage(damage);
            Destroy(gameObject, 0.1f);

        }


    }

}
