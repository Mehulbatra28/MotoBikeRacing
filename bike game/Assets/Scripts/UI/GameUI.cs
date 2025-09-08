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
    public GameObject WinPanel;
    public static GameUI instance;
     private PageState currentState;
   public enum PageState
    {
        Pause,
        Game,
        Death,
        Win
    }

   void Awake()
   {
    if(instance == null)
    {
        instance = this;
    }
   }
   void Start()
   {
     SetPageState(PageState.Game);
   }

   
    public void SetPageState(PageState newState)
    {
        currentState=newState;
        pausePanel.SetActive(false);
        GamePanel.SetActive(false);
        DeathPanel.SetActive(false);

        switch(currentState)
        {
            case PageState.Pause:
            pausePanel.SetActive(true);
            break;
            case PageState.Game:
            GamePanel.SetActive(true);
            break;
            case PageState.Death:
            DeathPanel.SetActive(true);
            break;
            case PageState.Win:
            WinPanel.SetActive(true);
            break;
        }
    

    }


   
     #region Pause

    public void OnPauseButtonClicked()
    {
        Time.timeScale = 0;
       SetPageState(PageState.Pause);
    }
    
    public void OnResumeButtonClicked()
    {
        Time.timeScale = 1;
       SetPageState(PageState.Game);
    }
    public void OnHomeButtonClicked()
    {
        SceneManager.LoadScene("Menu");
        
    }
    public void OnRestartButtonClicked()
    {
         Scene currentScene = SceneManager.GetActiveScene();
    SceneManager.LoadScene(currentScene.buildIndex);
        Time.timeScale=1;
    }
    #endregion

                   
    
    public void DeathPanelActive()
      {
          StartCoroutine(DeathPanelDelay());
      }
  
      IEnumerator DeathPanelDelay()
      {
          yield return new WaitForSeconds(3f);
         SetPageState(PageState.Death);
          Time.timeScale = 0;
      }
      public void WinPanelActive()
      {
        StartCoroutine(WinPanelDelay());
      } 
      IEnumerator WinPanelDelay()
      {
          yield return new WaitForSeconds(3f);
         SetPageState(PageState.Win);
          Time.timeScale = 0;
      }
    

}


