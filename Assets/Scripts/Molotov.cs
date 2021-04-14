using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Molotov : MonoBehaviour
{
    // Start is called before the first frame update
    public float initial_cooldown;
    float cooldown;

    public GameObject Molo; // molotov
    public Vector3 whereToSpawn;
    
    public EnemyBehaviour enemyLoc;

    void Start()
    {
        cooldown = initial_cooldown + Random.Range(0,5);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void FixedUpdate()
    {
        cooldown -= Time.deltaTime;
        if(cooldown < 0.0f) {
            cooldown += initial_cooldown + Random.Range(5,10);
            whereToSpawn = enemyLoc.GetComponent<EnemyBehaviour>().transform.position;
            Instantiate(Molo, whereToSpawn, Quaternion.identity);
        }
        
    }
}
