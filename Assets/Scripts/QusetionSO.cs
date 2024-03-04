using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(menuName = "Quiz Question", fileName = "New Question")]
public class QusetionSO : ScriptableObject 
{
    [SerializeField] string question = "Enter new Question text here";


}
