using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Edamege : MonoBehaviour
{
    public int edamege = 1;
    public GameObject plauer;
    public Player Player1;
    
    private void OnCollisionEnter(Collision collision)
    {
        Player1 = plauer.GetComponent<Player>();
        if (collision.gameObject.tag == "PLAUER")
        {
            
            Player1.PlayerTakeDamage(edamege);
        }
    }
}
