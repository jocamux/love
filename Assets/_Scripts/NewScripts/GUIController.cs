using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class GUIController : MonoBehaviour {

    public TimeController tc;
    public BeatController bc;
    public Animator cameraAnimator;
    public GameManager gm;

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
    public AudioSource P1Audio;
    public AudioSource P2Audio;
    public AudioSource changePhaseAudio;
    public AudioClip[] changePhaseClips;
    public AudioClip gameOverMusic;

    //Pools
    public Sprite[] backgrounds;


    // Use this for initialization
    void Start () {
        changePhaseClips = tc.currentSong.changePhaseClips;

    }
	
	// Update is called once per frame
	void Update () {
		
	}

    public void SolveBeat(bool perfect, int currentScore)
    {
  
        Step step = gm.currentStep;
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


        P2.nextPose = 9;
        P2.hasToChange = true;
        bso.Stop();
        bso.clip = gameOverMusic;
        //bso.loop = true;
        bso.Play();

        canvasAnimator.SetTrigger("TryAgain");
        
    }

    public void PlayOrderSound(Step step)
    {
        int affectedPlayer = step.affectedPlayers;
        switch (affectedPlayer)
        {
            case 0:
                P1Audio.clip = step.audioStep;
                P1Audio.Play();
                break;
            case 1:
                P2Audio.clip = step.audioStep;
                P2Audio.Play();
                break;
            case 2:
                P1Audio.clip = step.audioStep;
                P1Audio.Play();
                P2Audio.clip = step.audioStep;
                P2Audio.Play();
                break;
        }

    }
    public void PlayChangePhaseSound(int startingPhase)
    {
        changePhaseAudio.clip = changePhaseClips[startingPhase];
        changePhaseAudio.Play();
    }
           
}



