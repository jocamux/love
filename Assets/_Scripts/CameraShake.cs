using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraShake : MonoBehaviour {

    Animator animator;
	// Use this for initialization
	void Start () {
        animator = gameObject.GetComponentInParent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {
	}

    public void ShakeCamera()
    {
        animator.SetTrigger("Shake");

    }
}
