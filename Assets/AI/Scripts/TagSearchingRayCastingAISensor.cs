using UnityEngine;

public class TagSearchingRayCastingAISensor : RayCastingAISensor
{
    public string Tag;

    public override float HitSensed(RaycastHit hit)
    {
        if (hit.collider.gameObject.CompareTag(Tag))
        {
            return base.HitSensed(hit);
        }
        return NoHitSensed();
    }
}