using UnityEngine;
using System.Collections;

public class scr_camera : MonoBehaviour
{

    Transform cam;

    bool startNextRotation = true;

    public bool rotRight;

    public float yaw;

    public float pitch;

    public float secontsToRot;

    public float rotSwitchTime;

	void Start ()
    {
        cam = transform.GetChild(0);
        cam.localRotation = Quaternion.AngleAxis(pitch,Vector3.right);

        SetUpRotation();
	}

    private void Update()
    {
        if(startNextRotation && rotRight)
        {
            StartCoroutine(Rotate(yaw,secontsToRot));
        }
        else if(startNextRotation && !rotRight)
        {
            StartCoroutine(Rotate(-yaw, secontsToRot));
        }
    }

    IEnumerator Rotate(float yaw2,float duration)
    {
        yaw2 = yaw;
        startNextRotation = false;
        Quaternion initialRotation = transform.rotation;
        float timer = 0f;
        while(timer<duration)
        {
            timer += Time.deltaTime;
            transform.rotation = initialRotation * Quaternion.AngleAxis(timer / duration * yaw2, Vector3.up);
            yield return null;
        }

        yield return new WaitForSeconds(rotSwitchTime);
        startNextRotation = true;
        rotRight = !rotRight;
    }

    void SetUpRotation()
    {
        if(rotRight)
        {
            transform.localRotation = Quaternion.AngleAxis(-yaw / 2, Vector3.up);
        }
        else
        {
            transform.localRotation = Quaternion.AngleAxis(yaw / 2, Vector3.up);
        }
    }

    //void Update () 
    //{
    //  transform.rotation = Quaternion.Euler(transform.eulerAngles.x, (Mathf.Sin(Time.realtimeSinceStartup) * rotate_amount) + transform.eulerAngles.y, transform.eulerAngles.z);
    //}
}
