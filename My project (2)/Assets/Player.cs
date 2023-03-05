using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.InputSystem;
using UnityEngine.XR.Interaction.Toolkit;

public class Player : MonoBehaviour
{   
    [SerializeField] float helth, maxHealth = 10f;
    [SerializeField] public Image bar;
    [SerializeField] public Image hilkibar;
    [SerializeField] public Image manabar;
    [SerializeField] public Image manahilci;
    public InputActionProperty heelButton;
    public InputActionProperty manaButton;
    public InputActionProperty fireBalAction;
    public InputActionProperty metiorAction;
    public Transform metiorSpawn;
    public GameObject muve;
    public ContinuousMovementPhysics ContinuousMovementPhysicsPlayer;
    public float mana = 100f;
    private float hpbar = 1;
    public bool death = false;
    public GameObject deathmeny;
    public int valueHil = 10;
    public float pop = 0f;
    public float manapop = 0f;
    public float manahilki = 0f;
    public float hilki = 0f;
    public Transform spavnPoint;
    public GameObject fireBool;
    public float power;
    public GameObject metior;
    




    private void Start() 
    {
        helth = maxHealth;
        mana = 100f;
    }
    void Update()
    {
        if (heelButton.action.WasPressedThisFrame())
        {
            Usehilca();
        }
        if (manaButton.action.WasPressedThisFrame())
        {
            UseMana();
        }
        if (fireBalAction.action.WasPressedThisFrame())
        {
            if (mana >= 15)
            {
                Faerbal();
            }
        }
        if (metiorAction.action.WasPressedThisFrame())
        {
            if (mana >= 50)
            {
                Metior();
            }
        
        }
    }
    public void PlayerTakeDamage(float edamageAmount)
    {
        helth -= edamageAmount;
        hpbar -= edamageAmount / maxHealth;
        bar.fillAmount = hpbar;
        if (helth <= 0) 
        {
            death = true;
            Death();
            ContinuousMovementPhysicsPlayer = muve.GetComponent<ContinuousMovementPhysics>();
            ContinuousMovementPhysicsPlayer.enabled = false;
        }
    }
    public void Death()
    {
        if (death == true)
        {
            deathmeny.SetActive(!deathmeny.activeSelf);
            helth = maxHealth;
            hilki = 0f;
        }
    }
    public void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.tag == "HIL")
        {
            if (hilki < 5)
            {
                hilki += 1;
                pop = hilki * 0.2f;
                hilkibar.fillAmount = pop;
                Destroy(collider.gameObject);
            }
            else if (hilki >= 5)
            {
                Destroy(collider.gameObject);
            }
          
        }
        if (collider.gameObject.tag == "mana")
        {
            if (manahilki < 5)
            {
                manahilki += 1;
                manapop = manahilki * 0.2f;
                manahilci.fillAmount = manapop;
                Destroy(collider.gameObject);
            }
            else if (manahilki >= 5)
            {
                Destroy(collider.gameObject);
            }


        }
    }
    
    
    public void Usehilca()
    {
        if (hilki != 0)
        {
            hilki -= 1;
            pop = hilki * 0.2f;
            hilkibar.fillAmount = pop;
            helth += 10;
            bar.fillAmount = helth / 100f;
        }
    }
    public void Faerbal()
    {
        
        
            GameObject fire = Instantiate(fireBool);
            fire.transform.position = spavnPoint.position;
            fire.GetComponent<Rigidbody>().velocity = spavnPoint.forward * power;
            Destroy(fire, 15);
            mana -= 15;
            manabar.fillAmount = mana / 100f;
        
    }
    public void UseMana()
    {
        if (manahilki != 0)
        {
            manahilki -= 1;
            manapop = manahilki * 0.2f;
            manahilci.fillAmount = manapop;
            mana += 30;
            manabar.fillAmount = mana / 100f;
        }
    }
    public void Metior()
    {
        GameObject metior1 = Instantiate(metior);
        metior1.transform.position = metiorSpawn.position;
        Destroy(metior1, 20);
        mana -= 50;
        manabar.fillAmount = mana / 100f;
    }
}

