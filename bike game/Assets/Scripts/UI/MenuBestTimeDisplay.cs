using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class MenuBestTimeDisplay : MonoBehaviour
{
    public TextMeshProUGUI level1BestText;
    public TextMeshProUGUI level2BestText;

    void Start()
    {
        // Level 1
        if (PlayerPrefs.HasKey("BestTime_Level1"))
            level1BestText.text = "Level 1 : " + FormatTime(PlayerPrefs.GetFloat("BestTime_Level1"));
        else
            level1BestText.text = "Level 1 : --:--";

        // Level 2
        if (PlayerPrefs.HasKey("BestTime_Level2"))
            level2BestText.text = "Level 2 : " + FormatTime(PlayerPrefs.GetFloat("BestTime_Level2"));
        else
            level2BestText.text = "Level 2 : --:--";
    }

    string FormatTime(float time)
    {
        int minutes = Mathf.FloorToInt(time / 60);
        int seconds = Mathf.FloorToInt(time % 60);
        return string.Format("{0:00}:{1:00}", minutes, seconds);
    }
}
