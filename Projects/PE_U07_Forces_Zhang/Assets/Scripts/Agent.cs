using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

/// <summary>
/// Class representing agents that steers forces based on a target.
/// </summary>
[RequireComponent(typeof(PhysicsObject))]
public abstract class Agent : MonoBehaviour
{
    // fields
    [SerializeField] public PhysicsObject pb;
    [SerializeField] protected Agent target;

    // properties
    public float MaxSpeed
    {
        get => pb.MaxSpeed;
    }

    public float MaxForce
    {
        get => pb.MaxForce;
    }

    // methods
    /// <summary>
    /// Defines behavior of the steering force for the agent class.
    /// </summary>
    protected abstract void CalcSteeringForce();

    void Update()
    {
        CalcSteeringForce();
        // face movement direction
        transform.rotation = Quaternion.LookRotation(Vector3.forward, pb.Velocity);
    }

    /// <summary>
    /// Returns a steering force to have agent seek out the target.
    /// </summary>
    /// <param name="target"></param>
    /// <returns></returns>
    public Vector3 Seek(Agent target)
    {
        Vector3 desiredVelocity = target.pb.Position - pb.Position;
        desiredVelocity = desiredVelocity.normalized * MaxSpeed;

        Vector3 seekingForce = desiredVelocity - pb.Velocity;
        seekingForce = seekingForce.normalized * MaxForce;

        return seekingForce;
    }

    /// <summary>
    /// Returns a steering force to have agent flee form the target.
    /// </summary>
    /// <param name="runAwayFrom"></param>
    /// <returns></returns>
    public Vector3 Flee(Agent runAwayFrom)
    {
        Vector3 desiredVelocity = pb.Position - runAwayFrom.pb.Position;
        desiredVelocity = desiredVelocity.normalized * MaxSpeed;

        Vector3 fleeingForce = desiredVelocity - pb.Velocity;
        fleeingForce = fleeingForce.normalized * MaxForce;

        return fleeingForce;
    }
}
