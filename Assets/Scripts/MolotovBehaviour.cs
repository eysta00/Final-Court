using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MolotovBehaviour : MonoBehaviour
{

    Vector3 ballDir;
    public float power = 5f;

    public GameObject dmgZone; // damage zone
    public Vector3 whereToSpawn;
    //public Molotov enemyLoc;

    [Header("Put the player and enemy here")]
    Transform player;

    void Awake()
    {
        
        player = GameObject.FindGameObjectWithTag("Player").transform;
        // Random.Range(-3f,3f)
        //GetComponent<Rigidbody>().velocity = (ballDir + new Vector3(0,5,0) * 0.5f);
        ballDir = player.position - transform.position;
        GetComponent<Rigidbody>().velocity = (ballDir + new Vector3(0,5,0) * 0.5f);
    }

    void Update()
    {
        whereToSpawn = transform.position;
    }

    void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "PlayerSide") {
            Destroy(gameObject);
            whereToSpawn = transform.position;
            whereToSpawn.y = 0.01f;
            Instantiate(dmgZone, whereToSpawn, Quaternion.identity);
        }
    }
}
