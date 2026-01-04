using UnityEngine;

public class CameraController : MonoBehaviour
{
    public GameObject player;
    public int distanceFromPlayer;
    
    void Update()
    {
        // Keep the camera in the center of the view
        transform.position = new Vector3(transform.position.x, player.transform.position.y - distanceFromPlayer, transform.position.z);
    }
}
