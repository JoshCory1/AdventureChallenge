using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.Design.Serialization;
using UnityEngine;


[CreateAssetMenu(menuName = "Quiz Question", fileName = "New Question")]
public class QusetionSO : ScriptableObject 
{
    [TextArea(2,6)]
    [SerializeField] string question = "Enter new Question text here";
    [SerializeField] string[] answers = new string[4];
    [SerializeField] int correctAnswerIndex;

    public string GetQuestion()
        {
            return question;
        }

    public string GetAnswer(int index)
    {
        return answers[index];
    }

    public int GetCorrectAnswerIndex()
    {
        return correctAnswerIndex;
    }


}
