using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public GameObject player;  // Reference to the player (ball)
    private Vector3 offset;    // Offset between the camera and player

    // Start is called before the first frame update
    void Start()
    {
        // Set the initial offset based on current camera and player positions
        offset = new Vector3(0, 10, -10);  // Adjust this as needed for distance/height
    }

    // Update is called once per frame
    void LateUpdate()
    {
        // Update the camera position to follow the player with the offset
        transform.position = player.transform.position + offset;
    }
}
