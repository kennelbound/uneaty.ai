using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIControlledLimb : MonoBehaviour
{
    public Vector3 Direction { get; private set; }
    public float Modifier = 0.1f;
#if UNITY_EDITOR
    public Vector3 LastDirection;
#endif

    public List<SimpleAIOutputConfig> Configurations
    {
        get
        {
            List<SimpleAIOutputConfig> configs = new List<SimpleAIOutputConfig>();
            configs.Add(new SimpleAIOutputConfig(Key, OutputType.Vector3));
            return configs;
        }
    }

    public int Count
    {
        get
        {
            int total = 0;
            foreach (SimpleAIOutputConfig config in Configurations)
            {
                total += config.Type == OutputType.Vector3 ? 3 : 1;
            }
            return total;
        }
    }

    public void Handle(IDictionary output)
    {
        Direction = (Vector3) output[Key];
        Vector3 newPos = transform.position + Direction*Modifier;
        transform.position = newPos;
#if UNITY_EDITOR
        LastDirection = Direction;
#endif
    }

    public String Key
    {
        get { return "AI-Limb-" + gameObject.GetInstanceID(); }
    }
}