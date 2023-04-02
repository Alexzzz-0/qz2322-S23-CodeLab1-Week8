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

    [SerializeField] private Sprite leftEye;
    [SerializeField] private Sprite leftEyeBow;
    [SerializeField] private Sprite rightEye;
    [SerializeField] private Sprite rightEyeBow;
    [SerializeField] private Sprite leftEar;
    [SerializeField] private Sprite rightEar;
    [SerializeField] private Sprite nose;
    [SerializeField] private Sprite mouth;
    private Sprite _sprite;

    private ScriptableObjects _object;

    private int qArandom = 0;

    public string choseAnswer;

    public static GameManager _instance;

    //create a list to hold all question A blanks
    private List<string> questionA = new List<string>();
    //an array to hold all the question B blanks (location possibility)
    private string[] questionB = new string[] { "above", "under", "left to", "right to" };
    private string[] organ = new string[] { "left eye", "left eye bow", "right eye", "right eye bow", "nose", "mouth" };
    private void Start()
    {
        _instance = this;

        questionA.Add("left eye bow");
        questionA.Add("right eye bow");
        questionA.Add("left eye");
        questionA.Add("right eye");
        questionA.Add("left ear");
        questionA.Add("right ear");
        questionA.Add("nose");
        questionA.Add("mouth");

        _object = object1;
        _sprite = leftEye;
        choseAnswer = null;
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
        
        //randomly choose one direction (up/left/down/right
        //) every time we press the button
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
        //delete the element of list for now, so they won't be the same
        //add back at the end
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
        // _object.name = qAString;
        // _object.location = qBString;
        
        

        switch (questionIndex)
        {
            case 1:
                //object1 = _object;
                object1.name = qAString;
                object1.location = qBString;
                object1.sprite = SearchImage(qAString);
                object1.theOther = choseAnswer;
                break;
            case 2:
                //object2 = _object;
                object2.name = qAString;
                object2.location = qBString;
                object2.sprite = SearchImage(qAString);
                object2.theOther = choseAnswer;
                break;
            case 3:
                //object3 = _object;
                object3.name = qAString;
                object3.location = qBString;
                object3.sprite = SearchImage(qAString);
                object3.theOther = choseAnswer;
                break;
            case 4:
                //object4 = _object;
                object4.name = qAString;
                object4.location = qBString;
                object4.sprite = SearchImage(qAString);
                object4.theOther = choseAnswer;
                break;
            case 5:
                //object5 = _object;
                object5.name = qAString;
                object5.location = qBString;
                object5.sprite = SearchImage(qAString);
                object5.theOther = choseAnswer;
                break;
            case 6:
                //object6 = _object;
                object6.name = qAString;
                object6.location = qBString;
                object6.sprite = SearchImage(qAString);
                object6
                    .theOther = choseAnswer;
                break;
        }

    }

    Sprite SearchImage(string name)
    {
        switch (name)
        {
            case "left eye" :
                _sprite = leftEye;
                break;
            case "right eye":
                _sprite = rightEye;
                break;
            case "left eye bow":
                _sprite = leftEyeBow;
                break;
            case "right eye bow":
                _sprite = rightEyeBow;
                break;
            case "left ear":
                _sprite = leftEar;
                break;
            case "right ear":
                _sprite = rightEar;
                break;
            case "nose":
                _sprite = nose;
                break;
            case "mouth":
                _sprite = mouth;
                break;
        }

        return _sprite;
    }
    
    
    
    //end the application when there has gone 5 times
}
