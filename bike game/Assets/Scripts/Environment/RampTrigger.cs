using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RampTrigger : MonoBehaviour
{
    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("RampTrigger"))
        {
            RampScript.instance.RampStart();
            Debug.Log("Rotation Start");
        }
    }
}
