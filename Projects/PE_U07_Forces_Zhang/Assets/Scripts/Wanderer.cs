using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Agent that wanders a
/// </summary>
public class Wanderer : Agent
{
    // fields
    [SerializeField] private float wanderTime = 1f;
    [SerializeField] private float wanderRadius = 1f;
    [SerializeField] private float padding = 20f;

    private float currWanderAngle = 0;

    //methods

    /// <summary>
    /// Override of Agent's Init, sets start steering force.
    /// </summary>
    protected override void Init()
    {
        currWanderAngle = Random.Range(-Mathf.PI, Mathf.PI);
    }

    /// <summary>
    /// Calculates total steering force as a sum of Wander and StayInBounds forces.
    /// </summary>
    protected override void CalcSteeringForce()
    {
        ultimaForce += Wander(ref currWanderAngle, Mathf.PI / 36, Mathf.PI, wanderTime, wanderRadius);
        //ultimaForce += StayInBounds(wanderTime, padding);

        pb.ApplyForce(ultimaForce * Time.deltaTime);
    }

    /// <summary>
    /// Visualizes ultima force.
    /// </summary>
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.black;
        Gizmos.DrawLine(transform.position, transform.position + ultimaForce);
    }
}
