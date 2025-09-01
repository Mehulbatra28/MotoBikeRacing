using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pause : MonoBehaviour
{
    public void ResumeButton()
    {
        GameUI.instance.OnResumeButtonClicked();
    }
    public void SpeakerButton()
    {
        UIManager.instance.OnSpeakerButtonClicked();
    }
    public void HomeButton()
    {
        GameUI.instance.OnHomeButtonClicked();
    }
    public void RestartButton()
    {
        GameUI.instance.OnRestartButtonClicked();
    }
}
