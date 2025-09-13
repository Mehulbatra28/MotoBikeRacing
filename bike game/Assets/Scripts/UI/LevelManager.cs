using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    public GameObject[] Button;
    private void Awake()
    {
        if(PlayerPrefs.GetInt("levelUnlocked")==0)
        {
            PlayerPrefs.SetInt("levelUnlocked",1);
        }
    }

    void Start()
    {
        for(int i=0;i<Button.Length;i++)
        {
            Button[i].GetComponent<Button>().interactable=false;
        }
        for (int i = 1; i <= PlayerPrefs.GetInt("levelUnlocked"); i++)
        {
            Button[i - 1].GetComponent<Button>().interactable = true;
        }
    }
    public void LoadScene(int levelId)
    {
        SceneManager.LoadScene(levelId);
        SoundManager.instance.OnButtonClick();
        SoundManager.instance.StopBackgroundMusic();
        SoundManager.instance.OnGameBgPlay();
        SoundManager.instance.OnBikePlay();
        Time.timeScale=1f;
    }
}
