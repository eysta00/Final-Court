using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Combo : MonoBehaviour
{
    public Text com;
    public BallBehaviour ball;

    void Start()
    {
        com.text = "Combo";
    }

    void Update()
    {
        //float tala = ball.GetComponent<BallBehaviour>().combo;
        //Debug.Log(tala);
        com.text = "Combo " + ball.GetComponent<BallBehaviour>().combo.ToString();
    }
}
