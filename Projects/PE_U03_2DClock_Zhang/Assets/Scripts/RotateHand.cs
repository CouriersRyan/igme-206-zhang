/*
 * Ryan Zhang
 * PE - U03 - 2D Clock
 * https://docs.google.com/document/d/1XM8JzE5u0G8rFfbA_yE3toY6pZhOuQAjc2Wv7vxJxCg/edit?usp=sharing
 */

using UnityEngine;

public class RotateHand : MonoBehaviour
{
    [SerializeField] private float turnAmount = 6f;
    [SerializeField] private bool useDeltaTime;

    private void Update()
    {
        if (useDeltaTime)
        {
            transform.Rotate(new Vector3(0, 0, turnAmount * Time.deltaTime));
        }
        else
        {
            transform.Rotate(new Vector3(0, 0, turnAmount));
        }
    }
}
