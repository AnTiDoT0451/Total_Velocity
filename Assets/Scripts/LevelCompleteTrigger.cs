using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LevelCompleteTrigger : MonoBehaviour
{
    public TextMeshProUGUI levelCompleteText;  // Reference to the UI Text element
    public Image levelCompleteImage;  // Reference to the Image element to show upon completion
    public LevelTimer levelTimer;  // Reference to the LevelTimer script
    public Button retryButton;  // Reference to the Retry button
    public Button exitButton;   // Reference to the Exit button

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            // Show the "Level Complete" image and text
            levelCompleteImage.gameObject.SetActive(true);
            levelCompleteText.gameObject.SetActive(true);

            // Show the result text
            levelTimer.resultText.gameObject.SetActive(true);

            // Hide the timer
            levelTimer.timerText.gameObject.SetActive(false);

            // Stop the timer
            levelTimer.StopTimer();

            // Activate the Retry and Exit buttons
            retryButton.gameObject.SetActive(true);
            exitButton.gameObject.SetActive(true);

            // Unlock the cursor
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }
    }

    public void RetryLevel()
    {
        // Reload the current scene to restart the level
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void ExitToMainMenu()
    {
        // Load the main menu scene (assuming it's at index 0)
        SceneManager.LoadScene(0);
    }
}