using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Pause : MonoBehaviour
{
 

  
    public void ResumeButton()
    {
        GameUI.instance.OnResumeButtonClicked();
    }

    public void HomeButton()
    {
        GameUI.instance.OnHomeButtonClicked();
    }
    public void RestartButton()
    {
        GameUI.instance.OnRestartButtonClicked();
        SoundManager.instance.OnGameBgPlay();
        SoundManager.instance.OnBikePlay();
    }
}
