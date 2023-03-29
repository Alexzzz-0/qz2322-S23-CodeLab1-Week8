using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(
    fileName = "ScriptableObjects/Location",
    menuName = "ScriptableObjects/Location",
    order = 0
    )]

public class ScriptableObjects : ScriptableObject
{
    public int index;
    public string name;
    public float x;
    public float y;
}
