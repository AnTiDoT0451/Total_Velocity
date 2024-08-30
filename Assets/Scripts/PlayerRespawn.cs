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

        // Reset the camera holder's rotation to align with the checkpoint's rotation
        if (cameraHolder != null)
        {
            // Set the camera holder's rotation to match the checkpoint's rotation
            cameraHolder.transform.rotation = checkpoint.rotation;

            // Reset both pitch (X rotation) and roll (Z rotation) to zero, ensure the camera faces forward
            Vector3 eulerAngles = cameraHolder.transform.eulerAngles;
            cameraHolder.transform.eulerAngles = new Vector3(0, eulerAngles.y, 0);
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

        // Reset the camera holder's rotation to the original rotation
        if (cameraHolder != null)
        {
            cameraHolder.transform.rotation = originalRotation;

            // Reset both pitch (X rotation) and roll (Z rotation) to zero, ensure the camera faces forward
            Vector3 eulerAngles = cameraHolder.transform.eulerAngles;
            cameraHolder.transform.eulerAngles = new Vector3(0, eulerAngles.y, 0);
        }

        // Reset the timer when the player is reset
        if (levelTimer != null)
        {
            levelTimer.ResetTimer();
        }
    }
}
