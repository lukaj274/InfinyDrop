using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    private int _spawnTime;
    
    public List<GameObject> spikes;
    public List<GameObject> clouds; // To be added later
    public GameObject player;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        InvokeRepeating("SpawnSpikes", 1, 1);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void SpawnSpikes()
    {
        Debug.Log($"Spawning 1 spike");
        Instantiate(spikes[0]);
    }
}
