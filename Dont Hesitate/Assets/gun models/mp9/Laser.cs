using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Laser : MonoBehaviour
{
    private LineRenderer lr;
    // Start is called before the first frame update
    void Start()
    {
        lr = GetComponent<LineRenderer>();
        
    }

    // Update is called once per frame
    void Update()
    {
        lr.SetPosition(0, transform.position);
        RaycastHit hit;
        if (Physics.Raycast(transform.position, transform.forward, out hit))
        {
            if (hit.collider)
            {
                if (hit.collider.tag == "ignore_laser")
                {
                    lr.SetPosition(1, transform.forward * 5000);
                }
                else
                {
                    lr.SetPosition(1, hit.point);
                }
            }
        }
        else lr.SetPosition(1, transform.forward * 5000);
          
    }
}
