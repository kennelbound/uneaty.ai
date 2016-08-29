using System.Collections.Generic;
using SharpNeat.Phenomes;
using UnityEngine;

public class SensorBasedAI : UnitController
{
    public List<RayCastingAISensor> Sensors = new List<RayCastingAISensor>();
    public List<AIControlledLimb> Limbs = new List<AIControlledLimb>();
    public List<FitnessCalculator> FitnessCalculators = new List<FitnessCalculator>();

    public void FixedUpdate()
    {
        if (!IsRunning)
        {
            return;
        }

        ISignalArray ia = Box.InputSignalArray;
        int index = 0;
        foreach (RayCastingAISensor sensor in Sensors)
        {
            ia[index++] = sensor.Sense();
        }

        Box.Activate();

        ISignalArray oa = Box.OutputSignalArray;
        index = 0;
        Dictionary<string, object> values = new Dictionary<string, object>();
        foreach (AIControlledLimb limb in Limbs)
        {
            foreach (SimpleAIOutputConfig config in limb.Configurations)
            {
                switch (config.Type)
                {
                    case OutputType.Float:
                        values[config.OutputKey] = (float) oa[index++];
                        break;
                    case OutputType.Integer:
                        values[config.OutputKey] = (int) oa[index++];
                        break;
                    case OutputType.Boolean:
                        values[config.OutputKey] = oa[index++] > 0.5f;
                        break;
                    case OutputType.Vector3:
                        values[config.OutputKey] = new Vector3((float) oa[index++], (float) oa[index++],
                            (float) oa[index++]);
                        break;
                }
            }
        }
        foreach (AIControlledLimb limb in Limbs)
        {
            limb.Handle(values);
        }
    }

    public override float GetFitness()
    {
        float total = 0;
        foreach (FitnessCalculator calculator in FitnessCalculators)
        {
            total += calculator.GetFitness();
        }
        return total;
    }

    public int SensorCount
    {
        get
        {
            int total = 0;
            foreach (RayCastingAISensor sensor in Sensors)
            {
                total += sensor.Count;
            }
            return total;
        }
    }

    public
        int OutputCount
    {
        get
        {
            int total = 0;
            foreach (AIControlledLimb limb in Limbs)
            {
                total += limb.Count;
            }
            return total;
        }
    }
}