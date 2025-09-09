using UnityEngine;

public class BikeLauncher : MonoBehaviour
{
    public Vector3 startpoint;
    public Vector3 endpoint;
    public float duration = 0.5f;
    public GameObject Bike;
    public Vector2 ForceDirection = Vector2.up;
    public float forceAmount = 10f;

    private float timeElapsed;
    private bool forceApplied = false;

    void Start()
    {
        timeElapsed = 0f;
        transform.position = startpoint;
    }

    void Update()
    {
        if (timeElapsed < duration)
        {
            timeElapsed += Time.deltaTime;
            float t = Mathf.Clamp01(timeElapsed / duration);
            transform.position = Vector2.Lerp(startpoint, endpoint, t);
        }
        else if (!forceApplied) // apply only once
        {
            Rigidbody2D rb = Bike.GetComponent<Rigidbody2D>();
            if (rb != null)
            {
                rb.AddForce(ForceDirection.normalized * forceAmount, ForceMode2D.Impulse);
            }
            forceApplied = true;
        }
    }
}
