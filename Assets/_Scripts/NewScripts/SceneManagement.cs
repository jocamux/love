using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneManagement: MonoBehaviour {

	
	// Update is called once per frame
	public   void GoToGameplay () {
        SceneManager.LoadScene("NewGameplay");
        }
    public   void GoToCredits()
    {
        SceneManager.LoadScene("Credits");
    }
    public   void GoToDeath()
    {
       //SceneManager.LoadScene("Death");
    }
    public   void GoToStart()
    {
        SceneManager.LoadScene("Start");
    }
    public void GoToInstructions()
    {
        SceneManager.LoadScene("Instructions");
    }
}
