using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WinScript : MonoBehaviour
{
    public void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Player"))
        {
            UnlockNewLevel();
            Time.timeScale=0.5f;
            StartCoroutine(SceneDelay(2f));
            
            Debug.Log("HI");
        }
    }
    IEnumerator SceneDelay(float delaySeconds)
{
    yield return new WaitForSecondsRealtime(delaySeconds);
        Time.timeScale = 1f;
        SceneManager.LoadScene("Level2");
        
    yield return null;
 
    yield return new WaitUntil(()=>Time.time>10f);
 
}
void UnlockNewLevel()
{
    if(SceneManager.GetActiveScene().buildIndex>=PlayerPrefs.GetInt("ReachedIndex"))
    {
        PlayerPrefs.SetInt("ReachedIndex",SceneManager.GetActiveScene().buildIndex+1);
        PlayerPrefs.SetInt("unlockedlevel",PlayerPrefs.GetInt("unlockedlevel",1)+1);
        PlayerPrefs.Save();
    }
}
}
