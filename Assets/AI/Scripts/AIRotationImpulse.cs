using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class AIRotationImpulse : AIControlledLimb
{
    private Rigidbody _cachedRigidbody;

    public void Start()
    {
        _cachedRigidbody = GetComponent<Rigidbody>();
    }

    public new List<SimpleAIOutputConfig> Configurations
    {
        get
        {
            List<SimpleAIOutputConfig> configs = new List<SimpleAIOutputConfig>();
            configs.Add(new SimpleAIOutputConfig("AI-ImpulseRotation-" + name + "-" + gameObject.GetInstanceID(),
                OutputType.Vector3));
            return configs;
        }
    }

    public void Handle(IDictionary output)
    {
        Vector3 rotation =
            (Vector3) output["AI-ImpulseRotation-" + name + "-" + gameObject.GetInstanceID()] * Modifier;
        _cachedRigidbody.AddTorque(rotation, ForceMode.Impulse);
    }
}