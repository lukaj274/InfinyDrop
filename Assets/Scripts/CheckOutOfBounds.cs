using UnityEngine;

public class CheckOutOfBounds : MonoBehaviour
{
    public float xRange;
    public GameObject player;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        if (xRange == 0)
        {
            xRange = 10;
        }
    }

    // Update is called once per frame
    void Update()
    {
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

        if (gameObject.CompareTag("Spike") && transform.position.y > player.transform.position.y)
        {
            Destroy(transform.parent.gameObject);
        }
    }
}
