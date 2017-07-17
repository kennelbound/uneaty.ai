using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class AIImpulse : AIControlledLimb
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
            configs.Add(new SimpleAIOutputConfig("AI-ImpulseLeft-" + name + "-" + gameObject.GetInstanceID(),
                OutputType.Vector3));
            configs.Add(new SimpleAIOutputConfig("AI-ImpulseRight-" + name + "-" + gameObject.GetInstanceID(),
                OutputType.Vector3));
            return configs;
        }
    }

    public void Handle(IDictionary output)
    {
        Vector3 leftDirection = (Vector3) output["AI-ImpulseLeft-" + name + "-" + gameObject.GetInstanceID()] * Modifier;
        Vector3 rightDirection = (Vector3) output["AI-ImpulseRight-" + name + "-" + gameObject.GetInstanceID()] * Modifier;
        _cachedRigidbody.AddForceAtPosition(leftDirection, new Vector3(0f, 1f, .5f));
        _cachedRigidbody.AddForceAtPosition(rightDirection, new Vector3(1f, 1f, .5f));
    }
}