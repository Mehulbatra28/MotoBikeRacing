using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameUI : MonoBehaviour
{
    public GameObject pausePanel;
    public GameObject DeathPanel;
    public GameObject GamePanel;
    public static GameUI instance;
   

   void Awake()
   {
    if(instance == null)
    {
        instance = this;
    }
   }

     void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            OnPauseButtonClicked();
        }
    }
     #region Pause

    public void OnPauseButtonClicked()
    {
        Time.timeScale = 0;
        pausePanel.SetActive(true);
        GamePanel.SetActive(false);
    }
    
    public void OnResumeButtonClicked()
    {
        Time.timeScale = 1;
        pausePanel.SetActive(false);
        GamePanel.SetActive(true);
    }
    public void OnHomeButtonClicked()
    {
        SceneManager.LoadScene("Menu");
    }
    public void OnRestartButtonClicked()
    {
        SceneManager.LoadScene("Game");
    }
    #endregion

                   
    
    public void DeathPanelActive()
      {
          StartCoroutine(DeathPanelDelay());
      }
  
      IEnumerator DeathPanelDelay()
      {
          yield return new WaitForSeconds(3f);
          DeathPanel.SetActive(true);
          Time.timeScale = 0;
      }
    

}


