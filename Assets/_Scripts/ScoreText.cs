using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreText : MonoBehaviour {

    public GameManager gameManager;
    Text t;

	// Use this for initialization
	void Start () {
        t = gameObject.GetComponent<Text>();

	}
	
	// Update is called once per frame
	void Update () {

         t.text = gameManager.score.ToString();
    }
}
