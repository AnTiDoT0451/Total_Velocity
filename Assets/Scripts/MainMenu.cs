using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    // This method will be called when the Play button is clicked
    public void PlayGame()
    {
        // Assuming your game scene is the next scene in the build index
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    // This method will be called when the Exit button is clicked
    public void ExitGame()
    {
        // Quit the application
        Debug.Log("Exit Game");
        Application.Quit();
    }

    // Method to return to the main menu
    public void ReturnToMainMenu()
    {
        // Load the main menu scene (assuming it's at index 0)
        SceneManager.LoadScene(0);
    }
}