using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Pause : MonoBehaviour
{
 public Sprite speakerOnSprite;    // Sprite for when sound is on
    public Sprite speakerOffSprite;   // Sprite for when sound is off
    private Image speakerButtonImage;
    private bool isSoundOn = true;    // Track current sound state
    public Button SpeakerButton;

    void Start()
    {
        if (SpeakerButton != null)
        {
            speakerButtonImage = SpeakerButton.GetComponent<Image>();
            
            // Set initial sprite
            if (speakerButtonImage != null && speakerOnSprite != null)
            {
                speakerButtonImage.sprite = speakerOnSprite;
            }
        }
        else
        {
            Debug.LogWarning("SpeakerButton is not assigned in UIManager!");
        }
    }
    public void ResumeButton()
    {
        GameUI.instance.OnResumeButtonClicked();
    }
   public void SpeakerButtonActive()
    {
        // Toggle sound state
        isSoundOn = !isSoundOn;
        
        // Change the button image based on state
        if (speakerButtonImage != null)
        {
            if (isSoundOn)
            {
                if (speakerOnSprite != null)
                {
                    speakerButtonImage.sprite = speakerOnSprite;
                    // Add your sound on logic here
                    Debug.Log("Sound turned ON");
                }
            }
            else
            {
                if (speakerOffSprite != null)
                {
                    speakerButtonImage.sprite = speakerOffSprite;
                    // Add your sound off logic here
                    Debug.Log("Sound turned OFF");
                }
            }
        }
        else
        {
            Debug.LogWarning("Speaker button image component is null!");
        }
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
