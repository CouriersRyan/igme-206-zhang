using UnityEngine;
using UnityEngine.InputSystem;

/// <summary>
/// Handles player inputs. Other components access this for important variables.
/// </summary>
public class InputController : MonoBehaviour
{
    private PlayerInput playerInput;
    private InputAction moveAction;
    private InputAction switchCollisionAction;
    private Vector2 dir;
    public Vector2 Direction
    {
        get => dir; set => dir = value;
    }

    private void Start()
    {
        playerInput = GetComponent<PlayerInput>();

        // Listen for movement inputs.
        moveAction = playerInput.actions.FindAction("Move");
        moveAction.started += OnMove;
        moveAction.performed += OnMove;
        moveAction.canceled += OnMove;

        switchCollisionAction = playerInput.actions.FindAction("SwitchCollision");
        switchCollisionAction.performed += OnSwitchCollisions;
    }

    /// <summary>
    /// Set movement based input.
    /// </summary>
    /// <param name="context"></param>
    void OnMove(InputAction.CallbackContext context)
    {
        dir = context.ReadValue<Vector2>();
    }

    /// <summary>
    /// Toggles the collision mode.
    /// </summary>
    /// <param name="context"></param>
    void OnSwitchCollisions(InputAction.CallbackContext context)
    {
        CollisionManager.Instance.ToggleCollision();
    }
}
