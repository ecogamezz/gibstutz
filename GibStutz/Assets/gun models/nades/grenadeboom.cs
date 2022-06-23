using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class grenadeboom : MonoBehaviour
{
    [SerializeField] AudioSource gunAudioSource;
    [SerializeField] AudioClip gunClipSFX;

    public float delay = 3f;
    public float radius = 0.15f;
    public float force = 70f;
    public float deletetimer = 2f;
    public Rigidbody rb;

    int colinsschwoster = 0;

    public GameObject explosionEffect;



    float countdown;
    bool hasExploded = false;

    // Use this for initialization
    void Start()
    {
        countdown = delay;
        rb = GetComponent<Rigidbody>();
    }

    // countdown 'till explosion
    void FixedUpdate()
    {
        if (colinsschwoster == 1)
        {
            countdown -= Time.deltaTime;
            if (countdown <= 0f && !hasExploded)
            {
                gunAudioSource.PlayOneShot(gunClipSFX);
                Explode();
                hasExploded = true;
                colinsschwoster = 0;
            }
            
         
        }
        if (hasExploded == true)
        {
            deletetimer -= Time.deltaTime;
            if (deletetimer <= 0f)
            {
                Destroy(gameObject);
            }
        }
        



    }
    void Explode()
    {
        // disable rb & set transform
        transform.rotation = Quaternion.Euler(-90, 0, 0);
        transform.localScale = new Vector3(0, 0, 0);
        rb.isKinematic = true;
        rb.detectCollisions = false;

        //explosion
        Instantiate(explosionEffect, transform.position, transform.rotation);
        
        Vector3 explosionPos = transform.position;
        Collider[] colliders = Physics.OverlapSphere(explosionPos, radius);
        foreach (Collider hit in colliders)
        {
            Rigidbody rb = hit.GetComponent<Rigidbody>();

            if (rb != null)
                rb.AddExplosionForce(force, explosionPos, radius, 3.0F);
        }





    }
    public void Explodewithdelay(ActivateEventArgs arg0)
    {
        arg0.interactor.GetComponent<XRBaseController>().SendHapticImpulse(.5f, .25f);
        colinsschwoster = 1;

      
    }
}