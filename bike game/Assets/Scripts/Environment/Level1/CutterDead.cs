using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CutterDead : MonoBehaviour
{
       public void OnCollisionEnter2D(Collision2D collision)
{
    if(collision.gameObject.CompareTag("Die"))
    {
         Debug.Log("Collided with: " + collision.gameObject.name);
        DeathScript.instance.Die();
    }
}
private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Die"))
        {
            
         Debug.Log("Collided with: " + other.gameObject.name);
        DeathScript.instance.Die();
        }
    }

}
