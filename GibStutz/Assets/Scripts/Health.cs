using UnityEngine;
using System.Collections;

public class Health : MonoBehaviour
{
    
    public GameObject destroyedVersion;

    public void launch()
    {
        Debug.Log("meabootlegotshot");
        Instantiate(destroyedVersion, transform.position, transform.rotation);
        Destroy(gameObject);
    }

    

}


