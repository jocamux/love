using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Phase : MonoBehaviour
{
    //GameManager gameManager;

    public List<Step> possibleSteps;
    public List<int> probability;
    public float time;

    public float timeSound;

    public bool activated = false;



    public void Start()
    {
        //gameManager = gameObject.transform.parent.parent.gameObject.GetComponent<GameManager>();

    }

    public Phase(List <Step> steps, List <int> prob, float t)
    {
        possibleSteps = steps;
        probability = prob;
        time = t;

    }

    public Step GetRandomStep() {
        
        int sum = 0;
        int []aux = new int[probability.Capacity];
        for (int k = 0; k < probability.Capacity; ++k) {
            sum += probability[k];
            aux[k] = sum;
        }

        int ran = Random.Range(0, sum);
        for (int k=0; k< aux.Length; ++k)
        {
            if (aux[k] > ran) return possibleSteps[k];
        }
        return null;
    }

 
	// Update is called once per frame

}
