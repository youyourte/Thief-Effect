using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : FPCSupport
{
    public GameObject gunBarrel;
    

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
            Fire();
        
    }

    void Fire()
    {
        // add reload delay for fire - no button mashing !
        RaycastHit hit;

        if (Physics.Raycast(gunBarrel.transform.position, gunBarrel.transform.forward,out hit))
        {
            if (hit.collider.tag == "enemy")
            {
                ATHOn = true;
            }
        }

    }
}
