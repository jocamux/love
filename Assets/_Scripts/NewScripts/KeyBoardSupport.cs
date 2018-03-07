using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyBoardSupport : MonoBehaviour {

    public SceneManagement sm;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetKeyDown(KeyCode.Space))
        {
            sm.GoToGameplay();
        }
	}
}
