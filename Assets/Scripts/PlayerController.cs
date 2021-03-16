using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Rigidbody rb;
    public Transform aimTarget;
    public float playerSpeed = 3f;
    public float racketPower  = 10f;

    bool isHitting;

    public Transform ball; // The ball pos

    Vector3 aimTargetInitalPos; // inital pos of the aiming gameObj which is the center of the opposite court
    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody>();
    }
    void Update()
    {
        float h = Input.GetAxisRaw("Horizontal"); // Get horizontal axis of the keyboard (Might need to change if we need to use the arrow keys)
        float v = Input.GetAxisRaw("Vertical"); // Get vertical axis of the keyboard (Might need to change if we need to use the arrow keys)
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            isHitting = true;
        }
        else if (Input.GetKeyUp(KeyCode.LeftArrow))
        {
            isHitting = false; // we let go of the key so we are not hitting anymore and this 
        }                    // is used to alternate between moving the aim target and ourself

        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            isHitting = true; // we are trying to hit the ball and aim where to make it land
        }
        else if (Input.GetKeyUp(KeyCode.RightArrow))
        {
            isHitting = false;
        }


        if (isHitting)  // if we are trying to hit the ball
        {
            aimTarget.Translate(new Vector3(h, 0, 0) * 5 * Time.deltaTime); //translate the aiming gameObject on the court horizontallly
        }

        if ((h != 0 || v != 0) && !isHitting) // if we want to move and we are not hitting the ball
        {
            rb.AddForce(new Vector3(h, 0, v) * playerSpeed * Time.deltaTime); // move on the court
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Ball"))
        {
            Vector3 dir = aimTarget.position - transform.position; // get the direction to where we want to send the ball
            other.GetComponent<Rigidbody>().velocity = dir.normalized * racketPower + new Vector3(0, 4, 0);
            //add force to the ball plus some upward force according to the shot being played

            Vector3 ballDir = ball.position - transform.position; // get the direction of the ball compared to us to know if it is
            if (ballDir.x >= 0)                                   // on out right or left side 
            {
                //animator.Play("forehand");                        // play a forhand animation if the ball is on our right
            }
            else                                                  // otherwise play a backhand animation 
            {
                //animator.Play("backhand");
            }

            aimTarget.position = aimTargetInitalPos; // reset the position of the aiming gameObject to it's original position ( center)
        }
    }
}
