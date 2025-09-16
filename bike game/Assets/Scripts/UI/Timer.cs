using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Timer : MonoBehaviour
{
    private float currentTime = 0f;
    public TextMeshProUGUI timerText;       
    private bool isRunning = true;
    public static Timer instance;

    [Header("Level Settings")]
    public int levelIndex = 1;   

    void Awake()
    {
        if(instance==null)
        {
            instance=this;
        }
    }

    void Update()
    {
        if (isRunning)
        {
            currentTime += Time.deltaTime;
            UpdateTimerUI();
        }
    }

    void UpdateTimerUI()
    {
        int minutes = Mathf.FloorToInt(currentTime / 60);
        int seconds = Mathf.FloorToInt(currentTime % 60);
        timerText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }

    // Call this when the level ends
    public void SaveBestTime()
    {
        string key = "BestTime_Level" + levelIndex;

        if (!PlayerPrefs.HasKey(key) || currentTime < PlayerPrefs.GetFloat(key))
        {
            PlayerPrefs.SetFloat(key, currentTime);
            PlayerPrefs.Save();
            Debug.Log("New Best Time Saved for Level " + levelIndex + ": " + currentTime);
        }
    }

    public void StopTimer() => isRunning = false;
}
