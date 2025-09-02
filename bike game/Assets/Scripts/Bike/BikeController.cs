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
    public InputAction tiltAction; // reference from Input Actions

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

    private void Update()
    {
        moveInput = moveAction.ReadValue<float>(); 
        Debug.Log("MoveInput: " + moveInput);
        Vector3 accel = tiltAction.ReadValue<Vector3>();
        TiltInput = accel.x;


        // Will be -1 (back), 0 (idle), +1 (forward)
    }

    private void FixedUpdate()
    {
        frontTire.AddTorque(-moveInput * speed * Time.fixedDeltaTime);
        backTire.AddTorque(-moveInput * speed * Time.fixedDeltaTime);
        Bike.AddTorque(-moveInput * rotationSpeed * Time.fixedDeltaTime);

        // Clamp bike's Y position to not exceed maxY
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
