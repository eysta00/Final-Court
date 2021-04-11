using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class raiseOptions : MonoBehaviour
{
    // Start is called before the first frame update
    public levelCompleted done;
    float rise;
    void Start()
    {
        rise = 0.5f * Time.deltaTime;
    }

    // Update is called once per frame
    void Update()
    {
        if(done.GetComponent<levelCompleted>().completed == true) {
            if(transform.position.y < 1) {
                transform.Translate(0,rise,0);
            }
        }
    }
}
