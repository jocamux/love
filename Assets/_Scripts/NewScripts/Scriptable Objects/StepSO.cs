using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NewStep", menuName = "Step")]
public class StepSO : ScriptableObject
{
    // Required input

    public int indexInput;
    public List<KeyCode> keycodes;

    public int affectedPlayers; //obsolete?
    public AudioClip audioStep;
    public Pose[] pose = new Pose[2]; //P1/P2

    public bool changeColor;

 
}
