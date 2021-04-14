using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class hearts : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject h1;
    public GameObject h2;
    public GameObject h3;

    public PlayerController PC;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(PC.GetComponent<PlayerController>().Health == 2) {
            Destroy(h3);
        }
        if(PC.GetComponent<PlayerController>().Health == 1) {
            Destroy(h2);
        }
        if(PC.GetComponent<PlayerController>().Health == 0) {
            Destroy(h1);
        }
    }
}
