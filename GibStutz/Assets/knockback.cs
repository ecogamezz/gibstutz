using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class knockback : MonoBehaviour
{
    public void GetShot(Vector3 direction)
    {
        Vector3 force = direction * 5 + Vector3.forward * 10;
        this.GetComponent<Rigidbody>().AddForce(force, ForceMode.Impulse);
        this.transform.parent = null;
    }
}
