using UnityEngine;
using UnityEngine.InputSystem;

public class BikeController : MonoBehaviour
{
    public Rigidbody2D frontTire;
    public Rigidbody2D backTire;
    public Rigidbody2D Bike;
    public float speed = 10000f;
    public float rotationSpeed = 300f;

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
    }
}
