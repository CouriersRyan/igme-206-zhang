using UnityEngine;

/// <summary>
/// Represents an object affected by physical forces such as gravity and friction.
/// </summary>
public class PhysicsObject : MonoBehaviour
{
    // fields
    [Header("Body")]
    private Vector3 position;
    private Vector3 direction;
    private Vector3 velocity;
    private Vector3 acceleration;
    [SerializeField] private float mass = 1;
    [SerializeField] private float maxSpeed = 500f;
    [SerializeField] private float maxForce = 50f;

    [SerializeField] private bool doBounce = true;

    [Header("Friction")]
    [SerializeField] private bool isFriction;
    [SerializeField] private float frictionCoefficient;

    [Header("Gravity")]
    [SerializeField] private bool isGravity = true;
    [SerializeField] private float gravity = 9.81f;

    private Camera cam;

    // properties
    public Vector3 Position
    {
        get => position;
    }

    public Vector3 Velocity
    {
        get => velocity;
    }

    public float MaxSpeed
    {
        get => maxSpeed;
    }

    public float MaxForce
    {
        get => maxForce;
    }

    public Vector3 Direction
    {
        get => direction;
    }

    // methods
    void Start()
    {
        cam = Camera.main;
        position = transform.position;
    }

    void FixedUpdate()
    {
        // Apply forces
        if (isGravity) ApplyGravity();
        if (isFriction) ApplyFriction();

        // Update velocity
        velocity += acceleration * Time.deltaTime;

        if (velocity.sqrMagnitude > maxSpeed * maxSpeed)
        {
            velocity = velocity.normalized * maxSpeed;
        }
        direction = velocity.normalized;

        // Update position
        position += velocity * Time.deltaTime;
        if (doBounce) Bounce();

        transform.position = position;

        // Reset Forces
        acceleration = Vector3.zero;
    }

    /// <summary>
    /// Teleport the physics body to set position.
    /// </summary>
    /// <param name="pos"></param>
    public void Teleport(Vector2 pos)
    {
        position = pos;
    }

    /// <summary>
    /// Applies friction to the acceleration. Force of friction is dependent on velocity.
    /// </summary>
    private void ApplyFriction()
    {
        Vector3 friction = -velocity.normalized * frictionCoefficient;
        ApplyForce(friction);
    }

    /// <summary>
    /// Applies gravity in a downward direction.
    /// </summary>
    private void ApplyGravity()
    {
        acceleration += Vector3.down * gravity;
    }

    /// <summary>
    /// Applies a generic force represented as a vector.
    /// </summary>
    /// <param name="force"></param>
    public void ApplyForce(Vector3 force)
    {
        acceleration += force / mass;
    }

    /// <summary>
    /// Cause the physics object to bounce against the edges of the screen.
    /// </summary>
    private void Bounce()
    {
        Vector3 screenPos = cam.WorldToScreenPoint(position);
        bool didBounce = false;

        // Check x-edges
        if (screenPos.x < 0)
        {
            screenPos.x = 0;
            velocity.x *= -1;
            didBounce = true;
        }
        else if (screenPos.x > cam.scaledPixelWidth)
        {
            screenPos.x = cam.scaledPixelWidth;
            velocity.x *= -1;
            didBounce = true;
        }

        // Check y-edges
        if (screenPos.y < 0)
        {
            screenPos.y = 0;
            velocity.y *= -1;
            didBounce = true;
        }
        else if (screenPos.y > cam.scaledPixelHeight)
        {
            screenPos.y = cam.scaledPixelHeight;
            velocity.y *= -1;
            didBounce = true;
        }

        // Apply positional changes if the object did bounce.
        if (didBounce)
        {
            position = Camera.main.ScreenToWorldPoint(screenPos);
        }
    }

}
