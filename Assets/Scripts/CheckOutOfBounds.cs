using UnityEngine;

public class CheckOutOfBounds : MonoBehaviour
{
    public float xRange;
    private GameObject _player;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        _player = GameObject.FindGameObjectWithTag("Player");
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

        if (gameObject.CompareTag("Spike") && transform.position.y > _player.transform.position.y + 5)
        {
            Debug.Log("This object should be destroyed");
            Destroy(gameObject);
        }
    }
}
