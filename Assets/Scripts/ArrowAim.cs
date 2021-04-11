using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowAim : MonoBehaviour
{
    public Transform AimTarget;
    // Update is called once per frame
    void Update()
    {
    Vector3 dir = AimTarget.position - transform.position;
    Quaternion lookRot = Quaternion.LookRotation(dir);
    lookRot.x = 0; lookRot.z = 0;
    transform.rotation = Quaternion.Slerp(transform.rotation, lookRot, Mathf.Clamp01(3.0f * Time.maximumDeltaTime));
    }
}
