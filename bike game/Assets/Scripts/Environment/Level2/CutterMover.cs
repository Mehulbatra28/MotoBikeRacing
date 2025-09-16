using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CutterMover : MonoBehaviour
{
   public float moveForce=50f;
   public float torqueForce=25f;
    public Vector2 direction;
   public Rigidbody2D rb;


void Start()
{
     rb=GetComponent<Rigidbody2D>();
     
     // Set a default direction (right) or use the direction field if set in inspector
     if(direction == Vector2.zero)
     {
         direction = Vector2.right;
     }

     // Start the coroutine
     StartCoroutine(CutterDelay());
}

 public void OnCollisionEnter2D(Collision2D collision)
{
    if(collision.gameObject.CompareTag("TriggerPoint"))
    {
         Debug.Log("Collided with: " + collision.gameObject.name);
        DeathScript.instance.Die();
    }
}
IEnumerator CutterDelay()
{
    // Wait for a short delay before starting movement
    yield return new WaitForSeconds(1.1f);
    
    rb.AddForce(direction*moveForce);
    float rollDirection=direction.x>=0?-1f:1f;
    rb.AddTorque(rollDirection*torqueForce);
}
}