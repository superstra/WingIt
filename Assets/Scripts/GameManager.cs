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
    [SerializeField] private TMP_Text text;
    [SerializeField] private bool activeTimer;
    float startTime;
    float time;
    // Start is called before the first frame update
    void Start()
    {
        activeTimer = true;
        startTime = Time.time;
        text.text = startTime.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        if (activeTimer) {
            time += Time.deltaTime;
        }
        int minutes = Mathf.FloorToInt(time / 60F);
        float seconds = time - (minutes * 60F);

        string timeToDisplay = string.Format("{0:00}:{1:00.000}",minutes,seconds);
        text.text = timeToDisplay;

        
        //old implementation
        //float currtime = Time.time - startTime;
        //currtime = MathF.Round(currtime, 3);    
        //text.text = currtime.ToString();
    }
}
