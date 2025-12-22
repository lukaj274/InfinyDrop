using System;
using UnityEngine;
using UnityEngine.EventSystems;

public class PlayerController : MonoBehaviour
{
    public float jumpForce;
    public float horizontalAxis;
    
    private Rigidbody2D rb;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        
        if (jumpForce <= 0)
        {
            jumpForce = 1;
        }
    }

    // Update is called once per frame
    void Update()
    {
        horizontalAxis = Input.GetAxis("Horizontal");
        if (horizontalAxis != 0)
        {
            transform.Translate(Vector2.right * horizontalAxis / 10);
        }
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        throw new NotImplementedException();
    }

    private void OnCollisionExit2D(Collision2D other)
    {
        throw new NotImplementedException();
    }

    public void OnMove(AxisEventData eventData)
    {
        if (eventData.moveVector.x > 0)
        {
            rb.AddForce(Vector2.right * 10);
            Debug.Log("Moving right");
        }
        if (eventData.moveVector.x < 0)
        {
            rb.AddForce(Vector2.left * 10);
            Debug.Log("Moving left");
        }
    }
    
    
}
