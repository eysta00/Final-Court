using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [Header("Player Stats")]
    public int playerDamage = 15;
    public float playerSpeed = 2000f;
    [Space(10)]
    [Header("Grab objects")]
    public Transform Target;
    public Rigidbody rb;
    public Transform ball; // The ball pos
    [Space(10)]
    [Header("Variables For determing the angle of ball")]
    public float racketPower  = 10f;
    public int ballHeight = 7;

    WaitForSeconds myWait;
    bool isHitting;
    Vector3 aimTargetMouse = Vector3.one;


    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody>();
    }
    void Update()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        if (Physics.Raycast (ray, out hit)) {
                // Find the direction to move in
                Debug.DrawLine(transform.position, hit.point, Color.black);
                Target.position = hit.point;
            }

        float h = Input.GetAxisRaw("Horizontal"); // Get horizontal axis of the keyboard (Might need to change if we need to use the arrow keys)
        float v = Input.GetAxisRaw("Vertical"); // Get vertical axis of the keyboard (Might need to change if we need to use the arrow keys)
        if (Input.GetMouseButtonDown(0))
        {
            isHitting = true;
            // myWait = new WaitForSeconds(3000);
            
        }
        else if (Input.GetMouseButtonUp(0))
        {
            isHitting = false;
        }

        if ((h != 0 || v != 0) && !isHitting) // if we want to move and we are not hitting the ball
        {
            rb.AddForce(new Vector3(h, 0, v) * playerSpeed * Time.deltaTime); // move on the court
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Ball") && isHitting)
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast (ray, out hit)) {
                // Find the direction to move in
                Debug.DrawLine(transform.position, hit.point);
                Vector3 dir = hit.point - transform.position;
                other.GetComponent<Rigidbody>().velocity = dir.normalized * racketPower + new Vector3(0,ballHeight,0);
            }
            //add force to the ball plus some upward force according to the shot being played

            Vector3 ballDir = aimTargetMouse - transform.position; // get the direction of the ball compared to us to know if it is
            if (ballDir.x >= 0)                                   // on out right or left side 
            {
                //animator.Play("forehand");                        // play a forhand animation if the ball is on our right
            }
            else                                                  // otherwise play a backhand animation 
            {
                //animator.Play("backhand");
            }

        }
    }
}
