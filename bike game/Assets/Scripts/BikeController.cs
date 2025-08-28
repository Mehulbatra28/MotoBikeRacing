using UnityEngine;

public class BikeController : MonoBehaviour
{
    public Rigidbody2D frontTire;
    public Rigidbody2D backTire;
    public Rigidbody2D Bike;
    public float speed = 10000f;
    public float rotationSpeed = 300f;
    
    private float moveInput;

   public void Update()
    {
        moveInput = Input.GetAxisRaw("Horizontal");

    }
    private void FixedUpdate()
    {
        frontTire.AddTorque(moveInput * speed * Time.fixedDeltaTime);
        backTire.AddTorque(moveInput * speed * Time.fixedDeltaTime);
        Bike.AddTorque(moveInput * speed * Time.fixedDeltaTime);
    }
    
}