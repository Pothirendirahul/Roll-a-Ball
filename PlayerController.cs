using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using TMPro;

public class PlayerController : MonoBehaviour
{
    public TMP_Text countText;
    public TMP_Text WinText;
    private Rigidbody rb;
    public float speed = 10.0f;
    private AudioSource pop;
    private AudioSource gameOverAudio;  // Audio for Game Over  
    private float movementX;
    public TMP_Text gameOverText;
    private float movementY;

    private int count;


    // Start is called before the first frame update
    void Start()
    {
        count = 0;
        SetCountText();
        pop = GetComponent<AudioSource>();
        rb = GetComponent<Rigidbody>();
        WinText.gameObject.SetActive(false);
        gameOverText.gameObject.SetActive(false);
        gameOverAudio = gameObject.AddComponent<AudioSource>();
    }

    void OnMove(InputValue movementValue)  // Capitalized the method name 'OnMove' to follow Unity's convention.
    {
        Vector2 movementVector = movementValue.Get<Vector2>();

        movementX = movementVector.x;
        movementY = movementVector.y;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Vector3 movement = new Vector3(movementX, 0.0f, movementY);  // Fixed the typo here with 'Vector3'
        rb.AddForce(movement * speed);
    }

     

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("PickUp"))
        {
            other.gameObject.SetActive(false);

            count++;
            SetCountText();
            pop.Play();
        }
        else if (other.gameObject.CompareTag("Collinders")) // Check if collided with the Cylinder
        {
            GameOver(); // Call Game Over method when hitting the cylinder
        }


    }



    void SetCountText()
    {
        countText.text = "Count: " + count.ToString();
        if (count >= 12)
        {
            WinText.gameObject.SetActive(true);
        }

    }


    void GameOver()
    {
        Debug.Log("GameOver function called");  // This will log when the GameOver function is called
        gameOverText.gameObject.SetActive(true);  // Make the GameOver text visible
        gameOverAudio.Play();

        // Stop the player's movement by setting velocity to zero
        rb.velocity = Vector3.zero;
        rb.angularVelocity = Vector3.zero;

        // Optionally, freeze the Rigidbody so it no longer moves
        rb.constraints = RigidbodyConstraints.FreezeAll;

        // Disable player input by stopping movement
        movementX = 0;
        movementY = 0;
    }

}

