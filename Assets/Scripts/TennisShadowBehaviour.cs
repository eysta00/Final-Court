using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TennisShadowBehaviour : MonoBehaviour
{
    public Transform tennisBall; // Add a feature to grow the shadow size the higher up the ball is.
    Vector3 initalPos;
    void Start()
    {
        initalPos = tennisBall.position;
        initalPos.y = 0.01f;
        transform.position = initalPos;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(tennisBall.position.x, 0.01f, tennisBall.position.z);
    }
}
