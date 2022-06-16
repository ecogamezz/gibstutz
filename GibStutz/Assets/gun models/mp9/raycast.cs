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
    

    public void FireRaycastIntoScene()
    {
        RaycastHit hit;

        if(Physics.Raycast(raycastOrigin.position, raycastOrigin.TransformDirection(Vector3.forward), out hit, Mathf.Infinity, targetLayer))
        {
            Debug.Log("hit target");
            rb = TryGetComponent<RigidBody>
            
        }
    
    }



    public void shoot(ActivateEventArgs arg0)
    {
            arg0.interactor.GetComponent<XRBaseController>().SendHapticImpulse(.5f, .25f);

            gunAudioSource.PlayOneShot(gunClipSFX);

            FireRaycastIntoScene();
     

    }

}