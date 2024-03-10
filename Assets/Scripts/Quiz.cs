using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using System;

public class Quiz : MonoBehaviour
{
    [Header("Questions")]
    [SerializeField] TextMeshProUGUI questionText;
    [SerializeField] QusetionSO question;
    [Header("Answers")]
    [SerializeField] GameObject [] answerButtons;
    int correctAnswerIndex;
    bool hasAnsweredEarly;
    [Header("Button Colors")]  
    [SerializeField] Sprite defaultAnswerSprite;
    [SerializeField] Sprite correctAnswerSprite;
    [Header("Timer")]
    [SerializeField] Image timerImage;
    Timer timer;
    void Start()
    {
        timer = FindObjectOfType<Timer>();
        GetNextQuestion();
       //DisplayQuestion(); 
    }

    void Update()
    {
        timerImage.fillAmount = timer.fillFraction;
        if(timer.loadNextQuestion)
        {
            hasAnsweredEarly = false;
            GetNextQuestion();
            timer.loadNextQuestion = false;
        }
        else if(!hasAnsweredEarly && !timer.isAnsweringQuestion)
        {
            DisplayAnswer(-1);
            SetButtonState(false);
        }
    }

    public void OnAnswerSelected(int index)
    {
        hasAnsweredEarly = true;
        DisplayAnswer(index);
        SetButtonState(false);
        timer.CancelTimer();
    }

    private void DisplayAnswer(int index)
    {
        if (index == question.GetcorrectAnswerIndex())
        {
            questionText.text = "Correct";
            SetDefaltButtonSprite(correctAnswerSprite, index, false);
        }
        else
        {
            correctAnswerIndex = question.GetcorrectAnswerIndex();
            string correctAnswer = question.GetAnswer(correctAnswerIndex);
            questionText.text = "Good try, but the correct answer is :\n" + correctAnswer;
            SetDefaltButtonSprite(correctAnswerSprite, correctAnswerIndex, false);

        }
    }

    void GetNextQuestion()  //untested
    {
        SetButtonState(true);
        SetDefaltButtonSprite(defaultAnswerSprite, 0, true);
        DisplayQuestion();
    }

    private void SetDefaltButtonSprite(Sprite sprite, int index, bool cycle)
    {
        Image buttonImage;
        if(cycle == true)
        {
            for(int i = 0; i < answerButtons.Length; i++ )
            {
                buttonImage = answerButtons[i].GetComponent<Image>();
                buttonImage.sprite = sprite;
            }
        }
        else
        {
            buttonImage = answerButtons[index].GetComponent<Image>();
            buttonImage.sprite = sprite;
        }
    }

    void DisplayQuestion()
    {
        questionText.text = question.GetQuestion();

        for(int i = 0; i < answerButtons.Length; i++)
        {
            TextMeshProUGUI buttonText = answerButtons[i].GetComponentInChildren<TextMeshProUGUI>();
            buttonText.text = question.GetAnswer(i);
        }
    }

    void SetButtonState(bool state)
    {
        for(int i = 0; i < answerButtons.Length; i++)
        {
            Button button = answerButtons[i].GetComponent<Button>();
            button.interactable = state;
        }
    }

}
