/*
 * PE - U06 - Random
 * Ryan Zhang
 * https://docs.google.com/document/d/1QmIa5mm94qshlpU8wc-TsFr_Ftxnx0zCW2VlAwmgnM8/edit?usp=sharing
 */
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : Singleton<SpawnManager>
{
    // (Optional) Prevent non-singleton constructor use.
    protected SpawnManager() { }

    [SerializeField] private Sprite[] sprites;
    [SerializeField] private SpriteRenderer prefab;

    private List<GameObject> creatures = new List<GameObject>();

    // Spawn Rates
    private const float SpawnRateElephant = 0.25f;
    private const float SpawnRateTurtle = 0.2f;
    private const float SpawnRateSnail = 0.15f;
    private const float SpawnRateOctopus = 0.1f;
    private const float SpawnRateKanagaroo = 0.3f;

    /// <summary>
    /// Spawns a random number of random creatures at random positions.
    /// </summary>
    public void Spawn()
    {
        // pick a random number of creatures to spawn.
        int numToSpawn = Random.Range(1, 12);
        for (int i = 0; i < numToSpawn; i++)
        {
            // spawn a creature
            GameObject creature = SpawnCreature();
            creatures.Add(creature);
            // set position with normalized distrubtion
            creature.transform.position = new Vector2(Gaussian(0, 5), Gaussian(0, 2));
        }
    }

    /// <summary>
    /// Spawns a creature with a random color and sprite.
    /// </summary>
    /// <returns></returns>
    private GameObject SpawnCreature()
    {
        SpriteRenderer sr = Instantiate(prefab);
        sr.color = Random.ColorHSV();
        ChooseRandomCreature(sr);
        return sr.gameObject;
    }

    /// <summary>
    /// Deletes all spawned creatures.
    /// </summary>
    public void Cleanup()
    {
        foreach (GameObject creature in creatures)
        {
            Destroy(creature);
        }

    }

    /// <summary>
    /// Pick a random sprite from the list.
    /// </summary>
    /// <param name="sr"></param>
    private void ChooseRandomCreature(SpriteRenderer sr)
    {
        float rate = Random.Range(0.0f, 1.0f);
        // elephant
        if(rate < SpawnRateElephant)
        {
            sr.sprite = sprites[0];
        }
        // turtle
        else if(rate < SpawnRateElephant + SpawnRateTurtle)
        {
            sr.sprite = sprites[1];
        }
        // snail
        else if(rate < SpawnRateElephant + SpawnRateTurtle + SpawnRateSnail)
        {
            sr.sprite = sprites[2];
        }
        // octupus
        else if(rate < SpawnRateElephant + SpawnRateTurtle + SpawnRateSnail + SpawnRateOctopus)
        {
            sr.sprite = sprites[3];
        }
        // kangaroo
        else
        {
            sr.sprite = sprites[4];
        }
    }

    /// <summary>
    /// Provided by Professor Negrin in PE - U06 Writeup
    /// </summary>
    /// <param name="mean"></param>
    /// <param name="stdDev"></param>
    /// <returns></returns>
    private float Gaussian(float mean, float stdDev)
    {
        float val1 = Random.Range(0f, 1f);
        float val2 = Random.Range(0f, 1f);

        float gaussValue =
        Mathf.Sqrt(-2.0f * Mathf.Log(val1)) *
        Mathf.Sin(2.0f * Mathf.PI * val2);

        return mean + stdDev * gaussValue;
    }

}
