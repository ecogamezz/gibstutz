using UnityEngine;
using System;
using UnityEngine.XR.Interaction.Toolkit;

public class raycast : MonoBehaviour
{
    [SerializeField] XRGrabInteractable grabInteractable;
    [SerializeField] Transform raycastOrigin;
    [SerializeField] LayerMask targetLayer;

    private void FireRaycastIntoScene()
    {
        RaycastHit hit;

        if(Physics.Raycast(raycastOrigin.position, raycastOrigin.TransformDirection(Vector3.forward), out hit, Mathf.Infinity, targetLayer))
        {
            Debug.Log("hit target");
        }
   
    }
    public void shoot()
    {

        FireRaycastIntoScene();
    }

}
