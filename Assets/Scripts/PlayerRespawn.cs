using UnityEngine;

public class PlayerRespawn : MonoBehaviour
{
    public Transform checkpoint; // Assign the checkpoint Transform in the Inspector
    public float fallThreshold = -10f; // The Y position below which the player is considered to have fallen off the map
    public LevelTimer levelTimer; // Reference to the LevelTimer script
    public GameObject cameraHolder; // Reference to the camera holder object

    private Vector3 originalPosition;
    private Quaternion originalRotation;

    void Start()
    {
        originalPosition = transform.position;
        originalRotation = transform.rotation;

        // Optionally, find the LevelTimer script if not assigned
        if (levelTimer == null)
        {
            levelTimer = FindObjectOfType<LevelTimer>();
        }

        // Find the camera holder if not assigned
        if (cameraHolder == null)
        {
            cameraHolder = GameObject.FindWithTag("CameraHolder");
        }
    }

    void Update()
    {
        if (transform.position.y < fallThreshold || Input.GetKeyDown(KeyCode.F))
        {
            Respawn();
        }
    }

    void Respawn()
    {
        // Set player's position and rotation to the checkpoint's position and rotation
        transform.position = checkpoint.position;
        transform.rotation = checkpoint.rotation;

        // Reset the camera holder's rotation to (0,0,0)
        if (cameraHolder != null)
        {
            cameraHolder.transform.rotation = Quaternion.Euler(0, 0, 0); // Reset camera to (0,0,0)
        }

        // Optionally, reset the player's velocity if you're using a Rigidbody
        Rigidbody rb = GetComponent<Rigidbody>();
        if (rb != null)
        {
            rb.velocity = Vector3.zero;
        }

        // Reset the timer when the player respawns
        if (levelTimer != null)
        {
            levelTimer.ResetTimer();
        }
    }

    public void ResetPlayer()
    {
        // Reset player position and rotation to original
        transform.position = originalPosition;
        transform.rotation = originalRotation;

        // Reset the camera holder's rotation to (0,0,0)
        if (cameraHolder != null)
        {
            cameraHolder.transform.rotation = Quaternion.Euler(0, 0, 0); // Reset camera to (0,0,0)
        }

        // Reset the timer when the player is reset
        if (levelTimer != null)
        {
            levelTimer.ResetTimer();
        }
    }
}
