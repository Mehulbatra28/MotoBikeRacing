using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public static SoundManager instance;
    public AudioClip[] AudioClips;
    public AudioSource BGSource;
    public AudioSource GameSource;
    public AudioSource BikeSource;
    private bool deathCanPlay = true;
    private float deathCooldown = 4f;
    private bool winCanPlay = true;
    private float winCooldown = 4f;

    void Awake()
    {
        if(instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
     public void OnDeathPlay()
     {
        if (deathCanPlay)
        {
            BGSource.PlayOneShot(AudioClips[2]);
            StartCoroutine(DeathCooldown());
        }
     }
     private IEnumerator DeathCooldown()
     {
        deathCanPlay = false;
        yield return new WaitForSeconds(deathCooldown);
        deathCanPlay = true;
     }
     public void OnWinPlay()
     {
        if (winCanPlay)
        {
            BGSource.PlayOneShot(AudioClips[4]);
            StartCoroutine(WinCooldown());
        }
     }
     private IEnumerator WinCooldown()
     {
        winCanPlay = false;
        yield return new WaitForSeconds(winCooldown);
        winCanPlay = true;
     }
     public void OnGameBgPlay()
     {
        BGSource.clip = AudioClips[1];
        BGSource.loop = true;
        BGSource.Play();
     }
     
     public void OnMenuBGPlay()
     {
        BGSource.clip = AudioClips[3];
        BGSource.loop = true;
        BGSource.Play();
     }
     public void OnBikePlay()
     {
        BikeSource.clip = AudioClips[0];
         BikeSource.loop = true;
        BikeSource.Play();
     }
     public void OnButtonClick()
     {
        GameSource.PlayOneShot(AudioClips[5]);
     }
     
     public void StopBackgroundMusic()
     {
        BGSource.Stop();
     }
     public void StopGameMusic()
     {
        BGSource.Stop();
     }
     public void StopBikeSource()
     {
      BikeSource.Stop();
     }
     public void PauseGameMusic()
     {
        BGSource.Pause();
     }
    
     
}
