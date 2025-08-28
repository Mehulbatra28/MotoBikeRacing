using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform player;       // Reference to the player
    public Vector3 offset;         // Offset between player and camera
    public float smoothSpeed = 0.125f; // Smoothing factor

    void LateUpdate()
    {
        if (player != null)
        {
            // Desired position is player's position + offset
            Vector3 desiredPosition = player.position + offset;

            // Smooth movement
            Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);

            // Update camera position
            transform.position = new Vector3(smoothedPosition.x, smoothedPosition.y, transform.position.z);
        }
    }
}
