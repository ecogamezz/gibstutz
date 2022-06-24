using UnityEngine;
using System;
using System.Collections;
using UnityEngine.XR.Interaction.Toolkit;


[RequireComponent(typeof(XRBaseInteractable))]
public class raycast : MonoBehaviour
{
    [SerializeField] XRGrabInteractable grabInteractable;
    [SerializeField] Transform raycastOrigin;
    [SerializeField] LayerMask targetLayer;
    [SerializeField] AudioSource gunAudioSource;
    [SerializeField] AudioClip gunClipSFX;

    public int damage = 100;
    public int force = 450;
    public float waittime = 0.06f;
    private float nextFire = 0f;
    bool canshoot = false;
    int colinsschwoster = 0;


    public ParticleSystem nuzzleflash;
    public GameObject impactEffect;
    public ActivateEventArgs arg0;
    private XRBaseControllerInteractor vibcontroller;


    void FixedUpdate()
    {
        if (colinsschwoster == 1 && Time.time > nextFire)
        {
            nextFire = Time.time + waittime;
            gunAudioSource.Stop();
            gunAudioSource.PlayOneShot(gunClipSFX); 

            FireRaycastIntoScene(arg0);
        }

    }

    public void FireRaycastIntoScene(ActivateEventArgs arg0)
    {
        XRBaseControllerInteractor vibcontroller = (XRBaseControllerInteractor)GetComponent<XRBaseInteractable>().selectingInteractor;
        vibcontroller.SendHapticImpulse(0.4f, 0.1f);
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


    public void shoot(ActivateEventArgs arg0)

    {
        colinsschwoster = 1;
        

    }




    public void stopshoot()
    {
        colinsschwoster = 0;
    }
}