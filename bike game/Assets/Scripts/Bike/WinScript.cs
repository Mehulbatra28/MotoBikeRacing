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
          levelUnlocked(2);
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
public void levelUnlocked(int nextLevel)
{
    PlayerPrefs.SetInt("levelUnlocked",nextLevel);
        Debug.Log("level unlocked");
}

}
