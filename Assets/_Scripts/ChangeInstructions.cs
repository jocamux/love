using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChangeInstructions : MonoBehaviour {
    public string[] s1;

    public Text text1;


    public float time;

    // Use this for initialization
    void Start () {
        time = 0;
	}
	
	// Update is called once per frame
	void Update () {
        time += Time.deltaTime;
        float t = time % 2;
        if (t >= 0 && t < 0.5)
        {
            text1.text = s1[0];

        }
        else if (t >= 0.5 && t < 1) 
        {
            text1.text = s1[1];
  
        }
        else if (t >= 1 && t < 1.5) 
        {
            text1.text = s1[2];

        }
        else 
        {
            text1.text = s1[3];

        }



    }
}
