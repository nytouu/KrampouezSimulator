using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PanMovement : MonoBehaviour
{
    public float threshhold = 3f;
    public Krampou krampouez;

    private Rigidbody rb;
    private bool colliding;

    // Start is called before the first frame update
    void Start()
    {
        colliding = false;
        rb = GetComponent<Rigidbody>();
        Input.compensateSensors = true;
        Input.gyro.enabled = true;

        Screen.sleepTimeout = SleepTimeout.NeverSleep;
    }

    // Update is called once per frame
    void FixedUpdate()
    { 
        Vector3 rotation = Input.gyro.attitude.eulerAngles;

        // idk why i need to swap y and z but sure
        rotation = SwapYZ(rotation);

        rb.MoveRotation(Quaternion.Euler(rotation));

        if (Input.gyro.userAcceleration.z > threshhold) {
            krampouez.JumpFlip();
            /* if (colliding) { */
                /* Debug.Log("crêpe turn"); */
            /* } */
        }
    }

    private Vector3 SwapYZ(Vector3 vector) {
        float tempZ = vector.z;

        vector.z = vector.y;
        vector.y = tempZ;
        
        return vector;
    }

    private void OnCollisionEnter(Collision collision) {
        if (krampouez == collision.gameObject.GetComponent<Krampou>()) {
            colliding = true;
            Debug.Log("colliding");
        }
    }
    private void OnCollisionExit(Collision collision) {
        if (krampouez == collision.gameObject.GetComponent<Krampou>()) {
            colliding = false;
            Debug.Log("not colliding");
        }
    }
}
