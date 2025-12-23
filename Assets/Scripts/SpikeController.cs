using UnityEngine;

public class SpikeController : MonoBehaviour
{
    private GameObject _player;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        _player = GameObject.FindWithTag("Player");
        transform.position = new Vector3(_player.transform.position.x, _player.transform.position.y - 10, -1);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
