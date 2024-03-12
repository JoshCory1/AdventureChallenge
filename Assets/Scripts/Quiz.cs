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
    [SerializeField] List<QuestionsSO> questions = new List<QuestionsSO>();
    QuestionsSO currentQuestion;

    [Header("Answers")]
    [SerializeField] GameObject [] answerButtons;
    int correctAnswerIndex;
    bool hasAnsweredEarly = true;

    [Header("Button Colors")]  
    [SerializeField] Sprite defaultAnswerSprite;
    [SerializeField] Sprite correctAnswerSprite;
    [SerializeField] Sprite wrongAnswerSprite;

    [Header("Timer")]
    [SerializeField] Image timerImage;
    Timer timer;

    [Header("Scoring")]
    [SerializeField] TextMeshProUGUI scoreText;
    ScoreKeeper scoreKeeper;

    [Header("Progress Bar")]
    [SerializeField] Slider progressBar;


    [Header("SFX")]
    [SerializeField] public float sFXVolume = 0.8f;
    [SerializeField] public AudioClip clickSFX;
    SoundFX soundFX;
    public bool isComplete;

    void Awake() 
    {
        soundFX = FindObjectOfType<SoundFX>();
        scoreKeeper = FindObjectOfType<ScoreKeeper>();   
        timer = FindObjectOfType<Timer>();
        progressBar.maxValue = questions.Count;
        progressBar.value = 0;
    }
    

    void Update()
    {
        timerImage.fillAmount = timer.fillFraction;
        if(timer.loadNextQuestion)
        {
            if(progressBar.value == progressBar.maxValue)
            {
                isComplete = true;
                return;
            }
            hasAnsweredEarly = false;
            GetNextQuestion();
            timer.loadNextQuestion = false;
        }
        else if(!hasAnsweredEarly && !timer.isAnsweringQuestion && currentQuestion != null)
        {
            DisplayAnswer(-1);
            SetButtonState(false);
        }
    }
   
    private void DisplayAnswer(int index)
    {
        if (index == currentQuestion.GetCorrectAnswerIndex())
        {
            questionText.text = "Correct";
            SetDefaultButtonSprite(correctAnswerSprite, index, false);
            scoreKeeper.IncrementCorrectAnswers();
        }
        else
        {
            correctAnswerIndex = currentQuestion.GetCorrectAnswerIndex();
            string correctAnswer = currentQuestion.GetAnswer(correctAnswerIndex);
            questionText.text = "Good try, but the correct answer is :\n" + correctAnswer;
            SetDefaultButtonSprite(correctAnswerSprite, correctAnswerIndex, false);
            if(index >= 0 && index <= answerButtons.Length)
            {
                SetDefaultButtonSprite(wrongAnswerSprite, index, false);
            }

        }
    }

     public void OnAnswerSelected(int index)
    {
        soundFX.OnSoundFXClick();
        hasAnsweredEarly = true;
        DisplayAnswer(index);
        SetButtonState(false);
        timer.CancelTimer();
        scoreText.text = "Score: " + scoreKeeper.CalculateScore() + "%";

        
    }

    void GetNextQuestion()
    {
        if(questions.Count > 0)
        {
        SetButtonState(true);
        SetDefaultButtonSprite(defaultAnswerSprite, 0, true);
        GetRandomQuestion();
        DisplayQuestion();
        progressBar.value++;
        scoreKeeper.IncrementQuestionsSeen();
        }
        
    }

    void GetRandomQuestion()
    {
        int index = UnityEngine.Random.Range(0, questions.Count);
        currentQuestion = questions[index];
        if(questions.Contains(currentQuestion))
        {
            questions.Remove(currentQuestion);
        }
    }

    private void SetDefaultButtonSprite(Sprite sprite, int index, bool cycle)
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
        questionText.text = currentQuestion.GetQuestion();

        for(int i = 0; i < answerButtons.Length; i++)
        {
            TextMeshProUGUI buttonText = answerButtons[i].GetComponentInChildren<TextMeshProUGUI>();
            buttonText.text = currentQuestion.GetAnswer(i);
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
