using UnityEngine;

public class CameraController : MonoBehaviour
{
    public GameObject player;
    public int distanceFromPlayer;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(transform.position.x, player.transform.position.y - distanceFromPlayer, transform.position.z);
    }
}
