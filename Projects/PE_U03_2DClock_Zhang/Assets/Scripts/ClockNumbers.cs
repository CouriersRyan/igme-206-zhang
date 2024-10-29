/*
 * Ryan Zhang
 * PE - U03 - 2D Clock
 * https://docs.google.com/document/d/1XM8JzE5u0G8rFfbA_yE3toY6pZhOuQAjc2Wv7vxJxCg/edit?usp=sharing
 */

using UnityEngine;

public class ClockNumbers : MonoBehaviour
{
    // distance of clock numbers from center
    [SerializeField] private float numDistance = 2f;
    // amount of clock numbers to be created
    [SerializeField] private int numFaceNumbers = 12;
    // clock number prefab
    [SerializeField] private GameObject numFace;

    // Start is called before the first frame update
    void Start()
    {
        // calculate the angle between each clock number in radians
        float anglePerNumber = (2 * Mathf.PI) / numFaceNumbers;
        // the starting offset so that the numbers are properly lined up
        float offSet = Mathf.PI / 2;

        // we start with the biggest number because we that it should always be at the top at 12 o'clock.
        for (int i = numFaceNumbers; i > 0; i--)
        {
            // calculate where the number should go.
            Vector3 pointingVector = pointingVector = CreateRotateVector(numDistance, -anglePerNumber * i + offSet);
            Vector3 pos = transform.position + pointingVector;
            // instantiate number
            GameObject faceNumber = Instantiate (numFace, pos, Quaternion.identity);
            // set text to correct number
            faceNumber.GetComponent<TextMesh>().text = (i).ToString();
        }
    }

    /// <summary>
    /// Creates a vector based on a radius and rotation.
    /// </summary>
    /// <param name="radius"></param>
    /// <param name="angleRadians"></param>
    /// <returns></returns>
    private Vector2 CreateRotateVector(float radius, float angleRadians)
    {
        return new Vector2(
            Mathf.Cos(angleRadians) * radius, 
            Mathf.Sin(angleRadians) * radius
            );
    }
}
