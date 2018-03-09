using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhaseSounds : MonoBehaviour
{
    //obliterated

    public AudioClip[] clips; 
    public int[] times;
    public AudioSource animators;

    bool firstReproduced = false;
    bool secondReproduced = false;

    float time = 0;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        time += Time.deltaTime;

        if (times[0]<time && !firstReproduced)
        {
            firstReproduced = true;
            animators.clip = clips[0];
            animators.Play();
        }

        if (times[1]<time && !secondReproduced)
        {
            secondReproduced = true;
            animators.clip = clips[1];
            animators.Play();
        }
		
	}
}
