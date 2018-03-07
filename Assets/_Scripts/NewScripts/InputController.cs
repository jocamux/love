using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputController : MonoBehaviour {

    public KeyCode pause;
    public KeyCode[] gameplayButtons;
    static int[] currentInput = new int[8] { 0, 0, 0, 0, 0, 0, 0, 0 };
    static int[] correctInput = new int[8] { 0, 0, 0, 0, 0, 0, 0, 0 };
    public bool gameOver;



    public TimeController tc;
    public GameManager gc;

	void Update () {
        Event e = Event.current;
        if (e.type == EventType.KeyDown)
        {
            EvaluateKeyPressed(e.keyCode, 1);
        }
        else if (e.type == EventType.KeyUp)
        {
            EvaluateKeyPressed(e.keyCode, -1);
        }

        bool inputCompared = CompareInput();
        if(inputCompared&&!gameOver)
        {
            gc.CorrectBeat();
               
        }
        else if(gameOver)
        {
            return;
        }
        else
        {
            gc.GameOver();
        }

    }
    
    void EvaluateKeyPressed(KeyCode kc, int value)
    {
        if(kc == pause && value == 1)
        {
            //Pause the game
        }

        for (int i = 0; i < gameplayButtons.Length; i++)
        {
            if (kc == gameplayButtons[i])
            {
                if (!tc.toleratesInput)
                {
                    //End the game
                    Debug.Log("Game Over");
                    return;
                }
                else
                {
                    currentInput[i] += value;
                }
            }
        }
        
    }

    bool CompareInput()
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
}
