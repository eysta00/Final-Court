using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MolotovBehaviour : MonoBehaviour
{
    // Start is called before the first frame update

    Vector3 ballDir = new Vector3(0,7f,-6f);
    public float power = 5f;
    void Start()
    {
        ballDir.x = Random.Range(-2f,2f);
        GetComponent<Rigidbody>().velocity = ballDir.normalized * power;
    }

    // Update is called once per frame
    void Update()
    {
        // ballDir.x = Random.Range(-2f,2f);
        // GetComponent<Rigidbody>().velocity = ballDir.normalized * power;
    }

    void OnTriggerEnter(Collider other)
    {
        
    }
}
