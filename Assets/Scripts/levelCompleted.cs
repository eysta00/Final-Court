using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class levelCompleted : MonoBehaviour
{
    public bool completed = false;

    // Update is called once per frame
    void Update()
    {
        if(this.gameObject.transform.childCount == 0) {
            completed = true;
        }
    }
}
