using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PanMovement : MonoBehaviour
{
    public float forceThreshold = 3f;
    public float distanceThreshold = 2.5f;
    public Krampou krampouez;

    private Rigidbody rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        Input.compensateSensors = true;
        Input.gyro.enabled = true;

        Screen.sleepTimeout = SleepTimeout.NeverSleep;
    }

    // Update is called once per frame
    void FixedUpdate()
    { 
        Vector3 rotation = Input.gyro.attitude.eulerAngles;

        // magic stuff
        rotation = SwapYZ(rotation);

        rb.MoveRotation(Quaternion.Euler(-rotation));

        if (Input.gyro.userAcceleration.z >= forceThreshold &&
                Vector3.Distance(transform.position, krampouez.transform.position) <= distanceThreshold) {
            krampouez.JumpFlip();
        }
    }

    private Vector3 SwapYZ(Vector3 vector) {
        float tempZ = vector.z;

        vector.z = vector.y;
        vector.y = tempZ;
        
        return vector;
    }
}
