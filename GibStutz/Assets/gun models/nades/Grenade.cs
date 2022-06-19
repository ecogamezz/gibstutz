using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class Grenade : MonoBehaviour
{
   

    public float delay = 3f;
    public float radius = 0f;
    public float force = 0f;

    int colinsschwoster = 0;

    public GameObject explosionEffect;

    float countdown;
    bool hasExploded = false;

    // Use this for initialization
    void Start()
    {
        countdown = delay;
    }

    // Update is called once per frame
    void FixedUpdate()
    {  
        if (colinsschwoster == 1)
        {
            countdown -= Time.deltaTime;
            if (countdown <= 0f && !hasExploded)
            {
                Explode();
                hasExploded = true;
                colinsschwoster = 0;
            }
        }
        
    }
    void Explode()
    {
        Instantiate(explosionEffect, transform.position, transform.rotation);

        Vector3 explosionPos = transform.position;
        Collider[] colliders = Physics.OverlapSphere(explosionPos, radius);
        foreach (Collider hit in colliders)
        {
            Rigidbody rb = hit.GetComponent<Rigidbody>();

            if (rb != null)
                rb.AddExplosionForce(force, explosionPos, radius, 3.0F);
        }


        // Damage
        

        Destroy(gameObject);
    }
    public void Explodewithdelay(ActivateEventArgs arg0)
    {
        arg0.interactor.GetComponent<XRBaseController>().SendHapticImpulse(.5f, .25f);
        colinsschwoster = 1;

   
    }
}