using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Autohand.Demo
{
    public class rifle : MonoBehaviour
    {
        public Rigidbody body;

        public Transform barrelTip;

        public float hitPower = 1;
        public float recoilPower = 1;
        public float range = 100;
        public float waittime = 0.12f;
        private float nextFire = 0f;
        
        public LayerMask layer;

        public AudioClip shootSound;
        public float shootVolume = 1f;

        public bool triggerpress = false;

        private void Start()
        {
            if (body == null && GetComponent<Rigidbody>() != null)
                body = GetComponent<Rigidbody>();
        }

        private void FixedUpdate()
        {
            if (triggerpress == true && Time.time > nextFire)
            {
                nextFire = Time.time + waittime;
                Shoot();
            }
        }

        public void settriggerpress()
        {
            triggerpress = true;
        }

        public void removetriggerpress()
        {
            triggerpress = false;
        }

        public void Shoot()
        {
            //Play the audio sound
            if (shootSound)
                AudioSource.PlayClipAtPoint(shootSound, transform.position, shootVolume);

            RaycastHit hit;
            if (Physics.Raycast(barrelTip.position, barrelTip.forward, out hit, range, layer))
            {
                var hitBody = hit.transform.GetComponent<Rigidbody>();
                if (hitBody != null)
                {
                    Debug.DrawRay(barrelTip.position, (hit.point - barrelTip.position), Color.green, 5);
                    hitBody.GetComponent<Smash>()?.DoSmash();
                    hitBody.AddForceAtPosition((hit.point - barrelTip.position).normalized * hitPower * 10, hit.point, ForceMode.Impulse);
                }
                makesoundwhenhit mksnd = hit.collider.gameObject.GetComponent<makesoundwhenhit>();
                if (mksnd != null)
                {
                    mksnd.makesound();
                }
            }
            else
                Debug.DrawRay(barrelTip.position, barrelTip.forward * range, Color.red, 1);

            body.AddForce(barrelTip.transform.up * recoilPower * 5, ForceMode.Impulse);
        }
    }
}

