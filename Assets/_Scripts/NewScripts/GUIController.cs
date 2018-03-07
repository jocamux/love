using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class GUIController : MonoBehaviour {

    public TimeController tc;
    public BeatController bc;
    public Animator cameraAnimator;

    //ScreenElements
    public Animator canvasAnimator;
    public Silouette P1;
    public Silouette P2;
    public Text score;
    public GameObject bg1;
    public GameObject bg2;
    public Image bg3;
    public Image bg4;


    //AudioElements
    public AudioSource bso;

    public AudioClip gameOverMusic;

    //Pools
    public Sprite[] backgrounds;


    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void SolveBeat(bool perfect, int currentScore)
    {
  
        Step step = bc.currentStep;
        switch(step.affectedPlayers)
        {
            case 0:
                P1.nextPose = step.pose;
                P1.hasToChange = true;
                break;
            case 1:
                P2.nextPose = step.pose;
                P2.hasToChange = true;
                break;
            case 2:
                P1.nextPose = step.pose;
                P1.hasToChange = true;

                P2.nextPose = step.pose;
                P2.hasToChange = true;
                break;


        }
        if(step.changeColor)
        {
            Sprite chosenbg = backgrounds[Random.Range(0, backgrounds.Length)];
            bg1.GetComponent<SpriteRenderer>().sprite = chosenbg;
            bg2.GetComponent<SpriteRenderer>().sprite = chosenbg;
            bg3.sprite = chosenbg;
            bg4.sprite = chosenbg;
        }
        cameraAnimator.SetTrigger("Shake");
        score.text = currentScore.ToString();

        if(perfect)
        {
            //cosas de perfect
        }

    }

    public void GameOverFeedback()
    {
        bso.Stop();
        bso.clip = gameOverMusic;
        bso.loop = true;
        bso.Play();

        canvasAnimator.SetTrigger("TryAgain");
        
    }
           
}



