using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class restart : MonoBehaviour
{
    public GameObject move;
    public PhisicRig PhisicRigPlayer;
    public void Restart()
    {
        PhisicRigPlayer = move.GetComponent<PhisicRig>();
        PhisicRigPlayer.enabled = true;
        SceneManager.LoadScene("Start");
    }
}
