using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Step: MonoBehaviour
{

    public Inputs requiredInput;
    public int affectedPlayers; //0=1; 1=2; 2=both;
    public AudioClip audioStep;
    public int pose;
    public bool changeColor;
    public Pose stepPose;
    public Pose arrowAttached;
    
    /*
     * Pose 1 - Drake (Down)
     * Pose 2 - Jump (Up)
     * Pose 3 - Back kick (Left)
     * Pose 4 - Popping (Flat)
     * Pose 5 - Dab (Right)
     * Pose 7 - Kiss (Love)
     * */




    public Inputs getRequiredInput()
    {
        return requiredInput;
    }

    public Step(Inputs input, int player)
    {
        requiredInput = input;
        affectedPlayers = player;

    }



    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
