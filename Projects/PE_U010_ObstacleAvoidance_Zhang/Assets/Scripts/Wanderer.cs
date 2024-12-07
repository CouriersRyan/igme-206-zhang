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
    private Vector3 avoidanceForce;

    //methods

    /// <summary>
    /// Override of Agent's Init, sets start steering force.
    /// </summary>
    protected override void Init()
    {
        transform.rotation = Quaternion.Euler(0, 0, Random.Range(-180, 180));
    }

    /// <summary>
    /// Calculates total steering force as a sum of Wander and StayInBounds forces.
    /// </summary>
    protected override void CalcSteeringForce()
    {
        ultimaForce += Wander(ref currWanderAngle, Mathf.PI / 36, Mathf.PI / 4, wanderTime, wanderRadius);
        ultimaForce += StayInBounds(wanderTime, padding) * boundsScalar;
        avoidanceForce = AvoidObstacles();

        if (avoidanceForce.magnitude > 0)
        {
            pb.ApplyForce(avoidanceForce);
        }
        else
        {
            Vector3.ClampMagnitude(ultimaForce, MaxForce);
            pb.ApplyForce(ultimaForce);
        }
    }

    /// <summary>
    /// Visualizes variables for obstacle avoidance.
    /// </summary>
    private void OnDrawGizmos()
    {
        // Agent collision radius
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(transform.position, radius);
        
        // Avoidance Radius
        Gizmos.color = Color.cyan;
        Gizmos.DrawWireSphere(transform.position, avoidanceRadius);
        
        // All obstacles in avoidance radius
        foreach (var obstacle in trackedObstacles)
        {
            Gizmos.color = Color.black;
            Gizmos.DrawLine(transform.position, obstacle.transform.position);
        }

        // Current obstalce being avoided.
        if (mainObstacle != null)
        {
            Gizmos.color = Color.red;
            Gizmos.DrawLine(transform.position, mainObstacle.transform.position);
        }

        // Avoidance force
        Gizmos.color = Color.white;
        Gizmos.DrawLine(transform.position, transform.position + avoidanceForce);
        
        // Right Vector
        Gizmos.color = Color.yellow;
        Gizmos.DrawLine(transform.position, transform.position + new Vector3(-pb.Direction.y, pb.Direction.x, 0));
        
        // Forward Vector
        Gizmos.color = Color.blue;
        Gizmos.DrawLine(transform.position, transform.position + pb.Direction);
    }

}
