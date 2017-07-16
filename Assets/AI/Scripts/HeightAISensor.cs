public class HeightAISensor : SimpleFloatSensor
{
    public float Sense()
    {
        if (float.IsNaN(transform.position.y)) return 0;
        return transform.position.y;
    }
}