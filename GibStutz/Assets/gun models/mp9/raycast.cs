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
    public int damage = 50;


    public void FireRaycastIntoScene()
    {
        RaycastHit hit;

        if (Physics.Raycast(raycastOrigin.position, raycastOrigin.TransformDirection(Vector3.forward), out hit, Mathf.Infinity, targetLayer))
        {
            Transform objectHit = hit.transform;
            Debug.Log("testetsetst");


            Health HP = hit.collider.gameObject.GetComponent<Health>();
            HP.launch();
            Debug.Log("hit");


        }
    }


    public void shoot(ActivateEventArgs arg0)
    {
        arg0.interactor.GetComponent<XRBaseController>().SendHapticImpulse(.5f, .25f);

        gunAudioSource.PlayOneShot(gunClipSFX);

        FireRaycastIntoScene();


    }

}