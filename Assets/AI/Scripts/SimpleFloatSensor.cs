using UnityEngine;

public class SimpleFloatSensor : MonoBehaviour, IAISensor<float>
{
    public virtual string Name { get; private set; }

    public virtual int InputsRequired
    {
        get { return 1; }
    }

    public virtual float Sense()
    {
        return 0f;
    }
}