using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    public enum PageState
    {
        Menu,
        Credits,
        Level
    }
    public static UIManager instance;
    [Header("Menu")]
    public Sprite speakerOnSprite;    // Sprite for when sound is on
    public Sprite speakerOffSprite;   // Sprite for when sound is off
    private Image speakerButtonImage;
    public bool isSoundOn = true;    // Track current sound state
    public Button SpeakerButton;
    [Header("Panels")]
    public GameObject creditsPanel;
    public GameObject MenuPanel;
    public GameObject LevelPanel;
    public GameObject VideoPanel;
    public GameObject BGImage;
    private PageState currentState;
    


 
    #region Menu
    void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
    }
    
    void Start()
    {
        SetPageState(PageState.Menu);
        
        // Load sound state from PlayerPrefs (default to true if not set)
        isSoundOn = PlayerPrefs.GetInt("SoundOn", 1) == 1;
        
        // Get the Image component from the speaker button
        if (SpeakerButton != null)
        {
            speakerButtonImage = SpeakerButton.GetComponent<Image>();
            
            // Set initial sprite based on loaded state
            UpdateSpeakerButtonSprite();
            
            // Apply audio state
            ApplyAudioState();
        }
        else
        {
            Debug.LogWarning("SpeakerButton is not assigned in UIManager!");
        }
    }

    public void SetPageState(PageState newState)
    {
        currentState=newState;
        MenuPanel.SetActive(false);
        creditsPanel.SetActive(false);
        LevelPanel.SetActive(false);

        switch(currentState)
        {
            case PageState.Menu:
            MenuPanel.SetActive(true);
            VideoPanel.SetActive(true);
            BGImage.SetActive(false);
            break;
            case PageState.Credits:
            creditsPanel.SetActive(true);
            VideoPanel.SetActive(false);
            BGImage.SetActive(true);
            break;
            case PageState.Level:
            LevelPanel.SetActive(true);
            VideoPanel.SetActive(false);
            BGImage.SetActive(true);
            break;
        }
    

    }

    public void OnPlayButtonClicked()
    {
        SetPageState(PageState.Level);
        SoundManager.instance.OnButtonClick();
    }
    
    public void OnQuitButtonClicked()
    {
        Application.Quit();
        SoundManager.instance.OnButtonClick();
    }
    
    public void OnSpeakerButtonClicked()
    {
        // Play button click sound only if sound is on
        if (isSoundOn)
        {
            SoundManager.instance.OnButtonClick();
        }
        
        // Toggle sound state
        isSoundOn = !isSoundOn;
        
        // Save state to PlayerPrefs
        PlayerPrefs.SetInt("SoundOn", isSoundOn ? 1 : 0);
        PlayerPrefs.Save();
        
        // Update button appearance and audio
        UpdateSpeakerButtonSprite();
        ApplyAudioState();
        
        Debug.Log("Sound turned " + (isSoundOn ? "ON" : "OFF"));
    }
    
    private void UpdateSpeakerButtonSprite()
    {
        if (speakerButtonImage != null)
        {
            if (isSoundOn)
            {
                if (speakerOnSprite != null)
                {
                    speakerButtonImage.sprite = speakerOnSprite;
                }
            }
            else
            {
                if (speakerOffSprite != null)
                {
                    speakerButtonImage.sprite = speakerOffSprite;
                }
            }
        }
    }
    
    private void ApplyAudioState()
    {
        if (SoundManager.instance != null)
        {
            if (isSoundOn)
            {
                // Unmute audio sources
                SoundManager.instance.BGSource.mute = false;
                SoundManager.instance.GameSource.mute = false;
                SoundManager.instance.BikeSource.mute=false;
                // Start background music
                SoundManager.instance.OnMenuBGPlay();
            }
            else
            {
                // Mute audio sources
                SoundManager.instance.BGSource.mute = true;
                SoundManager.instance.GameSource.mute = true;
                SoundManager.instance.BikeSource.mute=true;
                // Stop all sounds
                SoundManager.instance.BGSource.Stop();
                SoundManager.instance.GameSource.Stop();
                SoundManager.instance.BikeSource.Stop();
            }
        }
    }
    
    public void OnCreditsButtonClicked()
    {
        SetPageState(PageState.Credits);
        SoundManager.instance.OnButtonClick();
    }
    #endregion

    #region Credits
    public void OnBackButtonClicked()
    {
        SetPageState(PageState.Menu);
        SoundManager.instance.OnButtonClick();
    }
    #endregion

   
}
