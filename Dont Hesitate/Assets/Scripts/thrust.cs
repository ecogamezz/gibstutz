using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class thrust : MonoBehaviour
{
    Rigidbody m_Rigidbody;
    public float m_Thrust = 5f;
    public bool activated = false;

    void FixedUpdate() {
        if (activated == true) { m_Rigidbody.AddForce(transform.forward * m_Thrust); }
    }
    public void Thrustforward() {
        activated = true;

    }    
}
