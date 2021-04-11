using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [Header("Player Stats")]
    public int playerDamage = 15;
    public float playerSpeed = 5000f;
    public bool isServing;
        
    [Header("Grab objects")]
    public Transform Target;
    public Rigidbody rb;
    public Transform ball; // The ball pos
    public GameObject currBall;
    private BallBehaviour BallBehaviour;
    public Transform racket;

    public SpriteRenderer racketSprite;


    [Space(10)]
    [Header("Variables For determing the angle of ball")]
    public float racketPower  = 12f;
    public int ballHeight = 7;

    WaitForSeconds myWait;
    [Header("Testing Bools")]
    public bool isHitting;
    public bool ballInRange;
    Vector3 aimTargetMouse = Vector3.one;

    [Header("Charge Attack")]
    public float m_powerMin = 5f;               // Lowest amount of power to fire with.
    public float m_powerMax = 10f;              // Highest amount of power to fire with.
    public float m_chargeDurationMax = 2f;      // Time at which auto-fire happens.
    private float m_chargeDurationCurrent = 0f; // Time spent holding left mouse button down.
    private bool m_isCharging = false;          // Currently charging?
    private bool m_mouseWasReleased = true;

     
    public string next_level = "None";

    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody>();
    }

    public Vector3 raycastOntoTheWorld() {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        if (Physics.Raycast (ray, out hit)) {
                return hit.point;
            }
        else {
            return Vector3.zero;
        }

    }
    void Update()
    {  
        if (Input.GetMouseButtonDown(0) && isServing) {
            currBall.transform.position = this.transform.position;
            BallBehaviour = currBall.GetComponent<BallBehaviour>();
            BallBehaviour.enabled = true;
            Fire(racketPower, currBall.GetComponent<Rigidbody>());
            isServing = false;
            
        }
        // Find the direction to move in
        Target.position = raycastOntoTheWorld();
            

        float h = Input.GetAxisRaw("Horizontal"); // Get horizontal axis of the keyboard (Might need to change if we need to use the arrow keys)
        float v = Input.GetAxisRaw("Vertical"); // Get vertical axis of the keyboard (Might need to change if we need to use the arrow keys)
        
        if (Input.GetMouseButtonDown(0) && m_mouseWasReleased )
        {
            m_chargeDurationCurrent = 0f;
            m_isCharging = true;
            m_mouseWasReleased = false;
            isHitting = false;
            
        }
        else if (m_isCharging && (Input.GetMouseButtonUp(0) || m_chargeDurationCurrent >= m_chargeDurationMax))
        {
            // Release or Auto-release.
            if (ballInRange) {
                float power = Mathf.Lerp( m_powerMin, m_powerMax, m_chargeDurationCurrent / m_chargeDurationMax );
                Fire(power, ball.GetComponent<Rigidbody>());
            }
            ResetChargeTime();
            isHitting = false;

            // My method.

        }

        if (m_isCharging)
        {
            m_chargeDurationCurrent += Time.deltaTime;
            isHitting = true;
        }

        if(!m_mouseWasReleased)
        {
            m_mouseWasReleased = Input.GetMouseButtonUp(0);
        }

        if ((h != 0 || v != 0) && isHitting) // if we want to move and we aren't trying to hit the ball.
        {
            rb.AddForce(new Vector3(h, 0, v) * playerSpeed * 1/4 * Time.deltaTime); // move the player on the court
        }
        else if ((h != 0 || v != 0) && !isHitting){
            rb.AddForce(new Vector3(h, 0, v) * playerSpeed * Time.deltaTime); // move the player on the court
        }
    }
    void Fire(float power, Rigidbody other) {
    
        Vector3 dir = raycastOntoTheWorld() - transform.position;
        other.velocity = dir.normalized * power + new Vector3(0,ballHeight,0);

        if (dir.x >= 0) // on out right or left side 
        {   
            Vector3 newPos = transform.position + new Vector3(1.4f, 0.5f, 0);
            racket.position = newPos;
            racketSprite.flipY = false;
                    //animator.Play("forehand");                        // play a forhand animation if the ball is on our right
        }
        else                                                  // otherwise play a backhand animation 
        {
            Vector3 newPos = transform.position + new Vector3(-1.4f, 0.5f, 0);
            racket.position = newPos;
            racketSprite.flipY = true;
                    //animator.Play("backhand");
        }

    }
    private void ResetChargeTime()
    {
        // Reset Current Duration.
        m_chargeDurationCurrent = 0f;
        m_isCharging = false;
    }

    void OnTriggerEnter(Collider other)
    {
        next_level = other.gameObject.tag;
    }
}
