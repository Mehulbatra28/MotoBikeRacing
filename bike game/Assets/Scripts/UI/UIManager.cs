using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    
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
    


 
    #region Menu
    void Awake()
    {
        if(instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject); // Prevent destruction when scenes change
        }
        else
        {
            Destroy(gameObject);
        }
    }
    
    void Start()
    {
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

    public void OnPlayButtonClicked()
    {
        SceneManager.LoadScene("Game");
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
        if (creditsPanel != null && MenuPanel != null)
        {
            creditsPanel.SetActive(true);
            MenuPanel.SetActive(false);
        }
        else
        {
            Debug.LogWarning("Credits panel or Menu panel is not assigned!");
        }
    }
    #endregion

    #region Credits
    public void OnBackButtonClicked()
    {
        creditsPanel.SetActive(false);
        MenuPanel.SetActive(true);
    }
    #endregion

   
}
