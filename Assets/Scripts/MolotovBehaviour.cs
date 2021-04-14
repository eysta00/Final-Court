using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MolotovBehaviour : MonoBehaviour
{

    Vector3 ballDir = new Vector3(0,7f,-6f);
    public float power = 5f;

    public GameObject dmgZone; // damage zone
    public Vector3 whereToSpawn;
    //public Molotov enemyLoc;

    void Start()
    {
        ballDir.x = Random.Range(-2f,2f);
        GetComponent<Rigidbody>().velocity = ballDir.normalized * power;
    }

    void FixedUpdate()
    {
        whereToSpawn = GetComponent<Rigidbody>().transform.position;

    }

    void Update()
    {

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
