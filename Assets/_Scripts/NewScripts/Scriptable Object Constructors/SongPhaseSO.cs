using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NewStep", menuName = "Song/SongPhase")]
public class SongPhaseSO : ScriptableObject
{
    public List<StepSO> possibleSteps;
    public List<int> stepProbability;
    public float time;
    public float timeSound;

    public bool activated = false;

    public StepSO GetRandomStep()
    {

        int sum = 0;
        int[] aux = new int[stepProbability.Capacity];
        for (int k = 0; k < stepProbability.Capacity; ++k)
        {
            sum += stepProbability[k];
            aux[k] = sum;
        }

        int ran = Random.Range(0, sum);
        for (int k = 0; k < aux.Length; ++k)
        {
            if (aux[k] > ran) return possibleSteps[k];
        }
        return null;
    }

    //Eventually it will contain a boll addUpPreviousPhasesSteps
}
