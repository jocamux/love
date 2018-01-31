using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shadow : MonoBehaviour {

    public GameObject playerIcon;
    SpriteMask playerMask;
    SpriteMask thisShadowMask;

	// Use this for initialization
	void Start () {
        playerMask = playerIcon.GetComponent<SpriteMask>();
        thisShadowMask = gameObject.GetComponent<SpriteMask>();
		
	}
	
	// Update is called once per frame
	void Update () {
        thisShadowMask.sprite = playerMask.sprite;
	}
}
