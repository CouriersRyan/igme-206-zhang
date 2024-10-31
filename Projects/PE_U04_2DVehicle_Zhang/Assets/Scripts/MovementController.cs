using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Handles player movement given a direction which is gets from the InputController.
/// Also forces the player to wrap around when it hits the bounds of the camera.
/// </summary>
public class MovementController : MonoBehaviour
{
    private InputController inputController;

    [SerializeField] private float speed = 5.0f;

    private void Start()
    {
        inputController = GetComponent<InputController>();
    }

    private void FixedUpdate()
    {
        // Move so long as directional change isn't 0
        if (inputController.Direction != Vector2.zero)
        {
            // normalize and apply speed
            Vector2 dir = inputController.Direction.normalized * (speed * Time.deltaTime);
            // set new position based on directional vector
            Vector2 newPos = new Vector2(transform.position.x + dir.x,
                transform.position.y + dir.y);
            transform.position = newPos;

            // rotate player to face movement direction
            float angle = Mathf.Atan2(dir.x, dir.y) * Mathf.Rad2Deg;
            Quaternion rotation = Quaternion.AngleAxis(angle, -Vector3.forward);
            transform.rotation = rotation;
        }

        WrapOnEdge();
    }

    /// <summary>
    /// Teleports player character when they move outside of the camera's bounds. Warps them to the other side of the camera.
    /// </summary>
    private void WrapOnEdge()
    {
        bool wrappingOccured = false; // check if any wrapping condition is fulfilled.
        // Calculate wrapping in screen space (bounded by the camera)
        Vector2 screenPos = Camera.main.WorldToScreenPoint(transform.position);

        if (screenPos != null)
        {
            // Check for each camera bound and set player position to opposite bound.
            // X-Axis
            if (screenPos.x < 0)
            {
                screenPos.x = Camera.main.scaledPixelWidth;
                wrappingOccured = true;
            }
            else if (screenPos.x > Camera.main.scaledPixelWidth)
            {
                screenPos.x = 0;
                wrappingOccured = true;
            }

            // Y-Axis
            if (screenPos.y < 0)
            {
                screenPos.y = Camera.main.scaledPixelHeight;
                wrappingOccured = true;
            }
            else if (screenPos.y > Camera.main.scaledPixelHeight)
            {
                screenPos.y = 0;
                wrappingOccured = true;
            }

            // Apply the position change.
            if (wrappingOccured)
            {
                transform.position = Camera.main.ScreenToWorldPoint(screenPos);
            }
        }
    }
}
