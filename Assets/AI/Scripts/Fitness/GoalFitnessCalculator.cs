using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Collider))]
public class GoalFitnessCalculator : FitnessCalculator
{
    public float TimeInGoal;
    public float TimesFound;

    public void OnTriggerStay(Collider other)
    {
        if (other.gameObject.CompareTag("Goal Zone"))
        {
            TimeInGoal += Time.deltaTime;
            TimesFound++;
        }
    }

    public override float GetFitness()
    {
        return TimeInGoal;
    }
}