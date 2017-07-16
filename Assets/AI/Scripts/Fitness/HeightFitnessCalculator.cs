using UnityEngine;

public class HeightFitnessCalculator : FitnessCalculator
{
    void FixedUpdate()
    {
        Transform t = transform;
        if (t.position.y > Threshold)
        {
            Threshold = t.position.y;
        }
    }

    public override float GetFitness()
    {
        return Threshold;
    }
}