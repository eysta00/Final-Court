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
        public string gameOverScreen;
        public bool isGameComplete;

        public float startScreenTime = 1.0f;
        public float endScreenDelay = 1.0f;
        public float endScreenTime = 1.0f;
        public string endScreen;
        public bool isFinalLevel;

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
            if(level.Health <= 0) {
                SceneManager.LoadScene(gameOverScreen);
            }
            if (isFinalLevel && done.GetComponent<levelCompleted>().completed == true) {
                SceneManager.LoadScene(endScreen);
            }
        }

        IEnumerator LevelCompleted()
        {
            // timeStopped = true;

            yield return new WaitForSeconds(endScreenDelay);

            

            yield return new WaitForSeconds(endScreenTime);

            if (nextLevel == "EnemySide" || nextLevel == "PlayerSide" || nextLevel == "Wall" || nextLevel == "Untagged" || nextLevel == "Ball") {
                // Nothing happens
            }

            else if (!string.IsNullOrEmpty(nextLevel))
            {
                SceneManager.LoadScene(nextLevel);
            }

            else
            {
                isGameComplete = true;
                SceneManager.LoadScene(gameOverScreen);
                //gameOverScreen.SetActive(true);
            }
        }
    }
}
