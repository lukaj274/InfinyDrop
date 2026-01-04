using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class CheckOutOfBounds : MonoBehaviour
{
    public float xRange;
    
    private GameObject _player;
    private List<GameObject> _spikes;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        _player = GameObject.FindGameObjectWithTag("Player");
        if (xRange == 0)
        {
            xRange = 10;
        }

        _spikes = new List<GameObject>();
    }

    // Update is called once per frame
    void Update()
    {
        // If this script is being used on a Player, then keep the Player within the xRange
        if (gameObject.CompareTag("Player"))
        {
            if (transform.position.x > xRange)
            {
                transform.position = new Vector3(xRange, transform.position.y, transform.position.z);
            }
            if (transform.position.x < -xRange)
            {
                transform.position = new Vector3(-xRange, transform.position.y, transform.position.z);
            }
        }

        // If this script is being used on a SpikeSet, then destroy the SpikeSet once it's out of bounds
        if (gameObject.CompareTag("SpikeSet") && transform.position.y > _player.transform.position.y + 5)
        {
            Debug.Log("This object should be destroyed");
            Debug.Log(ScoreManager.Score);
            Destroy(gameObject);
        }
    }
}
