using UnityEngine;
using System.Collections;

public class Health : MonoBehaviour
{
    
    public GameObject destroyedVersion;
    public GameObject destroyedVersion2;

    public void launch()
    {
        Debug.Log("meabootlegotshot");
        Instantiate(destroyedVersion, transform.position, transform.rotation);
        Instantiate(destroyedVersion2, transform.position, transform.rotation);
        Destroy(gameObject);

    }

    

}


