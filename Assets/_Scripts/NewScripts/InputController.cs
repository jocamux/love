using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputController : MonoBehaviour {

    public KeyCode pause;
    public KeyCode restart;

    public enum ControllerUsed
    {
        Keyboard,
        OneXboxController,
        TwoXboxControllers,
    }

    public ControllerUsed activeController;
    public KeyCode[] gameplayButtons; 
    public  int[] currentInput = new int[8] { 0, 0, 0, 0, 0, 0, 0, 0 };
    public  int[] correctInput = new int[8] { 0, 0, 0, 0, 0, 0, 0, 0 };



    public TimeController tc;
    public GameManager gc;

    private void Start()
    {
        
    }
    void Update () {

        if(Input.GetKeyDown(pause))
        {
            Debug.Log("Pause the game");
        }

        else if (Input.GetKeyDown(restart) && gc.gameOver)
        {
            Debug.Log("Try Again");

            gc.TryAgain();
        }
        if (gc.gameOver)
        {
            return;
        }
        foreach (KeyCode k in gameplayButtons)
        {
            if(Input.GetKeyDown(k))
            {
                EvaluateKeyPressed(k, 1);

            }
            if(Input.GetKeyUp(k))
            {
                EvaluateKeyPressed(k, -1);

            }
        }


       /* if (e.type == EventType.KeyDown)
        {
  
        }
        else if (e.type == EventType.KeyUp)
        {
            EvaluateKeyPressed(e.keyCode, -1);
        }*/

        /*bool inputCompared = CompareInput();

        if(inputCompared&&!gameOver)
        {
            gc.CorrectBeat();
               
        }*/



    }
    
    void EvaluateKeyPressed(KeyCode kc, int value)
    {
        //Debug.Log("Entra indeed");

        if (kc == pause && value == 1)
        {
            //Pause the game
        }

        for (int i = 0; i < gameplayButtons.Length; i++)
        {
            if (kc == gameplayButtons[i] && value == 1)
            {
                if (!tc.toleratesInput)
                {
                    //End the game
                    gc.GameOver();
                    return;
                }
                else
                {
                currentInput[i] = 1;
                    if (CompareInput())
                    {
                        gc.CorrectBeat();
                    }
                }
                
            }
            else if (kc == gameplayButtons[i] && value == -1)
            {
                currentInput[i] = 0;

            }

        }
        
    }

    public bool CompareInput()
    {
        
        if (currentInput.Length != correctInput.Length)
        {
            Debug.Log("Possible inputs are not properly set up");
            return false;
        }

        for (int k = 0; k < currentInput.Length; ++k)
        {
            if (currentInput[k] != correctInput[k]) return false;
        }
        return true;

    }

    public void AddPossibleInputs(List<KeyCode> possibleInputs)
    {
        correctInput = new int[] { 0, 0, 0, 0, 0, 0, 0, 0 };

        foreach (KeyCode k in possibleInputs)
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
    }

  
}
