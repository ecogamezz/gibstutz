using UnityEngine;
using System.Collections;

public class Health : MonoBehaviour
{
    [SerializeField] private Transform player;
    [SerializeField] private Transform respawnPoint;


    public void launch()
    {
        Debug.Log("meabootlegotshot");
       
    }

    void OnTriggerEnter(Collider other)
    {
        player.transform.position = respawnPoint.transform.position;
    }

}


