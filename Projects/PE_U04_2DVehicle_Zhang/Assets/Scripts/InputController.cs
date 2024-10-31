using UnityEngine;
using UnityEngine.InputSystem;

/// <summary>
/// Handles player inputs. Other components access this for important variables.
/// </summary>
public class InputController : MonoBehaviour
{
    private PlayerInput playerInput;
    private InputAction moveAction;
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
    }

    /// <summary>
    /// Set movement based input.
    /// </summary>
    /// <param name="context"></param>
    void OnMove(InputAction.CallbackContext context)
    {
        dir = context.ReadValue<Vector2>();
    }
}
