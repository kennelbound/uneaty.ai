using System;

[Serializable]
public class AIExperimentConfig : ExperimentConfig
{
    public SensorBasedAI AIPrototype;

    void Awake()
    {
        InputNodes = AIPrototype.SensorCount;
        OutputNodes = AIPrototype.OutputCount;
    }
}