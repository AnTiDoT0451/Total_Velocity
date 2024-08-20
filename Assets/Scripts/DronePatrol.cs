using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DroneMovement : MonoBehaviour
{
    public Transform[] waypoints;
    public float speed = 5f;
    public float waypointTolerance = 0.1f;
    public float swayAmount = 0.5f;
    public float swaySpeed = 2f;

    private int currentWaypointIndex = 0;
    private bool movingForward = true;
    private Vector3 initialPosition;

    void Start()
    {
        if (waypoints.Length > 0)
        {
            initialPosition = transform.position;
        }
    }

    void Update()
    {
        MoveTowardsWaypoint();
    }

    void MoveTowardsWaypoint()
    {
        if (waypoints.Length == 0) return;

        Transform targetWaypoint = waypoints[currentWaypointIndex];
        Vector3 targetPosition = targetWaypoint.position;

        // Calculate the direction to the next waypoint
        Vector3 direction = (targetPosition - transform.position).normalized;

        // Move towards the waypoint
        transform.position = Vector3.MoveTowards(transform.position, targetPosition, speed * Time.deltaTime);

        // Sway effect on the Y-axis
        float sway = Mathf.Sin(Time.time * swaySpeed) * swayAmount;
        Vector3 swayPosition = new Vector3(transform.position.x, initialPosition.y + sway, initialPosition.z);

        // Apply sway while maintaining the initial Z position
        transform.position = swayPosition;

        // Check if the drone is close enough to the waypoint
        if (Vector3.Distance(transform.position, targetPosition) < waypointTolerance)
        {
            if (movingForward)
            {
                currentWaypointIndex++;
                if (currentWaypointIndex >= waypoints.Length)
                {
                    currentWaypointIndex = waypoints.Length - 1;
                    movingForward = false;
                }
            }
            else
            {
                currentWaypointIndex--;
                if (currentWaypointIndex < 0)
                {
                    currentWaypointIndex = 0;
                    movingForward = true;
                }
            }
        }
    }
}