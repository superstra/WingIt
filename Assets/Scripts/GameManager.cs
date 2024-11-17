using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using TMPro;
using TMPro.EditorUtilities;
using Unity.Mathematics;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private TMP_Text timerText;
    [SerializeField] private TMP_Text speedText;
    [SerializeField] public bool activeTimer = false;
    [SerializeField] private Rigidbody bird;
    float startTime;
    float time;
    // Start is called before the first frame update
    void Start()
    {
        activeTimer = false;
        startTime = Time.time;
        timerText.text = startTime.ToString();
        speedText.text = "hi hello im init'd";
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
        
        speedText.text = "SPEED:"+string.Format("{0:000.0}",bird.velocity.magnitude);


        //old implementation
        //float currtime = Time.time - startTime;
        //currtime = MathF.Round(currtime, 3);    
        //text.text = currtime.ToString();
    }
}
