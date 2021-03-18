using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallBehaviour : MonoBehaviour
{
    Vector3 initalPos;
    public Vector3 playArea;

    //public int damage = 25;
    // Initial pos of ball
    // Bounce effect on ball
    // Collision detection
    //public EnemyHealth enemyHealth;

    void Start()
    {
        initalPos = transform.position; // Get the inital pos (Need to actually teleport to the player. Not IntialPos)
    }
    public bool isBallInPlayArea() {
        if ((transform.position.x<playArea.x && transform.position.x>-playArea.x) 
        && (transform.position.z<playArea.z && transform.position.z>-playArea.z)
        && (transform.position.y<playArea.y && transform.position.y>-playArea.y)) {
            return true;}
        else {
            return false;}
    }
    void Update()
    {
        if (!isBallInPlayArea()) {
            GetComponent<Rigidbody>().velocity = Vector3.zero;
            transform.position = initalPos;
        }
    }
    void OnCollisionEnter(Collision collision)
    {  
        if (collision.transform.CompareTag("Wall"))
        {
            GetComponent<Rigidbody>().velocity = Vector3.zero;
            transform.position = initalPos;
        }
        
    }

    // void OnTriggerEnter(Collider other)
    // {
        
    //     if(other.gameObject.tag == "Enemy")
    //     {
    //         GetComponent<Rigidbody>().velocity = Vector3.zero;
    //         // transform.position = initalPos;
    //         other.GetComponent<EnemyHealth>().health -= damage;
    //     }
    // }
}
