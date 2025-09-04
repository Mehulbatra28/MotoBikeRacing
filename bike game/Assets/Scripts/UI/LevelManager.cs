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

    void start()
    {
        for(int i=0;i<Button.Length;i++)
        {
            Button[i].GetComponent<Button>().enabled=false;
        }
        for(int i=1;i<=PlayerPrefs.GetInt("levelUnlocked");i++)
        {
            Button[i-1].GetComponent<Button>().enabled=true;
        }
    }
    public void LoadScene(int levelId)
    {
        SceneManager.LoadScene(levelId);
    }
}
