using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class moloTime : MonoBehaviour
{
    // Start is called before the first frame update
    public float dmgTime;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void FixedUpdate()
    {
        dmgTime -= Time.deltaTime;
        if(dmgTime < 0) {
            Destroy(gameObject);
        }
    }
}
