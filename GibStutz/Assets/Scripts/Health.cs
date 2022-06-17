using UnityEngine;
using System.Collections;

public class Health : MonoBehaviour
{
    Rigidbody rb;
    public float speed = 10f;

    public float maxHealth = 100f;
    static public float currentHealth = 100f;


    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    public void launch()
    {
        Debug.Log("launch")
        rb.AddForce(transform.up * speed);
    }

    void FixedUpdate()
    {
        if (currentHealth <= 0)
        {
            rb.AddForce(transform.up * speed);
        }
    }

}