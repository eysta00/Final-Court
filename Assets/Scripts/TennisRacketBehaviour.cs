using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TennisRacketBehaviour : MonoBehaviour
{
    // We need a target for the ball to go, One Idea is an invisble object that moves along x,z according to the mouse/arrow keys, 
    public Rigidbody2D rb2d;

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonDown(0)) {
            Debug.Log("Hi");
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
    }
    private void DeflectBall(Collider2D other) { // This takes in the ball and changes its direction

    }

    private void GetMousePos() { // In case we want the ball to deflect towards the mouse
    }
}
