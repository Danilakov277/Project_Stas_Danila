using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class demege : MonoBehaviour
{
    public int damege = 1;
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.TryGetComponent<Enemy>(out Enemy enemyComponent))
        {
            enemyComponent.TakeDamage(damege);
        }
        Destroy(gameObject);
    }
}
