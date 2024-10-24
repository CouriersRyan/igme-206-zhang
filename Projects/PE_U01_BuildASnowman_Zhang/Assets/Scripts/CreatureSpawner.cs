using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreatureSpawner : MonoBehaviour
{
    [SerializeField] private GameObject creaturePrefab;
    [SerializeField] private Vector3[] locations = new Vector3[3];

    // Start is called before the first frame update
    void Start()
    {
        if(locations.Length >= 3)
        {
            for (int i = 0; i < 3; i++)
            {
                if (locations[i] != null)
                {
                    Instantiate(creaturePrefab, locations[i], Quaternion.identity);
                }
                else
                {
                    Debug.LogError("Location at index " + i + " is not defined.");
                }
            }
        }
        else
        {
            Debug.LogError("Not enough locations assigned.");
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
