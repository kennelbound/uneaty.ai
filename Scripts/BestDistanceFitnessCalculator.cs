using UnityEngine;

public class BestDistanceFitnessCalculator : FitnessCalculator
{
    private float _maxHeight;

    public void FixedUpdate()
    {
        if(!float.IsNaN(transform.position.y))
        _maxHeight = Mathf.Abs(transform.position.y);
    }

    public override float GetFitness()
    {
        return _maxHeight*Modifier;
    }
}