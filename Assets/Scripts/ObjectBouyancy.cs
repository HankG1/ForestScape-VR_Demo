using UnityEngine;

public class ObjectBouyancy : MonoBehaviour
{
    private Rigidbody rb;
    public bool isInWater = false;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Water"))
        {
            isInWater = true;
            rb.linearDamping = 2f; // Slow it down in water
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Water"))
        {
            isInWater = false;
        }
    }

    private void FixedUpdate()
    {
        if (isInWater)
        {
            // Apply bouyancy force to counteract gravity (Tweak the value as needed)
            rb.AddForce(Vector3.up * 9.81f * rb.mass, ForceMode.Force);
        }
    }

}
