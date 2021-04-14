using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletBehaviour : MonoBehaviour
{
    private Rigidbody rB;
    public int damage = 5;

    public int bulletSpeed;

    Vector3 BulletDir = new Vector3(0,0,-15f);

    Vector3 initalPos;

    public int fireRate = 50;
    
    public int fireIn;

    public GameObject myEnemy;
    // Update is called once per frame

    void Start()
    {
        initalPos = new Vector3(0,-100,0);
        EnemyBehaviour EnemyController = myEnemy.GetComponent<EnemyBehaviour>();
        rB = GetComponent<Rigidbody>();
        rB.transform.position = initalPos;
        fireIn = fireRate;
    }

    void FixedUpdate()
    {
        if(fireIn <= 0){
            Vector3 new_pos = myEnemy.transform.position;
            new_pos.z-=0.5f;
            new_pos.y+=0.5f;
            rB.transform.position = new_pos;
            BulletDir.x = Random.Range(-2f,2f); 
            rB.velocity = BulletDir.normalized*bulletSpeed;
            fireIn = fireRate;
        }
        fireIn--;
    }

    void OnCollisionEnter(Collision collisionInfo)
    {
        if(collisionInfo.GetContact(0).otherCollider.tag == "Player"){
            collisionInfo.GetContact(0).otherCollider.gameObject.GetComponent<PlayerController>().Health -= damage;
            rB.velocity =  Vector3.zero;
            rB.transform.position = initalPos;
        }
    }

}
