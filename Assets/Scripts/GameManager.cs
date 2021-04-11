using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace FinalCourt
{
    public class GameManager : MonoBehaviour
    {
        public static GameManager instance;

        public levelCompleted done;
        public string nextLevel;
        public PlayerController level;
        public GameObject gameOverScreen;
        public bool isGameComplete;

        public float startScreenTime = 1.0f;
        public float endScreenDelay = 1.0f;
        public float endScreenTime = 1.0f;
        public GameObject endScreen;

    // Start is called before the first frame update
        void Start()
        {
            
        }

        // Update is called once per frame
        void Update()
        {
            if(done.GetComponent<levelCompleted>().completed == true) {
                nextLevel = level.GetComponent<PlayerController>().next_level;
                StartCoroutine(LevelCompleted());
                //StartCoroutine(LevelCompleted());
            }
        }

        IEnumerator LevelCompleted()
        {
            // timeStopped = true;

            yield return new WaitForSeconds(endScreenDelay);

            //endScreen.SetActive(true);

            yield return new WaitForSeconds(endScreenTime);

            if (!string.IsNullOrEmpty(nextLevel))
            {
                SceneManager.LoadScene(nextLevel);
            }
            
            else
            {
                isGameComplete = true;
                gameOverScreen.SetActive(true);
            }
        }
    }
}
