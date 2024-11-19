using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Child of agent that flees from a referenced target.
/// </summary>
public class Fleer : Agent
{
    /// <summary>
    /// The fleer steers away from the target.
    /// </summary>
    protected override void CalcSteeringForce()
    {
        pb.ApplyForce(Flee(target) * Time.deltaTime);
    }
}
