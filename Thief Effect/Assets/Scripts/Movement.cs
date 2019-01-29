using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public float speed;
    float zMovement;
    float xMovement;
    // Update is called once per frame
    void Update()
    {
        zMovement = Input.GetAxis("Vertical") * speed * Time.deltaTime;
        xMovement = Input.GetAxis("Horizontal") * speed * Time.deltaTime;
        transform.Translate(xMovement, 0, zMovement);
    }
}
