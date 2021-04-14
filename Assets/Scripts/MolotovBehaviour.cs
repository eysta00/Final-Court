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
    public Transform player;

    void Start()
    {

        ballDir = player.position;
        GetComponent<Rigidbody>().velocity = (ballDir + new Vector3(0,5,0));
    }

    void Update()
    {
        whereToSpawn = GetComponent<Rigidbody>().transform.position;

    }

    void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "PlayerSide") {
            Destroy(gameObject);
            whereToSpawn = GetComponent<Rigidbody>().transform.position;
            whereToSpawn.y = 0.01f;
            Instantiate(dmgZone, whereToSpawn, Quaternion.identity);
        }
    }
}
