using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Menu : MonoBehaviour
{
   

   public void PlayButton()
   {
    UIManager.instance.OnPlayButtonClicked();
   }
   public void SpeakerButton()
   {
    UIManager.instance.OnSpeakerButtonClicked();
   }
   public void CreditsButton()
   {
    UIManager.instance.OnCreditsButtonClicked();
   }

}
