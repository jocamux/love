using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NewPose", menuName = "Pose")]
public class Pose : ScriptableObject {

    public string namePose;
    public bool justOnce;
    public Sprite[] initPose;
    public Sprite[] loopPose;
    public Sprite[] extra;

    public int rewindFirstFrame; //When changing pose, from which frame in the initPose will start rewinding
}
