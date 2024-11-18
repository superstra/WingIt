using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using TMPro;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField] private TMP_Text timerText;
    [SerializeField] private TMP_Text speedText;
    [SerializeField] private TMP_Text countdownText;
    [SerializeField] public bool activeTimer = false;
    [SerializeField] private Rigidbody birdrb;
    [SerializeField] private PlayerController bird;
    

    private bool gamestarted = false;
    private float countDownTimeInterval = 1.0f;
    private float countdowntimeleft = 1.0f;

    float startTime;
    float time;
    // Start is called before the first frame update
    void Start()
    {
        gamestarted = false;
        activeTimer = false;
        startTime = Time.time;
        timerText.text = startTime.ToString();
        speedText.text = "hi hello im init'd";
        countdownText.text = "4";
    }

    // Update is called once per frame
    void Update()
    {
        //timer
        if (activeTimer) {
            time += Time.deltaTime;
        }
        int minutes = Mathf.FloorToInt(time / 60F);
        float seconds = time - (minutes * 60F);

        string timeToDisplay = string.Format("{0:00}:{1:00.000}",minutes,seconds);
        timerText.text = timeToDisplay;

        //Velocity
        
        speedText.text = "SPEED:"+string.Format("{0:000.0}",birdrb.velocity.magnitude * 2);

        if (Input.GetKeyDown(KeyCode.R)) {
            Debug.Log("User restart");
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }

        //old implementation
        //float currtime = Time.time - startTime;
        //currtime = MathF.Round(currtime, 3);    
        //text.text = currtime.ToString();
    }

    public void displayTime() {
        countdownText.text = "FINAL TIME: " + timerText.text;
        bird.stop();
    }
    private void FixedUpdate()
    {
        if (!gamestarted) {
            if (countdowntimeleft <= 0f) {
                countdowntimeleft = countDownTimeInterval;
                if (countdownText.text == "4") 
                {
                    countdownText.text = "3"; 
                }
                else if (countdownText.text == "3")
                {
                    countdownText.text = "2";
                }
                else if (countdownText.text == "2")
                {
                    countdownText.text = "1";
                }
                else if (countdownText.text == "1")
                {
                    countdownText.text = "GO!";
                    //let player move here, start timer.
                    bird.go();
                    activeTimer = true;
                }
                else if (countdownText.text == "GO!")
                {
                    countdownText.text = "";
                    gamestarted = true;
                }
            }
            else
            {
                countdowntimeleft -= Time.fixedDeltaTime;
            }



        }
    }
}
