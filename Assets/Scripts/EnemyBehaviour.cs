using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehaviour : MonoBehaviour
{
    public GameObject playerStats;
    int health = 2;
    Vector3 ballDir = new Vector3(0,7f,-6f);
    public float power = 5f;

    public float dir = 0;
    float step;
    public float speed = 1.0f;
    float curr_x_pos;
    float curr_y_pos;

    void Start() 
    {
        step = speed * Time.deltaTime;
        dir = step;
        curr_x_pos = transform.position.x;
    }

    void Update() 
    {
        if(transform.position.x > curr_x_pos + 2) {
            dir = -step;
        }
        if(transform.position.x < curr_x_pos - 2) {
            dir = step;
        }

        transform.Translate(dir, 0, 0);
    }
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
