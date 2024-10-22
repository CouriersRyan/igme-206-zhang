using UnityEngine;
public class Wheeee : MonoBehaviour
{
    public Rigidbody rb;
    public Vector3 forceDirection = Vector3.forward;
    public float forceMagnitude = 10f;

    void Start()
    {
        // Add force to the Rigidbody when the script starts
        rb.AddForce(forceDirection * forceMagnitude, ForceMode.Impulse);
    }
}

