﻿using UnityEngine;
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
    public int damage = 100;
    public int force = 450;


    public void FireRaycastIntoScene()
    {
        RaycastHit hit;
        

        if (Physics.Raycast(raycastOrigin.position, raycastOrigin.TransformDirection(Vector3.forward), out hit, Mathf.Infinity, targetLayer))
        {
            Transform objectHit = hit.transform;


            hit.rigidbody.AddForceAtPosition(force * transform.forward, hit.point);


            Health HP = hit.collider.gameObject.GetComponent<Health>();
            HP.launch();



        }
    }


    public void shoot(ActivateEventArgs arg0)
       
    {
        gunAudioSource.Stop();
        arg0.interactor.GetComponent<XRBaseController>().SendHapticImpulse(.5f, .25f);

        gunAudioSource.PlayOneShot(gunClipSFX);

        FireRaycastIntoScene();


    }

}