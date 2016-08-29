using UnityEngine;

public abstract class FitnessCalculator : MonoBehaviour
{
    public float Modifier = 1.0f;
    public float Threshold = 1.0f;
    public abstract float GetFitness();
}