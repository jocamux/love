using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Song : MonoBehaviour {

    AudioSource audioSource;
    public AudioClip audioClip;
    public float beatDuration;
    public int stepsInBeat;
    public int[] beatPerPhase; //Lenght = number of phases;
    public bool[] toleratesInput; 
    public int correctHitBeat;

    // Use this for initialization
    void Start () {
		if (beatPerPhase.Length != toleratesInput.Length)
        {
            Debug.Log("Missing Song Information. Is the script properly filled?");
        }
        audioSource = GetComponent<AudioSource>();
        audioSource.clip = audioClip;
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
