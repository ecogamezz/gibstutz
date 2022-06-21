using UnityEngine;
using System;
using System.Collections;
using UnityEngine.XR.Interaction.Toolkit;

public class raycast : MonoBehaviour
{
    [SerializeField] XRGrabInteractable grabInteractable;
    [SerializeField] Transform raycastOrigin;
    [SerializeField] LayerMask targetLayer;
    [SerializeField] AudioSource gunAudioSource;
    [SerializeField] AudioClip gunClipSFX;

    public int damage = 100;
    public int force = 450;
    private XRController xr;
    public float waittime = 0.06f;
    private float nextFire = 0f;
    bool canshoot = false;
    int colinsschwoster = 0;

    
    public ParticleSystem nuzzleflash;
    public GameObject impactEffect;

    void FixedUpdate()
    {
        Debug.Log("startupdate");
        xr = (XRController)GameObject.FindObjectOfType(typeof(XRController));
        if (colinsschwoster == 1 && Time.time > nextFire)
        {
            Debug.Log("startfire");
            nextFire = Time.time + waittime;
            gunAudioSource.Stop();
            xr.SendHapticImpulse(.5f, .25f);
            gunAudioSource.PlayOneShot(gunClipSFX);

            FireRaycastIntoScene();
        }

    }

    public void FireRaycastIntoScene()
    {
        RaycastHit hit;

        

        

        if (Physics.Raycast(raycastOrigin.position, raycastOrigin.TransformDirection(Vector3.forward), out hit, Mathf.Infinity, targetLayer))
        {
           

            Transform objectHit = hit.transform;


            hit.rigidbody.AddForceAtPosition(force * transform.forward, hit.point);


            makesoundwhenhit mksnd = hit.collider.gameObject.GetComponent<makesoundwhenhit>();
            mksnd.makesound();

            Instantiate(impactEffect, hit.point, Quaternion.LookRotation(hit.normal));

        }
        nuzzleflash.Play();
    }


    public void shoot()

    {
        colinsschwoster = 1;

    }




    public void stopshoot()
    {
        colinsschwoster = 0;

    }
}