using UnityEngine;
using System;
using System.Collections;
using UnityEngine.XR.Interaction.Toolkit;

public class pistol : MonoBehaviour
{
    [SerializeField] XRGrabInteractable grabInteractable;
    [SerializeField] Transform raycastOrigin;
    [SerializeField] LayerMask targetLayer;
    [SerializeField] AudioSource gunAudioSource;
    [SerializeField] AudioClip gunClipSFX;

    public int damage = 100;
    public int force = 450;


    public ParticleSystem nuzzleflash;
    public GameObject impactEffect;




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
        gunAudioSource.Stop();
        gunAudioSource.PlayOneShot(gunClipSFX);

        FireRaycastIntoScene();

    }

}