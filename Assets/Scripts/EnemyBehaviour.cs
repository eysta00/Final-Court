using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehaviour : MonoBehaviour
{
    public GameObject playerStats;
    int health = 100;
    Vector3 ballDir = new Vector3(0,7f,-6f);
    public float power = 5f;
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Ball")) {
            ballDir.x = Random.Range(-2f,2f);
            other.GetComponent<Rigidbody>().velocity = ballDir.normalized * power;
            
            
            if (health > 0) { // If he gets hit and has more than one life, lives gets deducted
                health -= 1;
            }
            else {
                Destroy(gameObject);
            }

        }
    }
}
