using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Serialization;
using Random = UnityEngine.Random;

public class GameManager : MonoBehaviour
{
    public TextMeshProUGUI question;
    public TextMeshProUGUI button1;
    public TextMeshProUGUI button2;
    public TextMeshProUGUI button3;
    public TextMeshProUGUI answers;

    public ScriptableObjects object1;
    public ScriptableObjects object2;
    public ScriptableObjects object3;
    public ScriptableObjects object4;
    public ScriptableObjects object5;
    public ScriptableObjects object6;
    

    private int qArandom = 0;
    private int qA = 0;
    
    //create a list to hold all question A blanks
    private List<string> questionA = new List<string>();
    //an array to hold all the question B blanks (location possibility)
    private string[] questionB = new string[] { "above", "under", "left to", "right to" };
    private string[] organ = new string[] { "left eye", "left eye bow", "right eye", "right eye bow", "nose", "mouth" };
    private void Start()
    {

        questionA.Add("left eye bow");
        questionA.Add("right eye bow");
        questionA.Add("left eye");
        questionA.Add("right eye");
        questionA.Add("left ear");
        questionA.Add("right ear");
        questionA.Add("nose");
        questionA.Add("mouth");
    }
    
    //each time press the button
    //generate a new one
    string qAString;
    private string qBString;
    private int questionIndex = 0;
    
    public void choose()
    {

        //align which question it is
        questionIndex++;
        
        //randomly choose a string "qAindex" from question A blanks list
        //to ensure that every organ is mentioned once in the game
        //left eye, right eye...
        qArandom = Random.Range(0,questionA.Count-1);
        qAString = questionA[qArandom];
        
        //randomly choose one direction (up/left/down/right) every time we press the button
        int qBRandom;
        qBRandom = Random.Range(0, questionB.Length - 1);
        qBString = questionB[qBRandom];
        
        //display the question with A and B blank
        question.text = "What is " + qBString + " the " + qAString;
        
        //wrote the question into file
        answers.text += "\n" + questionIndex + question.text;
        
        //remove the A blank that has been asked so it will not overlap
        questionA.Remove(questionA[qArandom]);

        //randomly choose an organ as the answer
        int answerRandomIndex;
        
        answerRandomIndex = Random.Range(0, questionA.Count - 1);
        button1.text = questionA[answerRandomIndex];
        questionA.RemoveAt(answerRandomIndex);
        answerRandomIndex = Random.Range(0, questionA.Count - 1);
        button2.text = questionA[answerRandomIndex];
        questionA.RemoveAt(answerRandomIndex);
        answerRandomIndex = Random.Range(0, questionA.Count - 1);
        button3.text = questionA[answerRandomIndex];
        questionA.Add(button1.text);
        questionA.Add(button2.text);
        
        //write into file
        int objectIndex = 0;
        switch (objectIndex)
        {
            case 1:
                //object1.index = qAString;
                break;
            case 2:
                //object2.index = qAindex;
                break;
            case 3:
                //object3.index = qAindex;
                break;
            case 4:
                //object4.index = qAindex;
                break;
            case 5:
                //object5.index = qAindex;
                break;
            case 6:
                //object6.index = qAindex;
                break;
        }

        objectIndex++;
            
        
    }
    
    
    
    //end the application when there has gone 5 times
}
