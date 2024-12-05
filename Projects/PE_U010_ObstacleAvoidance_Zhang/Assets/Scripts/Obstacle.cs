using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour
{
    [SerializeField] private float radius = 1f;

    public float Radius
    {
        get => radius;
    }

    private void Start()
    {
        ObstacleManager.Instance.obstacles.Add(this);
    }

    /// <summary>
    /// Visualizes ultima force.
    /// </summary>
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(transform.position, radius);
    }
}
