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
        int numberTimes = Random.Range(1, 5);
        Debug.Log($"Spawning {numberTimes} spike(s)");
        for (int i = 0; i < numberTimes; i++)
        {
            Instantiate(spikes[0]);
        }
    }
}
