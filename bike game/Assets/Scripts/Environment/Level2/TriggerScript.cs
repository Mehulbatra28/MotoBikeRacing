using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerScript : MonoBehaviour
{
  public void OnTriggerEnter2D(Collider2D other)
  {
    if(other.gameObject.CompareTag("TriggerPoint"))
    {
        CutterFollow.instance.CutterRotation();
        Debug.Log("trigger done");
          Debug.Log("Collided with: " + other.gameObject.name);
    }
  }
}
