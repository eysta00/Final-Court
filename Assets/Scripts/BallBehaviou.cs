using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallBehaviou : MonoBehaviour
{
    public Rigidbody2D rb2d;
    public Vector2 direction;
    public float impulse;

    // Start is called before the first frame update
    void Start()
    {
        rb2d.velocity = direction.normalized * impulse;
    }

    // Update is called once per frame
    void Update()
    {
        float ballAngle = Vector2.Angle(transform.position, rb2d.velocity);
    }
}
