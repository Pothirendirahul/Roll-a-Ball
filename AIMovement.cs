using UnityEngine;

public class AIMovement : MonoBehaviour
{
    public Transform[] waypoints;  // Array of waypoints for AI to follow
    private int currentWaypointIndex = 0;
    public float speed = 1f;  // Speed of the AI movement
    public float rotationSpeed = 1f;  // How quickly AI rotates towards the waypoint

    void Update()
    {
        // Move AI towards the current waypoint
        MoveTowardsWaypoint();
    }

    void MoveTowardsWaypoint()
    {
        if (currentWaypointIndex < waypoints.Length)
        {
            // Get direction towards the next waypoint
            Vector3 direction = waypoints[currentWaypointIndex].position - transform.position;
            
            // Move AI ball towards the waypoint
            transform.Translate(direction.normalized * speed * Time.deltaTime, Space.World);

            // Rotate AI to face the waypoint
            Quaternion targetRotation = Quaternion.LookRotation(direction);
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);

            // Check if AI reached the waypoint (within a small distance)
            if (Vector3.Distance(transform.position, waypoints[currentWaypointIndex].position) < 0.5f)
            {
                currentWaypointIndex++;  // Move to the next waypoint
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        // Check if the AI collides with a PickUp
        if (other.gameObject.CompareTag("PickUp"))
        {
            other.gameObject.SetActive(false);  // Disable the PickUp object
        }
    }
}
