using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Contains information on the SpriteRenderer,
/// including Bounds, Center, Radius, and Color
/// </summary>
public class SpriteInfo : MonoBehaviour
{
    [SerializeField] private bool isActivelyChecking = false;

    private SpriteRenderer spriteRenderer;

    private float radius;

    public Vector2 MinimumBounds 
    {
        get { return spriteRenderer.bounds.min; }
    }
    public Vector2 MaximumBounds
    {
        get { return spriteRenderer.bounds.max; }
    }
    public Vector2 Center
    {
        get { return spriteRenderer.bounds.center; }
    }
    public float Radius { get => radius; }
    public Color SpriteColor
    {
        set { spriteRenderer.color = value; }
    }

    private void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        radius = Mathf.Sqrt(spriteRenderer.bounds.extents.x * spriteRenderer.bounds.extents.x
            + spriteRenderer.bounds.extents.y * spriteRenderer.bounds.extents.y);
    }

    private void Update()
    {
        if (isActivelyChecking)
        {
            CollisionManager.Instance.CheckCollisions(this);
        }
    }

    /// <summary>
    /// Call when there is a collision, get the other collider
    /// </summary>
    /// <param name="info"></param>
    public void OnCollide(SpriteInfo info)
    {
        this.SpriteColor = Color.red;
    }
    
    /// <summary>
    /// Call at the start of every collision check, reset values for collision.
    /// </summary>
    public void ResetCollide()
    {
        this.SpriteColor = Color.white;
    }
}
