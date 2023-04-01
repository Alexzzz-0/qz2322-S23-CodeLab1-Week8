using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;



public class button1 : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI answersFile;
    [SerializeField] private TextMeshProUGUI answer1;
    
    public void WriteButton1()
    {
        answersFile.text += "--" + answer1.text;
    }
}
