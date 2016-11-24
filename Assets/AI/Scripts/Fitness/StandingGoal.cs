using UnityEngine;

public class StandingGoal : FitnessCalculator
{
    public Transform AlternativeTransform;
    public float TimeAboveThreshold;

    void FixedUpdate()
    {
        Transform t = AlternativeTransform ?? transform;
        if (transform.position.y > Threshold)
        {
            TimeAboveThreshold += Time.fixedDeltaTime;
        }
    }

    public override float GetFitness()
    {
        float retVal = TimeAboveThreshold;
        TimeAboveThreshold = 0;
        return retVal;
    }
}