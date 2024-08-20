using UnityEngine;

public class PlayerRespawn : MonoBehaviour
{
    public Transform checkpoint; // Assign the checkpoint Transform in the Inspector
    public float fallThreshold = -10f; // The Y position below which the player is considered to have fallen off the map

    private Vector3 originalPosition;

    void Start()
    {
        originalPosition = transform.position;
    }

    void Update()
    {
        if (transform.position.y < fallThreshold)
        {
            Respawn();
        }
    }

    void Respawn()
    {
        transform.position = checkpoint.position;
        // Optionally, you can reset the player's velocity if you're using a Rigidbody
        Rigidbody rb = GetComponent<Rigidbody>();
        if (rb != null)
        {
            rb.velocity = Vector3.zero;
        }
    }

    public void ResetPlayer()
    {
        // Reset player position to original
        transform.position = originalPosition;
        transform.rotation = Quaternion.identity; // Optionally reset rotation to identity
    }
}