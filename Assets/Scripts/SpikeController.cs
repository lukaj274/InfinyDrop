using System;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class SpikeController : MonoBehaviour
{
    public GameObject spike;
    
    private GameObject _player;
    private List<GameObject> _spikes;
    private int _randomMax;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        _player = GameObject.FindWithTag("Player");
        _spikes = new List<GameObject>();
        _randomMax = 5;
        transform.position = new Vector3(0, _player.transform.position.y - 30, -1);
        
        SpawnSpikes();
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.y > _player.transform.position.y)
        {
            DestroyAllSpikes();
        }
    }

    private void OnDestroy()
    {
        DestroyAllSpikes();
    }
    
    public void DestroyAllSpikes()
    {
        foreach (var thisSpike in _spikes)
        {
            Destroy(thisSpike);
        }

        ScoreManager.Score++;
        Destroy(gameObject);
    }
    
    void SpawnSpikes()
    {
        // Choose a number of spikes and spawn them at a random x-axis within the range
        int numberToSpawn = Random.Range(3, _randomMax);
        for (int i = 0; i < numberToSpawn; i++)
        {
            _spikes.Add(Instantiate(spike, new Vector3(Random.Range(-10, 10), transform.position.y + 5, -1), transform.rotation, transform));
        }
    }
}
