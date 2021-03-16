using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallBehaviour : MonoBehaviour
{
    Vector3 initalPos;

    // Initial pos of ball
    // Bounce effect on ball
    // Collision detection

    void Start()
    {
        initalPos = transform.position; // Get the inital pos (Need to actually teleport to the player. Not IntialPos)
    }

    void OnCollisionEnter(Collision collision)
    {  
        if (collision.transform.CompareTag("Wall"))
        {
            GetComponent<Rigidbody>().velocity = Vector3.zero;
            transform.position = initalPos;
        }
        
    }
}
