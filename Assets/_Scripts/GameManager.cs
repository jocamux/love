using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {


    //######### NEW CODING #########
    public int perfectScore;
    public float toleranceToPerfect;
    public int score = 0;
    public bool gameOver;

    public TimeController tc;
    public GUIController GUIc;
    public InputController ic;
    public Step currentStep; //deprecated
    public StepSO currentStepSO;

    CheatSheet cheatSheet;
    public bool neverEnds;
    bool cheatMode = false;
    //##############################
    /*public GameObject bSO;
    public AudioClip music;
    public AudioClip baseBeats;
    public InputManager im;
    public Animator anim;

    public GameObject Player1;
    public GameObject Player2;

    public List<Player> players;

    public List<Inputs> inputs;

    public List<Step> steps; //Step

    public List<Phase> phases; //Phase, float

    public float rate;
    public float epsilon;

    public int numberOfPhases = 3;
    public int numberOfSteps = 18;

    public float time = 0;

    public bool timeToStep = false;
    bool death = false;*/

    // Use this for initialization
    public void Start()
    {
        if (gameObject.GetComponent<CheatSheet>() != null )
        {

        }
    }
    //######### NEW CODING #########
    #region NewCoding
    public void ActivateCheatMode()
    {
        cheatMode = true;
        neverEnds = true;
    }
    public void CorrectBeat()
    {
        tc.solvedBeat = true;

        float percentageToPerfect = 1 - tc.distanceToPerfect;
        if(percentageToPerfect<0)
        { Debug.Log("check this bug");
            percentageToPerfect = 1;
        }

        if (percentageToPerfect > toleranceToPerfect)
        {
            score += perfectScore;

            GUIc.SolveBeat(true, score);
        }
        else
        {
            score += (int)(perfectScore * percentageToPerfect);

            GUIc.SolveBeat(false, score);

        }

    }
    
    public void SolveBeat()
    {
        if (ic.CompareInput())
        {
            CorrectBeat();
        }
        else
        {
            GameOver();
        }
    }

    public void GameOver()
    {
        if(!neverEnds)
        {
            GUIc.GameOverFeedback();
            gameOver = true;
        }


    }

    public void TryAgain() //Restart
    {
        gameOver = false;
        score = 0;
        if(cheatMode)
        {
            neverEnds = true;
        }
        GUIc.TryAgainFeedback();
        tc.RestartTime();
        tc.currentSong.Start();


        //SceneManager.LoadScene("NewGameplay");
    }

    public void SendOrder(Song currentSong, int currentPhase)
    {
        //currentStep = currentSong.songPhasesSteps[(currentPhase - 1) / 2].GetRandomStep(); //deprecated
        currentStepSO = currentSong.songPhasesSteps[(currentPhase - 1) / 2].GetRandomStepSO();
        GUIc.PlayOrderSound(currentStepSO);
        ic.AddPossibleInputs(currentStepSO.possibleInputPlaceHolder);
    }

    //##############################
    #endregion
    /*void Start() {

        //steps = new List<Step>();
        //steps = InitializeSteps();
        //phases = InitializePhases();


    }

    public void Die()
    {
        AudioSource thisstuff = bSO.GetComponent<AudioSource>();
        thisstuff.Stop();
        thisstuff.clip = baseBeats;
        thisstuff.loop = true;
        thisstuff.Play();
        anim.SetTrigger("TryAgain");


        death = true;
        Player2.GetComponent<Silouette>().nextPose = 9;
        Player2.GetComponent<Silouette>().hasToChange = true;

    }

    public void Restart()
    {
        Invoke("RestartLayout", 0f);
        /*AudioSource thisstuff = bSO.GetComponent<AudioSource>();
        thisstuff.Stop();
        thisstuff.loop = false;

        thisstuff.clip = music;
        thisstuff.Play();
        death = false;
        time = 0;
        timeToStep = false;
        score = 0;
        im.lose = false;
        im.win = false;
    }


    // Update is called once per frame


    void Update() {
            if (!death)
            {
                time += Time.deltaTime;

                if (time % rate > -epsilon && time % rate < epsilon && timeToStep)
                {
                    timeToStep = false;
                    Phase p = WhichPhase();
                    Debug.Log(WhichPhase());
                    if (p == null)
                    {

                        //win game
                    }
                    Step s = p.GetRandomStep();
                    Debug.Log(s.ToString());
                    //AudioClip au = null;
                    foreach (Step a in steps)
                    {
                        if (a == s)
                        {
                            //au = a.audioStep;
                        }
                    }
                    //Que suene el au
                    PlayAudio(s);
                    im.correctList = s.getRequiredInput().GetKeyCode();
                    im.affectedPlayer = s.affectedPlayers;
                    im.currentStep = s;
                    //affectedplayers

                }

                else if (time % rate >= epsilon)
                {
                    timeToStep = true;
                }

                if (time % rate > rate * 3.0 / 4.0 - epsilon && time % rate < rate * 3.0 / 4.0 + epsilon && !im.win)
                {
                    im.pressTime = true;
                }

                else im.pressTime = false;

                if (time % rate > rate * 3.0 / 4.0 + epsilon && time % rate < rate * 3.0 / 4.0 + 2 * epsilon)
                {
                    im.dieTime = true;
                    im.win = false;
                }

                else im.dieTime = false;



            }
            else
            {
                if (Input.GetKey(KeyCode.Space))
                {
                    Restart();
                    anim.SetTrigger("Restart");
                }
            }
    }

    

    void RestartLayout()
    {
        SceneManager.LoadScene(1);

    }

    private Phase WhichPhase()
    {
        
        Phase p = null; 
        for (int i = 0; i < phases.Capacity; ++i)
        {

            p = phases[i];
            if (time < phases[i].time)
            {

                break;
            }
            else if (i == phases.Capacity - 1)
            {
                p = null;
            }


            if(!p.activated)
            {
                p.activated = true;
            }
        }
        return p;
    }

    /*
    private List<Player> initializePlayers()
    {
        return new List<Player> { new Player(), new Player() };
    }
    

    private List<Phase> InitializePhases()  //Phase, second
    {
        Debug.Log("llega1");
        List<Phase> a = new List<Phase>(numberOfPhases);
        Debug.Log("llega2");

        a[0] = new Phase(
           new List<Step>() { steps[0] as Step, steps[1] as Step, steps[2] as Step, steps[3] as Step, steps[4] as Step, steps[5] as Step },
           new List<int>() { 2, 2, 1, 2, 2, 1 }, 30);//TODO CHANGE SECOND
        Debug.Log("llega3");

        a[1] = new Phase(
            new List<Step>() { steps[0] as Step, steps[1] as Step, steps[2] as Step, steps[3] as Step, steps[4] as Step, steps[5] as Step,
            steps[6] as Step, steps[7] as Step, steps[8] as Step, steps[9] as Step, steps[10] as Step, steps[11] as Step}, 
            new List<int>() { 2, 2, 1, 2, 2, 1, 2, 2, 1, 2, 2, 1 }, 60);//TODO CHANGE SECOND

        a[2]= new Phase(
            new List<Step>() { steps[0] as Step, steps[1] as Step, steps[2] as Step, steps[3] as Step, steps[4] as Step, steps[5] as Step,
            steps[6] as Step, steps[7] as Step, steps[8] as Step, steps[9] as Step, steps[10] as Step, steps[11] as Step,
            steps[12] as Step, steps[13] as Step, steps[14] as Step, steps[15] as Step, steps[16] as Step, steps[17] as Step},
            new List<int>() { 2, 2, 1, 2, 2, 1, 2, 2, 1, 2, 2, 1, 2, 2, 1, 2, 2, 1}, 120);//TODO CHANGE SECOND

        return a;

    }
    
    public void PlayAudio(Step step)
    {
        int affectedPlayer = step.affectedPlayers;
        if (affectedPlayer == 0)
        {
            AudioSource p1 = Player1.GetComponentInChildren<AudioSource>();
            p1.clip = step.audioStep;
            p1.Play();

        }
        else if (affectedPlayer == 1)
        {
            AudioSource p2 = Player2.GetComponentInChildren<AudioSource>();
            p2.clip = step.audioStep;
            p2.Play();
        }
        else if (affectedPlayer ==2)
        {
            AudioSource p1 = Player1.GetComponentInChildren<AudioSource>();
            p1.clip = step.audioStep;
            p1.Play();
            AudioSource p2 = Player2.GetComponentInChildren<AudioSource>();
            p2.clip = step.audioStep;
            p2.Play();
        }
    } //Obliterated
    private List<Step> InitializeSteps() //Step, Audio
    {
        List<Step> a = new List<Step>(numberOfSteps);
        for (int i = 0; i<numberOfSteps;  ++i )
        {
            
            Debug.Log(inputs[i].keycodes[0].ToString());
            Debug.Log(a[i].GetType().ToString());
            a[i] = new Step(inputs[i], (int)i%3);//inputs, players
            Debug.Log("llega1");
            

        }
        return a; 

    }*/
    /*private List<Inputs> InitializeInputs()
    {
        List<Inputs> a = new List<Inputs>(19);

        a = new List<Inputs>{
            new Inputs(new List<KeyCode> { KeyCode.A }),
            new Inputs(new List<KeyCode> { KeyCode.LeftArrow }),
            new Inputs(new List<KeyCode> { KeyCode.A, KeyCode.LeftArrow }),

            new Inputs(new List<KeyCode> { KeyCode.D }),
            new Inputs(new List<KeyCode> { KeyCode.RightArrow }),
            new Inputs(new List<KeyCode> { KeyCode.D, KeyCode.RightArrow }),

            new Inputs(new List<KeyCode> { KeyCode.W }),
            new Inputs(new List<KeyCode> { KeyCode.UpArrow }),
            new Inputs(new List<KeyCode> { KeyCode.W, KeyCode.UpArrow }),

            new Inputs(new List<KeyCode> { KeyCode.S }),
            new Inputs(new List<KeyCode> { KeyCode.DownArrow }),
            new Inputs(new List<KeyCode> { KeyCode.S, KeyCode.DownArrow }),

            new Inputs(new List<KeyCode> { KeyCode.UpArrow, KeyCode.DownArrow }),
            new Inputs(new List<KeyCode> { KeyCode.W, KeyCode.S }),
            new Inputs(new List<KeyCode> { KeyCode.UpArrow, KeyCode.DownArrow, KeyCode.W, KeyCode.S }),


            new Inputs(new List<KeyCode> { KeyCode.LeftArrow, KeyCode.RightArrow }),
            new Inputs(new List<KeyCode> { KeyCode.D, KeyCode.A }),
            new Inputs(new List<KeyCode> { KeyCode.LeftArrow, KeyCode.RightArrow, KeyCode.D, KeyCode.A }),



            new Inputs(new List<KeyCode> { KeyCode.P }) };

        foreach (Inputs k in a)
        {
            GameObject theGO = Instantiate(inputPrefab);
            theGO.AddComponent<Inputs>() = k.keycodes;
         

        }
        

       
        return new List<Inputs>
        {
            new Inputs(new List<KeyCode>{KeyCode.A}),
            new Inputs(new List<KeyCode>{KeyCode.LeftArrow}),
            new Inputs(new List<KeyCode>{KeyCode.A, KeyCode.LeftArrow}),

            new Inputs(new List<KeyCode>{KeyCode.D}),
            new Inputs(new List<KeyCode>{KeyCode.RightArrow}),
            new Inputs(new List<KeyCode>{KeyCode.D, KeyCode.RightArrow}),

            new Inputs(new List<KeyCode>{KeyCode.W}),
            new Inputs(new List<KeyCode>{KeyCode.UpArrow}),
            new Inputs(new List<KeyCode>{KeyCode.W, KeyCode.UpArrow}),
            
            new Inputs(new List<KeyCode>{KeyCode.S}),
            new Inputs(new List<KeyCode>{KeyCode.DownArrow}),
            new Inputs(new List<KeyCode>{KeyCode.S, KeyCode.DownArrow}),

            new Inputs(new List<KeyCode>{KeyCode.UpArrow, KeyCode.DownArrow}),
            new Inputs(new List<KeyCode>{KeyCode.W, KeyCode.S}),
            new Inputs(new List<KeyCode>{KeyCode.UpArrow, KeyCode.DownArrow, KeyCode.W, KeyCode.S}),


            new Inputs(new List<KeyCode>{KeyCode.LeftArrow, KeyCode.RightArrow}),
            new Inputs(new List<KeyCode>{KeyCode.D, KeyCode.A}),
            new Inputs(new List<KeyCode>{KeyCode.LeftArrow, KeyCode.RightArrow, KeyCode.D, KeyCode.A}),



            new Inputs(new List<KeyCode>{KeyCode.P}),
            //new Input(new List<KeyCode>{KeyCode.Space}),



        };*/
    }




