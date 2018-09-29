using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NewStep", menuName = "Step")]
public class StepSO : ScriptableObject
{
    // Required input

    public int indexInput;
    public enum KeysAssociated
    {
        upL, downL, leftL, rightL, upR,downR,leftR,rightR
    }

    public List<KeysAssociated> keycodes;
    public List<KeyCode> possibleInputPlaceHolder;

    public int affectedPlayers; //obsolete?
    public AudioClip audioStep;
    public Pose[] pose = new Pose[2]; //P1/P2
    public string animationTrigger;

    public bool changeColor;
    

 
}
