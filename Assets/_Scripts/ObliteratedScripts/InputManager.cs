using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public  class InputManager : MonoBehaviour{

    //obliterated?
    public BackgroundManager bg; 
    public GameManager gameManager;
    public SceneManagement sc;

    public CameraShake cameraShake;
    public Silouette P1;
    public Silouette P2;

    public Step currentStep;

    public int affectedPlayer;
    public  bool pressTime=false ;
    public  bool dieTime = false;
    public bool win = false;
    public bool lose = false;
    public List<KeyCode> correctList = new List<KeyCode>();
    public static int[] correctInput = new int[8] { 0, 0, 0, 0, 0, 0, 0, 0 };
    public static int[] currentInput = new int [8]{ 0, 0, 0, 0, 0, 0, 0, 0 };

    /*void Update () {
       if (pressTime)
       {
           FillArrays();
       }

       else if (dieTime)
       {
           if (!SameArray(correctInput, currentInput) && !lose)
           {
               //you died
               gameManager.Die();
               //SceneManager.LoadScene(1);
               lose = true;


               //  Debug.Log("moriste wey");
           }



       }

       foreach (char c in Input.inputString)
       {
           foreach(KeyCode k in correctList )
           //if("Alpha"+c ==                    )
           {
               Debug.Log("Right");
           }
       }
       


    //if (Input.GetKeyDown ==)
    //if not press time-> die
}

void FillArrays()
    {
        //Filling correct list
        correctInput = new int[]{ 0, 0, 0, 0, 0, 0, 0, 0};
        foreach (KeyCode k in correctList)
        {
            if (k == KeyCode.D)
            {
                correctInput[0] = 1;
            }
            if (k == KeyCode.A)
            {
                correctInput[1] = 1;
            }
            else if (k == KeyCode.W)
            {
                correctInput[2] = 1;
            }
            else if (k == KeyCode.S)
            {
                correctInput[3] = 1;
            }
            else if (k == KeyCode.RightArrow)
            {
                correctInput[4] = 1;
            }
            else if (k == KeyCode.LeftArrow)
            {
                correctInput[5] = 1;
            }
            else if (k == KeyCode.UpArrow)
            {
                correctInput[6] = 1;
            }
            else if (k == KeyCode.DownArrow)
            {
                correctInput[7] = 1;
            }
        }
        //Filling current list

        if (Input.GetKey(KeyCode.D))
        {
            currentInput[0] = 1;
        }
        else currentInput[0] = 0;
        if (Input.GetKey(KeyCode.A))
        {
            currentInput[1] = 1;
        }
        else currentInput[1] = 0;
        if (Input.GetKey(KeyCode.W))
        {
            currentInput[2] = 1;
        }
        else currentInput[2] = 0;
        if (Input.GetKey(KeyCode.S))
        {
            currentInput[3] = 1;
        }
        else currentInput[3] = 0;
        if (Input.GetKey(KeyCode.RightArrow))
        {
            currentInput[4] = 1;
        }
        else currentInput[4] = 0;
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            currentInput[5] = 1;
        }
        else currentInput[5] = 0;
        if (Input.GetKey(KeyCode.UpArrow))
        {
            currentInput[6] = 1;
        }
        else currentInput[6] = 0;
        if (Input.GetKey(KeyCode.DownArrow))
        {
            currentInput[7] = 1;
        }
        else currentInput[7] = 0;

       // Debug.Log("correct" + correctInput[0].ToString() + correctInput[1].ToString() + correctInput[2].ToString() + correctInput[3] + correctInput[4].ToString() + correctInput[5] + correctInput[6].ToString() + correctInput[7]);

       // Debug.Log("current" + currentInput[0].ToString() + currentInput[1].ToString() + currentInput[2].ToString() + currentInput[3] + currentInput[4].ToString() + currentInput[5] + currentInput[6].ToString() + currentInput[7]);

        //Compare arrays
        if (SameArray(currentInput, correctInput) && currentStep != null && !win)
        {
            win = true;
                gameManager.score += 100;

            ExecuteAnimation(affectedPlayer, currentStep.pose);
            if(currentStep.changeColor)
            {
                bg.Changebg();
            }
            dieTime = true;
            pressTime = false;
            //Debug.Log("ganaste wey");
            cameraShake.ShakeCamera();
            //ejecutar animacion
            //score++
            
        }

        else if ((pressTime==false || DifferentInput())&&!lose)
        {
            lose = true;
            //you died
            //sc.GoToDeath();
            //Debug.Log("moriste wey");
            gameManager.Die();

        }

    }
    bool SameArray(int[] a, int[] b)
    {
        if (a.Length != b.Length) return false;
        else
        {
            for (int k=0; k < a.Length; ++k)
            {
                if (a[k] != b[k]) return false;
            }
            return true;
        }

    }//obliterated

    bool DifferentInput()
    {
        for (int i=0; i < currentInput.Length; ++i)
        {
            if (correctInput[i] - currentInput[i] == -1) return true;
        }

        return false;
    }//obliterated


    public void ExecuteAnimation(int player, int pose)
    {
        /*switch (pose)
        {
            case 1:
                if (player == 0)
                {
                    P1.nextPose = pose;
                    P1.hasToChange = true;
                }
                else if (player == 1)
                {
                    P2.nextPose = pose;
                    P2.hasToChange = true;
                }
                else if (player ==2)
                {
                    P1.nextPose = pose;
                    P1.hasToChange = true;

                    P2.nextPose = pose;
                    P2.hasToChange = true;
                }
        /*  break;

      case 2:
          if (player == 0)
          {
              P1.GoToPose2 = true;
          }
          else if (player == 1)
          {
              P2.GoToPose2 = true;
          }
          else if (player == 2)
          {
              P1.GoToPose2 = true;
              P2.GoToPose2 = true;
          }
          break;

      case 3:
          if (player == 0)
          {
              P1.GoToPose3 = true;
          }
          else if (player == 1)
          {
              P2.GoToPose3 = true;
          }
          else if (player == 2)
          {
              P1.GoToPose3 = true;
              P2.GoToPose3 = true;
          }
          break;

      case 4:
          if (player == 0)
          {
              P1.GoToPose4 = true;
          }
          else if (player == 1)
          {
              P2.GoToPose4 = true;
          }
          else if (player == 2)
          {
              P1.GoToPose4 = true;
              P2.GoToPose4 = true;
          }
          break;

      case 5:
          if (player == 0)
          {
              P1.GoToPose5 = true;
          }
          else if (player == 1)
          {
              P2.GoToPose5 = true;
          }
          else if (player == 2)
          {
              P1.GoToPose5 = true;
              P2.GoToPose5 = true;
          }
          break;

      case 6:
          if (player == 0)
          {
              P1.GoToPose6 = true;
          }
          else if (player == 1)
          {
              P2.GoToPose6 = true;
          }
          else if (player == 2)
          {
              P1.GoToPose6 = true;
              P2.GoToPose6 = true;
          }
          break;

      case 7:
          if (player == 0)
          {
              P1.GoToPose7 = true;
          }
          else if (player == 1)
          {
              P2.GoToPose7 = true;
          }
          else if (player == 2)
          {
              P1.GoToPose7 = true;
              P2.GoToPose7 = true;
          }
          break;
  }



    }//obliterated

    */
}
