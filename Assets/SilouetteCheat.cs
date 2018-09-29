using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SilouetteCheat : MonoBehaviour {

    public Pose PoseUP;
    public Pose PoseDOWN;
    public Pose PoseLEFT;
    public Pose PoseRIGHT;
    public Pose PoseVERTICAL;
    public Pose PoseHORIZONTAL;
    public Pose PoseLOVE;
    public Animator animator;
    Silouette silouette;

    public bool up;
    public bool down;
    public bool left;
    public bool right;
    public bool vertical;
    public bool horizontal;
    public bool love;


    public Pose PoseUPArrow;
    public Pose PoseDOWNArrow;
    public Pose PoseLEFTArrow;
    public Pose PoseRIGHTArrow;
    public Pose PoseVERTICALArrow;
    public Pose PoseHORIZONTALArrow;
    public Pose PoseLOVEArrow;

    public bool upArrow;
    public bool downArrow;
    public bool leftArrow;
    public bool rightArrow;
    public bool verticalArrow;
    public bool horizontalArrow;
    public bool loveArrow;



    // Use this for initialization
    void Start () {
        silouette = GetComponent<Silouette>();
	}

    // Update is called once per frame
    void Update() {
        if (up)
        {
            up = false;
            silouette.followingPose = PoseUP;
            silouette.currentStatus = 3;
        }
        if (down)
        {
            up = false;

        }
        if (left)
        {
            up = false;

        }
        if (right)
        {
            up = false;

        }

        if (upArrow)
        {
            upArrow = false;

            animator.SetTrigger("LeftChar_UP");
            silouette.followingPose = PoseUPArrow;
            silouette.currentStatus = 3;
        }
        if (downArrow)
        {
            downArrow = false;
            animator.SetTrigger("LeftChar_DOWN");
            silouette.followingPose = PoseUPArrow;
            silouette.currentStatus = 3;

        }
        if (leftArrow)
        {
            leftArrow = false;
            animator.SetTrigger("LeftChar_LEFT");
            silouette.followingPose = PoseUPArrow;
            silouette.currentStatus = 3;
        }
        if (rightArrow)
        {
            rightArrow = false;
            animator.SetTrigger("LeftChar_RIGHT");
            silouette.followingPose = PoseUPArrow;
            silouette.currentStatus = 3;
        }
    }
}
