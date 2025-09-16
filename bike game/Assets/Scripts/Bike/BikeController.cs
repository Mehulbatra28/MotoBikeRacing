using UnityEngine;
using UnityEngine.InputSystem;

public class BikeController : MonoBehaviour
{
    public Rigidbody2D frontTire;
    public Rigidbody2D backTire;
    public Rigidbody2D Bike;
    public float speed = 10000f;
    public float rotationSpeed = 300f;
    private float maxY = 25f;
    private float moveInput;
    private float TiltInput;
    public InputAction moveAction;
    public InputAction tiltAction; 
    private AudioSource BikeSource;

    
    public float minPitch = 0.8f;
    public float maxPitch = 2.0f;
    public float APitch = 1.5f;
    public float DPitch = 1.0f;
    private float currentSpeed;
    private float AInput;

    private void OnEnable()
    {
        moveAction.Enable();
        tiltAction.Enable();
    }

    private void OnDisable()
    {
        moveAction.Disable();
        tiltAction.Disable();
    }


    void Start()
    {
        BikeSource=SoundManager.instance.BikeSource;
    }
    
    private void Update()
    {
        moveInput = moveAction.ReadValue<float>(); 
        Debug.Log("MoveInput: " + moveInput);
        Vector3 accel = tiltAction.ReadValue<Vector3>();
        TiltInput = accel.x;
        Debug.Log("TiltAction Vector3: " + accel + " | TiltInput (X): " + TiltInput);
        currentSpeed = GetComponent<Rigidbody2D>().velocity.magnitude;
    }

    private void FixedUpdate()
    {
        AInput = moveInput;
        frontTire.AddTorque(-moveInput * speed * Time.fixedDeltaTime);
        backTire.AddTorque(-moveInput * speed * Time.fixedDeltaTime);
        Bike.AddTorque(-TiltInput* rotationSpeed * Time.fixedDeltaTime);
        float basePitch = Mathf.Lerp(minPitch, maxPitch, currentSpeed / 50f);
        
        if(AInput>0)
        {
            basePitch*=APitch;
        }
        else if (AInput < 0)
        {
            basePitch*=DPitch;
        }
        BikeSource.pitch = Mathf.Lerp(BikeSource.pitch, basePitch, Time.deltaTime * 5f);
        Vector2 bikePosition = Bike.position;
        if (bikePosition.y > maxY)
        {
            bikePosition.y = maxY;
            Bike.position = bikePosition;

            // Prevent further upward movement
            Vector2 bikeVelocity = Bike.velocity;
            if (bikeVelocity.y > 0f)
            {
                bikeVelocity.y = 0f;
                Bike.velocity = bikeVelocity;
            }
        }

        // Clamp front tire's Y position to not exceed maxY
        Vector2 frontPosition = frontTire.position;
        if (frontPosition.y > maxY)
        {
            frontPosition.y = maxY;
            frontTire.position = frontPosition;

            Vector2 frontVelocity = frontTire.velocity;
            if (frontVelocity.y > 0f)
            {
                frontVelocity.y = 0f;
                frontTire.velocity = frontVelocity;
            }
        }

        // Clamp back tire's Y position to not exceed maxY
        Vector2 backPosition = backTire.position;
        if (backPosition.y > maxY)
        {
            backPosition.y = maxY;
            backTire.position = backPosition;

            Vector2 backVelocity = backTire.velocity;
            if (backVelocity.y > 0f)
            {
                backVelocity.y = 0f;
                backTire.velocity = backVelocity;
            }
        }
    }
}
