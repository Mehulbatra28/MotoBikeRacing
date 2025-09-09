using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinTrigger : MonoBehaviour
{


public void OnTriggerEnter2D(Collider2D other)
{
    
    if(other.gameObject.CompareTag("Die"))
    {
        // Debug.Log("Collided with: " + collision.gameObject.name);
        var tag=other.gameObject.tag="TriggerPoint";
        Debug.Log("changed tag to"+tag);
    }
}
}
