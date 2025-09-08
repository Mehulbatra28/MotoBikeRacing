using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RampScript : MonoBehaviour
{

    public Vector3 target;
    public Vector3 StartPos;
    public float rotationSpeed = 2f;
    private float TimeElapsed=0f;
    public bool RampOn = false;
    public static RampScript instance;

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }


  
    public void RampStart()
    {
       
        RampOn = true;
    }

    void Update()
    {
        if (RampOn)
        {
           if(TimeElapsed<rotationSpeed)
            {
                TimeElapsed += Time.deltaTime;
                Vector3 currentRotation = Vector3.Lerp(StartPos,target, TimeElapsed / rotationSpeed);
                transform.rotation=Quaternion.Euler(currentRotation);
            }
        }

    }
}
