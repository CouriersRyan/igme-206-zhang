using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleManager : MonoBehaviour
{
    private static ObstacleManager instance;

    public static ObstacleManager Instance
    {
        get
        {
            if(instance == null)
            {
                instance = FindAnyObjectByType<ObstacleManager>();

                if (instance == null)
                {
                    instance = new GameObject().AddComponent<ObstacleManager>();
                    instance.name = "Obstacle Manager";
                }
            }

            return instance;
        }
    }

    public List<Obstacle> obstacles = new List<Obstacle>();
}
