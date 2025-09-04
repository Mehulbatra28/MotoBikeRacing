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
    private bool isSoundOn = true;    // Track current sound state
    public Button SpeakerButton;
    [Header("Panels")]
    public GameObject creditsPanel;
    public GameObject MenuPanel;
    public GameObject LevelPanel;
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
    //     if(MenuPanel==null)
    //     {
    //     var x=GameObject.Find("MenuPanel");
    //     }
    //      if(LevelPanel==null){
    //     var y=GameObject.Find("LevelPanel");
    //      }
    //      if(creditsPanel==null)
    //      {
    //     var z=GameObject.Find("CreditsPanel");
    //      }
        SetPageState(PageState.Menu);
        // Get the Image component from the speaker button
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
            break;
            case PageState.Credits:
            creditsPanel.SetActive(true);
            break;
            case PageState.Level:
            LevelPanel.SetActive(true);
            break;
        }
    

    }

    public void OnPlayButtonClicked()
    {
       SetPageState(PageState.Level);
    }
    
    public void OnQuitButtonClicked()
    {
        Application.Quit();
    }
    
    public void OnSpeakerButtonClicked()
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
    
    public void OnCreditsButtonClicked()
    {
     SetPageState(PageState.Credits);
    }
    #endregion

    #region Credits
    public void OnBackButtonClicked()
    {
       SetPageState(PageState.Menu);
    }
    #endregion

   
}
