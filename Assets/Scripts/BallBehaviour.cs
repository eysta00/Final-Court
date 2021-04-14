using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallBehaviour : MonoBehaviour
{
    public Vector3 initalPos;
    public Vector3 playArea;

    public GameObject myPlayer;
    private PlayerController PlayerController;
    private Rigidbody rB;
    public bool isServing;
    int rand;

    public float total_score;
    public float combo = 1.0f;
    float enemyHitScore = 100;
    int EnemySideBounce = 0;
    //public int damage = 25;
    // Initial pos of ball
    // Bounce effect on ball
    // Collision detection
    //public EnemyHealth enemyHealth;

    void Start()
    {
        //initalPos = myPlayer.transform.position; // Get the inital pos (Need to actually teleport to the player. Not IntialPos)
        PlayerController = myPlayer.GetComponent<PlayerController>();
        rB = GetComponent<Rigidbody>();
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
            rand = Random.Range(-2,2);
            initalPos.x += rand;
            transform.position = initalPos;
            initalPos.x -= rand;
            GetComponent<Rigidbody>().velocity = Vector3.zero;
            combo = 1;
            // PlayerController.isServing = true;
            // PlayerController.currBall = this.gameObject;
            // this.enabled = false;
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "EnemySide")
        {
            EnemySideBounce += 1;
            if(EnemySideBounce >= 5) {
                rand = Random.Range(-2,2);
                initalPos.x += rand;
                transform.position = initalPos;
                initalPos.x -= rand;
                GetComponent<Rigidbody>().velocity = Vector3.zero;
                combo = 1;
            }
        }

        if(other.gameObject.tag == "PlayerSide")
        {
            EnemySideBounce = 0;
        }

        if(other.gameObject.tag == "Enemy")
        {
            EnemySideBounce = 0;
            //GetComponent<Rigidbody>().velocity = Vector3.zero;
            //transform.position = initalPos;
            other.GetComponent<EnemyHealth>().health -= 34;
            total_score += combo * enemyHitScore;
            if(combo < 2) { combo += 0.5f; }
            else if(combo < 3) { combo += 0.25f; }
            else if(combo < 4) { combo += 0.2f; }
            else if(combo < 5) { combo += 0.1f; } // Max verður 5
        }

        if(other.gameObject.tag == "HealthRegEnemy")
        {
            EnemySideBounce = 0;
            //GetComponent<Rigidbody>().velocity = Vector3.zero;
            //transform.position = initalPos;
            Debug.Log(other.GetComponent<EnemyHealth>().health);
            other.GetComponent<EnemyHealth>().health -= 50;
            Debug.Log(other.GetComponent<EnemyHealth>().health);
            total_score += combo * enemyHitScore;
            if(combo < 2) { combo += 0.5f; }
            else if(combo < 3) { combo += 0.25f; }
            else if(combo < 4) { combo += 0.2f; }
            else if(combo < 5) { combo += 0.1f; } // Max verður 5
        }
    }
}
