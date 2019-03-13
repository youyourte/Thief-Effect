using System.Collections;
using System.Collections.Generic;
using UnityEngine;

 [RequireComponent (typeof (LineRenderer))]

public class Laser : MonoBehaviour
{

    private LineRenderer lr;

    // add delegate for targeting call to enemys

    // use this for initialisation
    void Start()
    {
       lr = GetComponent<LineRenderer>(); 
    }

    // Update is called once per frame
    void Update()
    {
        RaycastHit hit;

        if (Physics.Raycast(transform.position, transform.forward,out hit))
        {
            if (hit.collider)
            {
                lr.SetPosition(1,new Vector3(0,0,hit.distance));
            }
            else
            {
                lr.SetPosition(1,new Vector3(0,0,500));
            }
        }
    }
}
