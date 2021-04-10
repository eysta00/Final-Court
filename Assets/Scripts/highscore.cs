using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class highscore : MonoBehaviour
{
    // Start is called before the first frame update

    public Text score;
    //public GameObject txt;

    int curr_score = 0;

    void Start()
    {
        score.text = "Score: 0";
    }

    // Update is called once per frame
    void Update()
    {
        score.text = "Score: " + curr_score.ToString();
        //score.text = "Score: " + curr_score.ToString();
        //txt.GetComponent<Text>().text = score.text;
    }

    // void update_score() {
    //     score.text = "Score: " + curr_score.ToString();
    //     txt.GetComponent<Text>().text = "Score: " + curr_score.ToString();
    // }
}
