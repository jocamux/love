using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inputs : MonoBehaviour
{
    public int indexInput;
    public List<KeyCode> keycodes;


    public Inputs(List<KeyCode> list)
    {
        keycodes = list;

    }
   
    public List <KeyCode> GetKeyCode()
    {
        return keycodes;
    }
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    /*public bool ValidInput()
    {
        KeyCode.Keypad5.ToString;
    }
    */
}
