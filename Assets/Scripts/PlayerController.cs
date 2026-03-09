using System;
using System.Collections;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    // Public members
    public float horizontalAxis;
    public int fallSpeed;
    public ParticleSystem particle;
    public GameObject character;
    public AudioSource music;
    
    // Private members
    private Rigidbody2D _rb;
    private AudioSource _audio;
    private Animator _animator;
    private bool _isPaused;
    private int _defaultFallSpeed;
    private Vector3 _screenPoint;
    private Vector3 _offset;
    private bool _wasMouseDown = false;
    private float _xRange = 10f;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
        _audio = GetComponent<AudioSource>();
        _animator = character.GetComponent<Animator>();
        //_animator.Play("Movement");
        _defaultFallSpeed = fallSpeed;
        
        // Get the xRange from CheckOutOfBounds script
        CheckOutOfBounds checkBounds = GetComponent<CheckOutOfBounds>();
        if (checkBounds != null)
        {
            _xRange = checkBounds.xRange;
        }
    }
    // Update is called once per frame
    void Update()
    {
        // Handle mouse input anywhere on screen
        if (Input.GetMouseButton(0))
        {
            // Calculate offset on first mouse click
            if (!_wasMouseDown)
            {
                _screenPoint = Camera.main.WorldToScreenPoint(transform.position);
                _offset = transform.position - Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, _screenPoint.z));
                _wasMouseDown = true;
            }
            
            // Get the Z distance from camera to player
            Vector3 cursorScreenPoint = new Vector3(Input.mousePosition.x, Input.mousePosition.y, _screenPoint.z);
            Vector3 cursorPosition = Camera.main.ScreenToWorldPoint(cursorScreenPoint) + _offset;
            
            // Clamp the x position to stay within boundaries
            float clampedX = Mathf.Clamp(cursorPosition.x, -_xRange, _xRange);
            
            // Move player to follow mouse horizontally (with offset) while falling
            transform.position = new Vector3(clampedX, transform.position.y - fallSpeed * Time.deltaTime, transform.position.z);
        }
        else
        {
            // Reset mouse down flag when mouse is released
            _wasMouseDown = false;
            
            // Normal movement with arrow keys or WASD when not dragging
            horizontalAxis = Input.GetAxis("Horizontal");
            if (horizontalAxis != 0)
            {
                transform.Translate(Vector2.right * horizontalAxis / 10);
            }
            
            // Apply falling
            transform.Translate(Vector3.down * fallSpeed * Time.deltaTime);
        }
        
        // Check for pause key (Escape)
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            PauseOrStartGame();
        }
    }

    public static void PauseOrStartGame()
    {
        if (Time.timeScale == 0)
        {
            Time.timeScale = 1;
        }
        else
        {
            Time.timeScale = 0;
        }
    }

    private void OnCollisionEnter(Collision other)
    {
        Debug.Log("Something collided with the Player!");
        
        // If Player collides with Spike, end game
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

        // If player collides with a SpikeSet, then destroy the set
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
        SceneManager.LoadScene(0);
    }

    public void StopFalling()
    {
        fallSpeed = 0;
    }
}