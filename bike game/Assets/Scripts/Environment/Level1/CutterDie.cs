using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CutterDied : MonoBehaviour
{
   public void OnCollisionEnter2D(Collision2D collision)
{
    if(collision.gameObject.CompareTag("Die"))
    {
         Debug.Log("Collided with: " + collision.gameObject.name);
        DeathScript.instance.Die();
    }
}
}
