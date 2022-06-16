using UnityEngine;
using System;
using System.Threading;
using UnityEngine.XR.Interaction.Toolkit;

public class raycast : MonoBehaviour
{
    [SerializeField] XRGrabInteractable grabInteractable;
    [SerializeField] Transform raycastOrigin;
    [SerializeField] LayerMask targetLayer;
    [SerializeField] AudioSource gunAudioSource;
    [SerializeField] AudioClip gunClipSFX;
    int FireRate = 10;

    public float thrust = 1.0f;
    public Rigidbody rb;

    public void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    public void FireRaycastIntoScene()
    {
        RaycastHit hit;

        if(Physics.Raycast(raycastOrigin.position, raycastOrigin.TransformDirection(Vector3.forward), out hit, Mathf.Infinity, targetLayer))
        {
            Debug.Log("hit target");
            rb.AddForce(100, 100, thrust, ForceMode.Impulse);
        }
    
    }



    public void shoot(ActivateEventArgs arg0)
    {
            arg0.interactor.GetComponent<XRBaseController>().SendHapticImpulse(.5f, .25f);

            gunAudioSource.PlayOneShot(gunClipSFX);

            FireRaycastIntoScene();
     

    }

}