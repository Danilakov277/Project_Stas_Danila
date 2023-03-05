using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class exploDamage : MonoBehaviour
{
    public int exploDamag = 10;
    // Start is called before the first frame update
    private void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.TryGetComponent<Enemy>(out Enemy enemyComponent))
        {
            enemyComponent.TakeDamage(exploDamag);

        }
    }
}
