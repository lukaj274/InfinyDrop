using System;
using System.Collections;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    public float horizontalAxis;
    public int fallSpeed;
    public ParticleSystem particle;
    
    private Rigidbody2D _rb;
    private AudioSource _audio;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
        _audio = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        horizontalAxis = Input.GetAxis("Horizontal");
        if (horizontalAxis != 0)
        {
            transform.Translate(Vector2.right * horizontalAxis / 10);
        }
        transform.Translate(Vector3.down * fallSpeed * Time.deltaTime);
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        Debug.Log("Something collided with the Player!");
        if (other.gameObject.CompareTag("Spike"))
        {
            Debug.Log("Game will restart");
            
            Destroy(other.transform.parent.gameObject);
            
            particle.Play();
            _audio.Play();
            
            StartCoroutine(WaitAndChangeScene(1.5f));
        }

        else if (other.gameObject.CompareTag("SpikeSet"))
        {
            // Destroy the spike set, calling its OnDestroy event handler
            Destroy(other.gameObject);
        }
    }

    private void OnCollisionExit2D(Collision2D other)
    {
        // Once clouds are added, this method will be used for them
    }

    public void OnMove(AxisEventData eventData)
    {
        if (eventData.moveVector.x > 0)
        {
            _rb.AddForce(Vector2.right * 10);
            Debug.Log("Moving right");
        }
        if (eventData.moveVector.x < 0)
        {
            _rb.AddForce(Vector2.left * 10);
            Debug.Log("Moving left");
        }
    }

    IEnumerator WaitAndChangeScene(float seconds)
    {
        // Destroy the sprite renderer
        Destroy(GetComponent<SpriteRenderer>());
        
        // Stop the player from still falling
        StopFalling();
        
        // Wait 1 second
        yield return new WaitForSeconds(seconds);
        
        // Reload the scene
        SceneManager.LoadScene("Main 1");
    }

    public void StopFalling()
    {
        fallSpeed = 0;
    }
}
