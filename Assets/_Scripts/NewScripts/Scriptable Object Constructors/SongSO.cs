using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NewStep", menuName = "Song/Song")]
public class SongSO : ScriptableObject
{
    public AudioClip audioClip;
    public AudioClip[] changePhaseClips;
    public float beatDuration;
    public int stepsInBeat;
    public int[] beatPerPhase; //Lenght = number of phases;
    public bool[] toleratesInput;
    public int correctHitBeat;

    public SongPhaseSO[] songPhasesSteps;

}
