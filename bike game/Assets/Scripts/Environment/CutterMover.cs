using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CutterMover : MonoBehaviour
{
   public float moveForce=10f;
   public float torqueForce=5f;
   public Rigidbody2D rb;
   public GameObject player;

void start()
{
     rb=GetComponent<Rigidbody2D>();
}
void FixedUpdate()
{
    if(player!=null)
    {
        Vector2 direction=(player.transform.position-transform.position).normalized;

        rb.AddForce(direction*moveForce);
        float rollDirection=direction.x>=0?-1f:1f;
        rb.AddTorque(rollDirection*torqueForce);
    }
}
}
