using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Child of agent that seeks out a referenced target.
/// </summary>
public class Seeker : Agent
{
    /// <summary>
    /// Seeker steers towards the target and teleports it when it collides with it.
    /// </summary>
    protected override void CalcSteeringForce()
    {
        pb.ApplyForce(Seek(target) * Time.deltaTime);
        // Teleport the Target once seeker reachers it.
        if(CircleCollision(this.pb, target.pb))
        {
            target.pb.Teleport(new Vector2(
                Random.Range(-9, 9),
                Random.Range(-5, 5)
            ));
        }
    }

    /// <summary>
    /// Check collision between two sprites using Circle collision checking
    /// </summary>
    /// <param name="info1"></param>
    /// <param name="info2"></param>
    /// <returns></returns>
    private bool CircleCollision(PhysicsObject info1, PhysicsObject info2)
    {
        float dstSq = (info1.Position - info2.Position).sqrMagnitude;
        float contactDist = info1.Radius + info2.Radius;
        contactDist = contactDist * contactDist;

        return dstSq <= contactDist;
    }
}
