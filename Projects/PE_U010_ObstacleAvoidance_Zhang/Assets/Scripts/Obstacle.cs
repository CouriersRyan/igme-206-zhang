using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Class representing an obstacle for obstacle avoidance.
/// </summary>
public class Obstacle : MonoBehaviour
{
    [SerializeField] private float radius = 1f;

    public float Radius
    {
        get => radius;
    }

    private void Start()
    {
        // Add obstacle to the manager.
        ObstacleManager.Instance.obstacles.Add(this);
    }

    /// <summary>
    /// Visualizes collision radius.
    /// </summary>
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(transform.position, radius);
    }
}
