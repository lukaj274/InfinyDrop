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
    public GameObject character;
    public AudioSource music;
    
    private Rigidbody2D _rb;
    private AudioSource _audio;
    private Animator _animator;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
        _audio = GetComponent<AudioSource>();
        _animator = character.GetComponent<Animator>();
        _animator.Play("Land");
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

    private void OnCollisionEnter(Collision other)
    {
        Debug.Log("Something collided with the Player!");
        if (other.gameObject.CompareTag("Spike"))
        {
            // Print message to console
            Debug.Log("Game will restart");
            
            // Destroy the character and spike
            Destroy(other.transform.parent.gameObject);
            Destroy(character);
            
            // Play audio and visual effects
            music.Stop();
            particle.Play();
            _audio.Play();
            
            // Wait 1.5 seconds and then change the scene
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
        // Stop the player from still falling
        StopFalling();
        
        // Wait 1 second
        yield return new WaitForSeconds(seconds);
        
        // Reload the scene
        SceneManager.LoadScene("3D-Main-PC");
    }

    public void StopFalling()
    {
        fallSpeed = 0;
    }
}