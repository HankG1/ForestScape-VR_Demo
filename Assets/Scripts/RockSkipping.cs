using UnityEngine;

public class RockSkipping : MonoBehaviour
{
    private Rigidbody rb;
    private int skipCount = 0;
    private int maxSkips = 3;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void OnTriggerEnter(Collider other)
    {
        Vector3 velocity = rb.angularVelocity;
        if (velocity.y < 0 && skipCount < maxSkips)
        {  
            rb.AddForce(Vector3.up * 5f, ForceMode.Impulse); // Bounce it up slightly
            skipCount++;
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Water") && skipCount >= maxSkips)
        {
            rb.linearDamping = 5f; // Slow it down in water
            rb.AddForce(Vector3.down * 2f); // sink gradually
        }
    }
}
