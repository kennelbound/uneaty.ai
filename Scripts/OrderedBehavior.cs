using System.Collections.Generic;

public class OrderedBehavior : FitnessCalculator
{
    public List<FitnessCalculator> FitnessCalculators = new List<FitnessCalculator>();

    public override float GetFitness()
    {
        float output = 0f;
        foreach (FitnessCalculator calculator in FitnessCalculators)
        {
            float fitness = calculator.GetFitness();
            output += fitness;
            if (fitness < calculator.Threshold)
            {
                break;
            }
        }
        return output;
    }
}