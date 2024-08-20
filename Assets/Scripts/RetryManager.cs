using UnityEngine;
using UnityEngine.SceneManagement;

public class RetryManager : MonoBehaviour
{
    public LevelTimer levelTimer;  // Reference to the LevelTimer script
    public PlayerRespawn playerRespawn;  // Reference to the PlayerRespawn script

    public void RetryLevel()
    {
        // Reset the level timer
        if (levelTimer != null)
        {
            levelTimer.ResetTimer();
        }

        // Reset player position
        if (playerRespawn != null)
        {
            playerRespawn.ResetPlayer();
        }

        // Reload the current scene to reset the level
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);

        // Lock the cursor
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }
}