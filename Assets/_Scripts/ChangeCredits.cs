using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChangeCredits : MonoBehaviour {
    public string[] s1;
    public string[] s2;
    public string[] s3;
    public string[] s4;
    public string[] s5;
    public string[] s6;

    public Text text1;
    public Text text2;
    public Text text3;
    public Text text4;
    public Text text5;
    public Text text6;

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
            text2.text = s2[0];
            text3.text = s3[0];
            text4.text = s4[0];
            text5.text = s5[0];
            text6.text = s6[0];
        }
        else if (t >= 0.5 && t < 1) 
        {
            text1.text = s1[1];
            text2.text = s2[1];
            text3.text = s3[1];
            text4.text = s4[1];
            text5.text = s5[1];
            text6.text = s6[1];
        }
        else if (t >= 1 && t < 1.5) 
        {
            text1.text = s1[2];
            text2.text = s2[2];
            text3.text = s3[2];
            text4.text = s4[2];
            text5.text = s5[2];
            text6.text = s6[2];
        }
        else 
        {
            text1.text = s1[3];
            text2.text = s2[3];
            text3.text = s3[3];
            text4.text = s4[3];
            text5.text = s5[3];
            text6.text = s6[3];
        }



    }
}
