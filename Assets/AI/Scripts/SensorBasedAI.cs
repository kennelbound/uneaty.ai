using System;
using System.Collections.Generic;
using SharpNeat.Phenomes;
using UnityEngine;

public class SensorBasedAI : UnitController
{
    public List<SimpleFloatSensor> Sensors = new List<SimpleFloatSensor>();
    public List<AIControlledLimb> Limbs = new List<AIControlledLimb>();
    public List<FitnessCalculator> FitnessCalculators = new List<FitnessCalculator>();
    public Boolean AllowCollisions = false;

    private Collider _myCollider;

    private void Start()
    {
        _myCollider = gameObject.GetComponent<Collider>();
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.collider.gameObject.GetComponent<SensorBasedAI>() != null)
        {
            Physics.IgnoreCollision(other.collider, _myCollider);
        }
    }

    public void FixedUpdate()
    {
        if (!IsRunning)
        {
            return;
        }

        ISignalArray ia = Box.InputSignalArray;
        int index = 0;
        foreach (SimpleFloatSensor sensor in Sensors)
        {
            ia[index++] = sensor.Sense();
        }

        // Execute the sensor logic, and routing through the neural network
        Box.Activate();

        ISignalArray oa = Box.OutputSignalArray;
        index = 0;
        Dictionary<string, object> values = new Dictionary<string, object>(); // This may cause a mem leak.
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
        get { return Sensors.Count; }
    }

    public int OutputCount
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