using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public GameObject pauseMenuCanvas; // Reference to the Pause Menu Canvas
    public PlayerMovement playerMovement; // Reference to the PlayerMovement script

    private bool isPaused = false;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (isPaused)
            {
                ResumeGame();
            }
            else
            {
                PauseGame();
            }
        }
    }

    public void PauseGame()
    {
        pauseMenuCanvas.SetActive(true); // Activate the Pause Menu Canvas
        Time.timeScale = 0f; // Freeze the game time
        isPaused = true;

        // Lock the cursor and make it visible
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;

        // Lock camera movement
        if (playerMovement != null)
        {
            playerMovement.SetPauseState(true);
        }
    }

    public void ResumeGame()
    {
        pauseMenuCanvas.SetActive(false); // Deactivate the Pause Menu Canvas
        Time.timeScale = 1f; // Resume the game time
        isPaused = false;

        // Lock the cursor and hide it
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;

        // Unlock camera movement
        if (playerMovement != null)
        {
            playerMovement.SetPauseState(false);
        }
    }

    public void ExitToMainMenu()
    {
        Time.timeScale = 1f; // Ensure time is resumed before loading the main menu
        SceneManager.LoadScene(0); // Load the main menu scene (assuming it's at index 0)
    }
}