using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheatSheet : MonoBehaviour {

    GameManager gm;
    public KeyCode lose = KeyCode.L;

	// Use this for initialization
	void Start () {
        gm = GetComponent<GameManager>();
        gm.ActivateCheatMode();
	}
	
	// Update is called once per frame
	void Update () {

        if(Input.GetKeyDown(lose)) 
        {
            gm.neverEnds = false;
            gm.GameOver();
               
        }
		
	}
}
