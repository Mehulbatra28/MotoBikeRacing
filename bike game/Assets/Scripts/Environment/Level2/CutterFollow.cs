using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CutterFollow : MonoBehaviour
{
   public float moveForce=10f;
   public float torqueForce=5f;
   public Rigidbody2D rb;
   public bool isRotating=false;
    public static CutterFollow instance;

    void Awake()
    {
        if(instance==null)
        {
            instance=this;
        }
    }


void Start()
{
     rb=GetComponent<Rigidbody2D>();
     rb.freezeRotation = true;
}
public void CutterRotation()
{
    rb.freezeRotation = false;
    isRotating=true;
}
 public void OnCollisionEnter2D(Collision2D collision)
{
    if(collision.gameObject.CompareTag("TriggerPoint"))
    {
         Debug.Log("Collided with: " + collision.gameObject.name);
        DeathScript.instance.Die();
    }
}

void FixedUpdate()
{
    if(isRotating)
    {
        
        Vector2 direction=((Vector2)transform.position).normalized;

        rb.AddForce(direction*moveForce);
        float rollDirection=direction.x>=0?-1f:1f;
        rb.AddTorque(rollDirection*torqueForce);
    }
    
}
}
