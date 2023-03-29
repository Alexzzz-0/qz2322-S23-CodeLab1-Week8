using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using Random = UnityEngine.Random;

public class GameManager : MonoBehaviour
{
    public TextMeshProUGUI question;
    public TextMeshProUGUI answer1;
    public TextMeshProUGUI answer2;
    public TextMeshProUGUI answer3;

    public ScriptableObjects object1;
    public ScriptableObjects object2;
    public ScriptableObjects object3;
    public ScriptableObjects object4;
    public ScriptableObjects object5;
    public ScriptableObjects object6;
    

    private int qArandom = 0;
    private int qA = 0;
    
    //create a list to hold all question A blanks
    private List<int> questionA = new List<int>();
    //an array to hold all the location possibility
    private string[] questionB = new string[] { "above", "under", "left to", "right to" };
    private string[] organ = new string[] { "left eye", "left eye bow", "right eye", "right eye bow", "nose", "mouth" };
    private void Start()
    {
        for (int i = 0; i < 6; i++)
        {
            questionA.Add(i);
        }
    }
    
    //each time press the button
    //generate a new one
    int qAindex;
    string qAString;
    private string qBString;
    
    public void choose()
    {
        //create a list to hold all the qustion A blank possiblities
        //to ensure that every organ is mentioned once in the game
        //left eye, right eye...
        qArandom = Random.Range(0,questionA.Count-1);
        qAindex = questionA[qArandom];
        
        switch (qAindex)
        {
            case 0:
                qAString = "left eye";
                break;
            case 1:
                qAString = "left eye bow";
                break;
            case 2:
                qAString = "right eye";
                break;
            case 3:
                qAString = "right eye bow";
                break;
            case 4:
                qAString = "nose";
                break;
            case 5:
                qAString = "mouth";
                break;
        }

        //create an array of above, under, left, right
        //randomly choose one every time we press the button
        int qBRandom;
        qBRandom = Random.Range(0, questionB.Length - 1);
        qBString = questionB[qBRandom];
        
        //display the question with A and B blank
        question.text = "What is " + qBString + " the " + qAString;
        
        //remove the A blank that has been asked so it will not overlap
        questionA.Remove(questionA[qArandom]);

        //randomly choose an organ as the answer
        int answerIndex;
        answerIndex = Random.Range(0, organ.Length - 1);
        answer1.text = organ[answerIndex];
        answerIndex = Random.Range(0, organ.Length - 1);
        answer2.text = organ[answerIndex];
        answerIndex = Random.Range(0, organ.Length - 1);
        answer3.text = organ[answerIndex];
        
        //write into file
        int objectIndex = 0;
        switch (objectIndex)
        {
            case 1:
                object1.index = qAindex;
                break;
            case 2:
                object2.index = qAindex;
                break;
            case 3:
                object3.index = qAindex;
                break;
            case 4:
                object4.index = qAindex;
                break;
            case 5:
                object5.index = qAindex;
                break;
            case 6:
                object6.index = qAindex;
                break;
        }

        objectIndex++;
            
        
    }
    
    
    
    //end the application when there has gone 5 times
}
