using UnityEngine;
using System.Collections;

public class Health : MonoBehaviour
{
    
    public GameObject destroyedVersion;
    public GameObject destroyedVersion2;
    public ParticleSystem particlesys;

    public void launch()
    {
        Debug.Log("meabootlegotshot");
        Instantiate(destroyedVersion, transform.position, transform.rotation);
        Instantiate(destroyedVersion2, transform.position, transform.rotation);
        Instantiate(particlesys, transform.position, transform.rotation);
        Destroy(gameObject);

    }

    

}


