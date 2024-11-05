using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CollisionManager : MonoBehaviour
{
    // Singleton
    private static CollisionManager instance;
    public static CollisionManager Instance
    {
        get
        {
            if(instance == null)
            {
                instance = new GameObject().AddComponent<CollisionManager>();
            }
            
            return instance;
        }
    }

    [SerializeField] private SpriteInfo[] collidables;
    [SerializeField] private TMP_Text collisionText;
    private bool isAABB = true;

    private void Awake()
    {
        instance = this;
    }

    /// <summary>
    /// Check a given collider against all listed obstacles.
    /// </summary>
    /// <param name="info"></param>
    /// <returns></returns>
    public bool CheckCollisions(SpriteInfo info)
    {
        
        bool didCollide = false;

        // Reset collisions then calculate collisions.
        info.ResetCollide();
        foreach (SpriteInfo collision in collidables)
        {
            collision.ResetCollide();
            didCollide = didCollide || TryCollision(info, collision);
        }

        return didCollide;
    }

    /// <summary>
    /// Perform collisions based on collision mode.
    /// </summary>
    /// <param name="info1"></param>
    /// <param name="info2"></param>
    /// <returns></returns>
    private bool TryCollision(SpriteInfo info1, SpriteInfo info2)
    {
        // Check collisions
        bool collision = false;
        if (isAABB)
        {
            collision = AABBCollision(info1, info2);
        }
        else
        {
            collision = CircleCollision(info1, info2);
        }

        // If any collision occured, run each colliding object's onCollide script.
        if (collision) {
            info1.OnCollide(info2);
            info2.OnCollide(info1);
        }

        return collision;
    }

    /// <summary>
    /// Check collision between two sprites using AABB
    /// </summary>
    /// <param name="info1"></param>
    /// <param name="info2"></param>
    /// <returns></returns>
    private bool AABBCollision(SpriteInfo info1, SpriteInfo info2)
    {
        // Check for all four bounds.
        return (
            info2.MinimumBounds.x < info1.MaximumBounds.x &&
            info2.MaximumBounds.x > info1.MinimumBounds.x &&
            info2.MaximumBounds.y > info1.MinimumBounds.y &&
            info2.MinimumBounds.y < info1.MaximumBounds.y
        );
    }

    /// <summary>
    /// Check collision between two sprites using Circle collision checking
    /// </summary>
    /// <param name="info1"></param>
    /// <param name="info2"></param>
    /// <returns></returns>
    private bool CircleCollision(SpriteInfo info1, SpriteInfo info2)
    {
        float dstSq = (info1.Center - info2.Center).sqrMagnitude;
        float radiiSq = Mathf.Pow(info1.Radius + info2.Radius, 2);

        return dstSq <= radiiSq;
    }

    /// <summary>
    /// Changes the active collision mode.
    /// </summary>
    public void ToggleCollision()
    {
        isAABB = !isAABB;
        if (collisionText != null)
        {
            // Update UI
            if (isAABB)
            {
                collisionText.text = "Active Collison Type: AABB";
            }
            else
            {
                collisionText.text = "Active Collison Type: Circle";
            }
        }
    }
}
