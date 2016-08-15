using UnityEngine;

public class RayCastingAISensor : MonoBehaviour
{
    public Vector3 Source = Vector3.zero;
    public Vector3 Direction = Vector3.forward;
    public float SensorRange = 1;

    public int Count
    {
        get { return 1; }
    }

    public float Sense()
    {
        if (float.IsNaN(1 / SensorRange))
        {
            SensorRange = 0.00001f;
        }

        RaycastHit hit;
        if (!float.IsNaN(transform.position.x) && Physics.Raycast(transform.position + Source,
            transform.TransformDirection(Direction.normalized), out hit, SensorRange))
        {
            float sensorModified = hit.distance/SensorRange;
            if (float.IsNaN(sensorModified))
            {
                sensorModified = 0f;
            }
            return 1 - sensorModified;
        }
        return 0;
    }
}