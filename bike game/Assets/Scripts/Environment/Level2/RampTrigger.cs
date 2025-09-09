using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RampTrigger : MonoBehaviour
{
    public GameObject[] Obstacles;
    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("TriggerPoint"))
        {
            RampScript.instance.RampStart();
              Debug.Log("Collided with: " + other.gameObject.name);
              foreach (var obstacle in Obstacles)
            {
                obstacle.GetComponent<SqueezeObstacles>().Obstacle();
            }        
              Debug.Log("Collided with: " + other.gameObject.name);
    
        }
    }
}
