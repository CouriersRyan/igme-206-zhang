using UnityEngine;
using UnityEngine.InputSystem;

/// <summary>
/// Tracks position and inputs from the mouse so that it can pull the physics object towards the mouse when left-clicked.
/// </summary>
public class MouseTracker : MonoBehaviour
{
    [SerializeField] private PhysicsObject physicsObject;
    [SerializeField] private float multiplier = 5f;

    private InputAction mouseLeftClick;

    void Start()
    {
        mouseLeftClick = FindObjectOfType<PlayerInput>().actions.FindAction("LeftClick");
        mouseLeftClick.performed += MousePuller;
    }

    /// <summary>
    /// Applies a force based on the vector from the referenced PhysicsObject to the mouse.
    /// </summary>
    private void MousePuller(InputAction.CallbackContext context)
    {
        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Mouse.current.position.ReadValue());
        mousePos.z = physicsObject.Position.z;

        Vector3 force = mousePos - physicsObject.Position;

        physicsObject.ApplyForce(force * multiplier);
    }

    void OnDestroy()
    {
        mouseLeftClick.performed -= MousePuller;
    }
}
