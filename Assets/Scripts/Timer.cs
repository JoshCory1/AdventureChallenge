using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Timer : MonoBehaviour
{
    [SerializeField] float timeToCompleteQuestion = 30f;
    [SerializeField] float timeToShowCorrectAnswer = 10f;
   
   public bool isAnsweringQuestion;

    float timerValue;


    void Update()
    {
       updateTimer(); 
    }

    void updateTimer()
    {
        timerValue -= Time.deltaTime;
        if(timerValue <= 0)
        {
            if(isAnsweringQuestion)
            {
                timerValue = timeToShowCorrectAnswer;
                isAnsweringQuestion = false;
            }
            else
            {
                timerValue = timeToCompleteQuestion;
                isAnsweringQuestion = true;
            }
        }
    }
}
