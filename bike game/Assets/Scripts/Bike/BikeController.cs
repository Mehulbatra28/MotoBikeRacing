using UnityEngine;
using UnityEngine.InputSystem;

public class BikeController : MonoBehaviour
{
    public Rigidbody2D frontTire;
    public Rigidbody2D backTire;
    public Rigidbody2D Bike;
    public float speed = 10000f;
    public float rotationSpeed = 2000f;
    public LayerMask groundLayer;
    private float maxY = 25f;
    private float moveInput;
    private float TiltInput;
    public InputAction TiltAction;
    public InputAction moveAction;
    private AudioSource BikeSource;

    
    public float minPitch = 0.8f;
    public float maxPitch = 2.0f;
    public float APitch = 1.5f;
    public float DPitch = 1.0f;
    private float currentSpeed;
    private float AInput;
    private Collider2D frontTireCollider;
    private Collider2D backTireCollider;

    private void OnEnable()
    {
        moveAction.Enable();
        TiltAction.Enable();
        
    }

    private void OnDisable()
    {
        moveAction.Disable();
        TiltAction.Disable();
        
    }


    void Start()
    {
        BikeSource=SoundManager.instance.BikeSource;
        frontTireCollider = frontTire != null ? frontTire.GetComponent<Collider2D>() : null;
        backTireCollider = backTire != null ? backTire.GetComponent<Collider2D>() : null;
    }
    
    private void Update()
    {
        moveInput = moveAction.ReadValue<float>(); 
        Debug.Log("MoveInput: " + moveInput);
        TiltInput=TiltAction.ReadValue<float>();
         Debug.Log("TiltInput: " + TiltInput);
        currentSpeed = GetComponent<Rigidbody2D>().velocity.magnitude;
    }

    private void FixedUpdate()
    {
        AInput = moveInput;
        frontTire.AddTorque(-moveInput * speed * Time.fixedDeltaTime);
        backTire.AddTorque(-moveInput * speed * Time.fixedDeltaTime);
		bool isGrounded = false;
		if (frontTireCollider != null && backTireCollider != null)
		{
			isGrounded = frontTireCollider.IsTouchingLayers(groundLayer) || backTireCollider.IsTouchingLayers(groundLayer);
		}
        if (isGrounded)
        {
            Bike.AddForce(Vector2.right * moveInput * rotationSpeed);
        }
        
        // Allow tilt control via torque (works in air for mid-air control)
         if (Mathf.Abs(TiltInput) > 0f)
        {
            Bike.AddTorque(-TiltInput * rotationSpeed * Time.fixedDeltaTime);
        }
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
