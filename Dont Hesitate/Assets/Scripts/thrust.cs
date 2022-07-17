using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class thrust : MonoBehaviour
{
    public int updateforward = 1;
    public Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    public void Thrustforward() {
        updateforward ++;
    }    

    void FixedUpdate()
    {
        if (updateforward != 1)
        {
            ApplyForce();
        }
    }
    void ApplyForce()
    {
        Vector3 direction = rb.transform.position - transform.position;
        rb.AddForceAtPosition(direction.normalized, transform.position * 100f);
    }
}
