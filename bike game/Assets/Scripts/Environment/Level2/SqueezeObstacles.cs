using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SqueezeObstacles : MonoBehaviour
{
    public Vector3 target;
    public Vector3 StartPos;
    public float moveSpeed = 2f;
    private float TimeElapsed=0f;
    public bool ObstacleOn = false;

 

    public void OnCollisionEnter2D(Collision2D collision)
{
    if(collision.gameObject.CompareTag("TriggerPoint"))
    {
         Debug.Log("Collided with: " + collision.gameObject.name);
        DeathScript.instance.Die();
    }
}

    public void Obstacle()
    {
        ObstacleOn=true;
        Debug.Log("SqueezeObstacles working");
            }
     void Update()
    {
        if (ObstacleOn)
        {
           if(TimeElapsed<moveSpeed)
            {
                TimeElapsed += Time.deltaTime;
                Vector3 currentMove = Vector3.Lerp(StartPos,target, TimeElapsed / moveSpeed);
                transform.position = currentMove;
            }
        }

    }
}
