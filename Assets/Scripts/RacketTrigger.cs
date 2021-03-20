using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RacketTrigger : MonoBehaviour
{
    private PlayerController playerScript;
    void Start()
    {
        playerScript = GetComponentInParent<PlayerController>();
    }
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Ball")){
            playerScript.ballInRange = true;
        }
    }
    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Ball")){
            playerScript.ballInRange = false;
        }
    }
}
