using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
            + spriteRenderer.bounds.extents.y + spriteRenderer.bounds.extents.y);
    }

    private void Update()
    {
        if (isActivelyChecking)
        {
            CollisionManager.Instance.CheckCollisions(this);
        }
    }
}
