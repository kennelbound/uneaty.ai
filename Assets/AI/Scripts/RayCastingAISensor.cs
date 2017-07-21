using UnityEngine;

public class RayCastingAISensor : SimpleFloatSensor
{
    public Vector3 Source = Vector3.zero;
    public Vector3 Direction = Vector3.forward;
    public float SensorRange = 1;
    public float LastSensorValue = 0f;

    public override float Sense()
    {
        if (float.IsNaN(1 / SensorRange))
        {
            SensorRange = 0.00001f;
        }

        RaycastHit hit;
        if (!float.IsNaN(transform.position.x) &&
            Physics.Raycast(transform.position + Source, transform.TransformDirection(Direction.normalized), out hit,
                SensorRange))
        {
            LastSensorValue = HitSensed(hit);
        }
        else
        {
            LastSensorValue = NoHitSensed();
        }

        return LastSensorValue;
    }

    public virtual float HitSensed(RaycastHit hit)
    {
        return RangeAffectedValue(1, hit.distance);
    }

    public virtual float NoHitSensed()
    {
        return 0f;
    }

    public virtual float RangeAffectedValue(float sensorValue, float distance)
    {
        float sensorModified = distance / SensorRange;
        if (float.IsNaN(sensorModified))
        {
            sensorModified = 0f;
        }
        return sensorValue - sensorModified;
    }
}