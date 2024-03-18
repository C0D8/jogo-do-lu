using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class Timer : MonoBehaviour
{
    // Start is called before the first frame update
    public float timeRemaining = 10;
    public bool timerIsRunning = false;
    public TextMeshProUGUI timeText;

    void Start()
    {
        // Starts the timer automatically
        timeRemaining = 120;
        timerIsRunning = true;
        
    }

    // Update is called once per frame
    void Update()
    {
        if(timerIsRunning){
            if(timeRemaining > 0){
                timeRemaining -= Time.deltaTime;
                DisplayTime(timeRemaining);
            }else{
                Debug.Log("Time has run out!");
                timeRemaining = 0;
                timerIsRunning = false;
            }
        }
        
    }

    void DisplayTime(float timeToDisplay){
        if(timeToDisplay < 0){
            timeToDisplay = 0;
        }
        float minutes = Mathf.FloorToInt(timeToDisplay / 60);
        float seconds = Mathf.FloorToInt(timeToDisplay % 60);

        timeText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }

}
