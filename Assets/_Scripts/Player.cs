using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour{

    public GameManager gameManager;
    public Animator animator;

    public Sprite[] Pose0Idle;

    public int CurrentPose;
    public bool changePose;

    public bool GoToPose1;
    public Sprite[] Pose1TransitionPre;
    public Sprite[] Pose1;
    public Sprite[] Pose1Idle;
    public Sprite[] Pose1Transition;

    public bool GoToPose2;
    public Sprite[] Pose2TransitionPre;
    public Sprite[] Pose2;
    public Sprite[] Pose2Idle;
    public Sprite[] Pose2Transition;

    public bool GoToPose3;
    public Sprite[] Pose3TransitionPre;
    public Sprite[] Pose3;
    public Sprite[] Pose3Idle;
    public Sprite[] Pose3Transition;

    public bool GoToPose4;
    public Sprite[] Pose4TransitionPre;
    public Sprite[] Pose4;
    public Sprite[] Pose4Idle;
    public Sprite[] Pose4Transition;

    public bool GoToPose5;
    public Sprite[] Pose5TransitionPre;
    public Sprite[] Pose5;
    public Sprite[] Pose5Idle;
    public Sprite[] Pose5Transition;

    public bool GoToPose6;
    public Sprite[] Pose6TransitionPre;
    public Sprite[] Pose6;
    public Sprite[] Pose6Idle;
    public Sprite[] Pose6Transition;

    public bool GoToPose7;
    public Sprite[] Pose7TransitionPre;
    public Sprite[] Pose7;
    public Sprite[] Pose7Idle;
    public Sprite[] Pose7Transition;

    public bool GoToPose8;
    public Sprite[] Pose8TransitionPre;
    public Sprite[] Pose8;
    public Sprite[] Pose8Idle;
    public Sprite[] Pose8Transition;

    public bool GoToPose9;
    public Sprite[] Pose9TransitionPre;
    public Sprite[] Pose9;
    public Sprite[] Pose9Idle;
    public Sprite[] Pose9Transition;

    int currentPosePhase = 0; //0 = pre, 1=in, 2=idle, 3=transition
    int currentPose = 0;
    public bool inAnimation;

    public SpriteMask maskPlayer1;

    public float timeAnimation;

    // Use this for initialization
    /*void Start () {
        InvokeRepeating("StartPose", 0, 1 / timeAnimation);
        //maskPlayer1.sprite = Pose1[];
	}
	
	// Update is called once per frame
	void Update () {
        if(currentPosePhase == 3 && GoToPose1 ||GoToPose2||GoToPose3||GoToPose4||GoToPose5||GoToPose6||GoToPose7||GoToPose8 || GoToPose9)
        {
            inAnimation = true ;
        }
        //MusicSource.clip = MusicClip[]
        /*if (GoToPose1)
        {
            GoToPose1 = false;
            CancelInvoke();
            currentPose = 0;
            currentPosePhase = 0;
            InvokeRepeating("AnimPose1", 0, 1 / timeAnimation);
        }

        if (GoToPose2)
        {
            GoToPose2 = false;
            CancelInvoke();
            InvokeRepeating("AnimPose2", 0.5f, 1 / timeAnimation);
            currentPose = 0;
            currentPosePhase = 0;
            
        }

        if (GoToPose3)
        {
            Invoke("DisableChange", 0.5f);
            GoToPose3 = false;
            CancelInvoke();
            InvokeRepeating("AnimPose3", 0.5f, 1 / timeAnimation);
            currentPose = 0;
            currentPosePhase = 0;

        }

        if (GoToPose4)
        {
            GoToPose4 = false;
            CancelInvoke();
            InvokeRepeating("AnimPose4", 0.5f, 1 / timeAnimation);
            currentPose = 0;
            currentPosePhase = 0;

        }

        if (GoToPose5)
        {
            GoToPose5 = false;
            CancelInvoke();
            InvokeRepeating("AnimPose5", 0.5f, 1 / timeAnimation);
            currentPose = 0;
            currentPosePhase = 0;

        }

        if (GoToPose6)
        {
            GoToPose6 = false;
            CancelInvoke();
            InvokeRepeating("AnimPose6", 0.5f, 1 / timeAnimation);
            currentPose = 0;
            currentPosePhase = 0;

        }

        if (GoToPose7)
        {
            GoToPose7 = false;
            CancelInvoke();
            InvokeRepeating("AnimPose7", 0.5f, 1 / timeAnimation);
            currentPose = 0;
            currentPosePhase = 0;

        }

        if (GoToPose9)
        {
            GoToPose9 = false;

            CancelInvoke();
            InvokeRepeating("AnimPose9", 0.5f, 1 / timeAnimation);
            currentPose = 0;
            currentPosePhase = 0;
            animator.SetTrigger("TryAgain");
           
        }
         

    }

    void MainIdle()
    {
        if(currentPose == 0)
        {
            currentPose = 1;
        }
        else
        {
            currentPose = 0;
        }
        //maskPlayer1.sprite = Pose0Idle[currentPose];
    }


void StartPose()
    {
        currentPose++;
        currentPose %= Pose0Idle.Length;
        maskPlayer1.sprite = Pose0Idle[currentPose];

        
    }

   void AnimPose1()
    {
        switch (currentPosePhase)
        {
            case 0:
                maskPlayer1.sprite = Pose1TransitionPre[currentPose];
                currentPose++;
                currentPose %= Pose1TransitionPre.Length;
                if (currentPose == 0)
                {
                    currentPosePhase++;
                }
                break;

            case 1:
                maskPlayer1.sprite = Pose1[currentPose];
                currentPose++;
                currentPose %= Pose1.Length;
                if (currentPose == 0)
                {
                    currentPosePhase++;
                }
                break;
            case 2:
                maskPlayer1.sprite = Pose1Idle[currentPose% Pose1Idle.Length];
                currentPose++;
                currentPose %= (Pose1Idle.Length * 3); //Idle is repeated 3 times
                if (changePose)
                {
                    currentPosePhase++;
                }

                break;
            case 3:
                maskPlayer1.sprite = Pose1Transition[currentPose];
                currentPose++;
                currentPose %= Pose1Transition.Length;
                if (currentPose == 0)
                {
                    CancelInvoke();
                    InvokeRepeating("MainIdle", 0, 1 / timeAnimation);
                    break;
                }

                break;

        }
        // maskPlayer1.sprite = Pose
       /* currentPose = 0;
        currentPosePhase = 0;
    }

    void AnimPose2()
    {
        switch (currentPosePhase)
        {
            case 0:
                maskPlayer1.sprite = Pose2TransitionPre[currentPose];
                currentPose++;
                currentPose %= Pose2TransitionPre.Length;
                if (currentPose == 0)
                {
                    currentPosePhase++;
                }
                break;

            case 1:
                maskPlayer1.sprite = Pose2[currentPose];
                currentPose++;
                currentPose %= Pose2.Length;
                if (currentPose == 0)
                {
                    currentPosePhase++;
                }
                break;
            case 2:
                maskPlayer1.sprite = Pose2Idle[currentPose];
                currentPose++;
                currentPose %= Pose2Idle.Length;
                if (changePose)
                {
                    currentPosePhase++;
                }
                break;
            case 3:
                maskPlayer1.sprite = Pose2Transition[currentPose];
                currentPose++;
                currentPose %= Pose2Transition.Length;
                if (currentPose == 0)
                {
                    changePose = false;
                    CancelInvoke();
                    InvokeRepeating("MainIdle", 0, 1 / timeAnimation);
                    break;
                }
                break;

        }
        // maskPlayer1.sprite = Pose
    }
        void AnimPose3()
        {
            switch (currentPosePhase)
            {
                case 0:
                    maskPlayer1.sprite = Pose3TransitionPre[currentPose];
                    currentPose++;
                    currentPose %= Pose3TransitionPre.Length;
                    if (currentPose == 0)
                    {
                        currentPosePhase++;
                    }
                    break;

                case 1:
                    maskPlayer1.sprite = Pose3[currentPose];
                    currentPose++;
                    currentPose %= Pose3.Length;
                    if (currentPose == 0)
                    {
                        currentPosePhase++;
                    }
                    break;
                case 2:
                    maskPlayer1.sprite = Pose3Idle[currentPose];
                    currentPose++;
                    currentPose %= Pose3Idle.Length;
                    if (changePose)
                {
                        currentPosePhase++;
                    }
                    break;
                case 3:
                    maskPlayer1.sprite = Pose3Transition[currentPose];
                    currentPose++;
                    currentPose %= Pose3Transition.Length;
                    if (currentPose == 0)
                    {
                        CancelInvoke();
                        InvokeRepeating("MainIdle", 0, 1 / timeAnimation);
                        break;
                    }
                    break;

            }

        }

    void AnimPose4()
    {
        switch (currentPosePhase)
        {
            case 0:
                maskPlayer1.sprite = Pose4TransitionPre[currentPose];
                currentPose++;
                currentPose %= Pose4TransitionPre.Length;
                if (currentPose == 0)
                {
                    currentPosePhase++;
                }
                break;

            case 1:
                maskPlayer1.sprite = Pose4[currentPose];
                currentPose++;
                currentPose %= Pose4.Length;
                if (currentPose == 0)
                {
                    currentPosePhase++;
                }
                break;
            case 2:
                maskPlayer1.sprite = Pose4Idle[currentPose];
                currentPose++;
                currentPose %= Pose4Idle.Length;
                if (changePose)
                {
                    currentPosePhase++;
                }
                break;
            case 3:
                maskPlayer1.sprite = Pose4Transition[currentPose];
                currentPose++;
                currentPose %= Pose4Transition.Length;
                if (currentPose == 0)
                {
                    CancelInvoke();
                    InvokeRepeating("MainIdle", 0, 1 / timeAnimation);
                    break;
                }
                break;

        }
    }

        void AnimPose5()
        {
            switch (currentPosePhase)
            {
                case 0:
                    maskPlayer1.sprite = Pose5TransitionPre[currentPose];
                    currentPose++;
                    currentPose %= Pose5TransitionPre.Length;
                    if (currentPose == 0)
                    {
                        currentPosePhase++;
                    }
                    break;

                case 1:
                    maskPlayer1.sprite = Pose5[currentPose];
                    currentPose++;
                    currentPose %= Pose5.Length;
                    if (currentPose == 0)
                    {
                        currentPosePhase++;
                    }
                    break;
                case 2:
                    maskPlayer1.sprite = Pose5Idle[currentPose];
                    currentPose++;
                    currentPose %= Pose5Idle.Length;
                    if (changePose)
                    {
                        currentPosePhase++;
                    }
                    break;
                case 3:
                    maskPlayer1.sprite = Pose5Transition[currentPose];
                    currentPose++;
                    currentPose %= Pose5Transition.Length;
                    if (currentPose == 0)
                    {
                        CancelInvoke();
                        InvokeRepeating("MainIdle", 0, 1 / timeAnimation);
                        break;
                    }
                    break;

            }

        }


    void AnimPose6()
    {
        switch (currentPosePhase)
        {
            case 0:
                maskPlayer1.sprite = Pose6TransitionPre[currentPose];
                currentPose++;
                currentPose %= Pose6TransitionPre.Length;
                if (currentPose == 0)
                {
                    currentPosePhase++;
                }
                break;

            case 1:
                maskPlayer1.sprite = Pose6[currentPose];
                currentPose++;
                currentPose %= Pose6.Length;
                if (currentPose == 0)
                {
                    currentPosePhase++;
                }
                break;
            case 2:
                maskPlayer1.sprite = Pose6Idle[currentPose];
                currentPose++;
                currentPose %= Pose6Idle.Length;
                if (changePose)
                {
                    currentPosePhase++;
                }
                break;
            case 3:
                maskPlayer1.sprite = Pose6Transition[currentPose];
                currentPose++;
                currentPose %= Pose6Transition.Length;
                if (currentPose == 0)
                {
                    CancelInvoke();
                    InvokeRepeating("MainIdle", 0, 1 / timeAnimation);
                    break;
                }
                break;

        }

    }

    void AnimPose7()
    {
        switch (currentPosePhase)
        {
            case 0:
                maskPlayer1.sprite = Pose7TransitionPre[currentPose];
                currentPose++;
                currentPose %= Pose7TransitionPre.Length;
                if (currentPose == 0)
                {
                    currentPosePhase++;
                }
                break;

            case 1:
                maskPlayer1.sprite = Pose7[currentPose];
                currentPose++;
                currentPose %= Pose7.Length;
                if (currentPose == 0)
                {
                    currentPosePhase++;
                }
                break;
            case 2:
                maskPlayer1.sprite = Pose7Idle[currentPose];
                currentPose++;
                currentPose %= Pose7Idle.Length;
                if (changePose)
                {
                    currentPosePhase++;
                }
                break;
            case 3:
                maskPlayer1.sprite = Pose7Transition[currentPose];
                currentPose++;
                currentPose %= Pose7Transition.Length;
                if (currentPose == 0)
                {
                    CancelInvoke();
                    InvokeRepeating("MainIdle", 0, 1 / timeAnimation);
                    break;
                }
                break;

        }
    }

        void AnimPose9()
        {
            switch (currentPosePhase)
            {
                case 0:
                    maskPlayer1.sprite = Pose9TransitionPre[currentPose];
                    currentPose++;
                    currentPose %= Pose9TransitionPre.Length;
                    if (currentPose == 0)
                    {
                        currentPosePhase++;
                    }
                    break;

                case 1:
                    maskPlayer1.sprite = Pose9[currentPose];
                    currentPose++;
                    currentPose %= Pose9.Length;
                    if (currentPose == 0)
                    {
                        currentPosePhase++;
                    }
                    break;
                case 2:
                    Debug.Log(currentPose);
                    maskPlayer1.sprite = Pose9Idle[currentPose];
                    currentPose++;
                    currentPose %= Pose9Idle.Length;
                    if (Input.GetKey(KeyCode.Space))
                    {
                        gameManager.Restart();
                        animator.SetTrigger("Restart");
                        currentPosePhase++;
                    }
                    break;
                case 3:
                    maskPlayer1.sprite = Pose9Transition[currentPose];
                    currentPose++;
                    currentPose %= Pose9Transition.Length;
                    if (currentPose == 0)
                    {
                        CancelInvoke();
                        InvokeRepeating("MainIdle", 0, 1 / timeAnimation);
                        break;
                    }
                    break;

            }

        }

    void DisableChange()
    {
        changePose = false;
    }

*/
}
