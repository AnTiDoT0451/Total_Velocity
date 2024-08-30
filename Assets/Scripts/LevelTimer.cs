using UnityEngine;
using TMPro;

public class LevelTimer : MonoBehaviour
{
    public TextMeshProUGUI timerText;  // Timer display
    public TextMeshProUGUI resultText;  // Result display (Time: or Best Time:)
    private float startTime;
    private bool levelCompleted = false;
    private bool isPaused = false;  // New flag for pause state
    private float pausedTime;  // Time when paused
    private float bestTime = float.MaxValue;  // Store the best time

    void Start()
    {
        ResetTimer();
    }

    void Update()
    {
        if (!levelCompleted && !isPaused)  // Check if not paused
        {
            float timePassed = Time.time - startTime;
            UpdateTimerDisplay(timePassed);
        }
    }

    void UpdateTimerDisplay(float timePassed)
    {
        int minutes = Mathf.FloorToInt(timePassed / 60);
        float seconds = timePassed % 60;
        string timeText = minutes > 0 ? $"{minutes:0}:{seconds:00.000}" : $"{seconds:00.000}";
        timerText.text = timeText;
    }

    public void StopTimer()
    {
        levelCompleted = true;
        float finalTime = Time.time - startTime;
        UpdateResultText(finalTime);
        if (finalTime < bestTime)
        {
            bestTime = finalTime;
        }
    }

    public void ResetTimer()
    {
        levelCompleted = false;
        startTime = Time.time;
        timerText.text = "0:00.000";
        resultText.gameObject.SetActive(false); // Hide result text when resetting
        timerText.gameObject.SetActive(true); // Ensure timer text is visible
    }

    private void UpdateResultText(float finalTime)
    {
        if (finalTime < bestTime)
        {
            resultText.text = $"Best Time:\n{FormatTime(finalTime)}";
        }
        else
        {
            resultText.text = $"Time:\n{FormatTime(finalTime)}";
        }
        resultText.gameObject.SetActive(true); // Show result text
    }

    private string FormatTime(float time)
    {
        int minutes = Mathf.FloorToInt(time / 60);
        float seconds = time % 60;
        return minutes > 0 ? $"{minutes:0}:{seconds:00.000}" : $"{seconds:00.000}";
    }

    public void PauseTimer()
    {
        isPaused = true;
        pausedTime = Time.time - startTime;  // Capture time when paused
        timerText.gameObject.SetActive(false);  // Hide the timer
    }

    public void ResumeTimer()
    {
        isPaused = false;
        startTime = Time.time - pausedTime;  // Adjust start time
        timerText.gameObject.SetActive(true);  // Show the timer
    }
}