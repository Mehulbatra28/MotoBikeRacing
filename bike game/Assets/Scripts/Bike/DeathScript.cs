using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DeathScript : MonoBehaviour
{
     public float upsideDownTime = 3f; // seconds before death
    private float timer = 0f;
  

    
    void Update()
    {
        // Check if bike is upside down (rotation > 90 and < 270)
        float zRot = transform.eulerAngles.z;
        bool isUpsideDown = (zRot > 90f && zRot < 270f);

        if (isUpsideDown)
        {
            timer += Time.deltaTime; // count time
            if (timer >= upsideDownTime)
            {
                Die();
            }
        }
        else
        {
            timer = 0f; // reset if bike gets up
        }
    }

    void Die()
    {
        GameUI.instance.DeathPanelActive();
        Debug.Log("Player Died - Bike stayed upside down too long!");
      
    }
}
