
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using System.Collections;

public class GameMeny : MonoBehaviour
{
    public GameObject menu;
    public InputActionProperty showButton;
    void Update()
    {
        if (showButton.action.WasPressedThisFrame())
        {
            menu.SetActive(!menu.activeSelf);
        }
    }
}
