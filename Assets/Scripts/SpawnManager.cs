using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    private int _spawnTime;

    public static float SpawnRate;
    
    public List<GameObject> spikes;
    public List<GameObject> clouds; // To be added later
    public GameObject player;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        SpawnRate = 1.25f;

        // Quarter the SpawnRate if the game is in Hard Mode
        if (ScoreManager.ScoreMultiplier == 2)
        {
            SpawnRate /= 2;
        }
        
        InvokeRepeating(nameof(SpawnSpikeSet), 0, SpawnRate);
    }

    void SpawnSpikeSet()
    {
        Debug.Log($"Spawning 1 spike");
        
        var spawnPos = new Vector3(transform.position.x, spikes[0].transform.position.y, transform.position.z);
        
        var spawnRot = new Quaternion
        {
            eulerAngles = new Vector3(90, 0, 0)
        };
        
        Instantiate(spikes[0], spawnPos, spawnRot);
    }
}
