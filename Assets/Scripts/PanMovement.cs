using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PanMovement : MonoBehaviour
{
    public ParticleSystem particles;
    public float threshhold = 3f;

    private Vector3 bias;

    // Start is called before the first frame update
    void Start()
    {
        Input.compensateSensors = true;
        Input.gyro.enabled = true;

        Screen.sleepTimeout = SleepTimeout.NeverSleep;
    }

    // Update is called once per frame
    void Update()
    { 
        Vector3 rotation = Input.gyro.attitude.eulerAngles;

        // idk why i need to swap y and z but sure
        rotation = SwapYZ(rotation);

        gameObject.transform.rotation = Quaternion.Euler(rotation.x, rotation.y, rotation.z);

        if (Input.gyro.userAcceleration.z > threshhold) {
            Debug.Log("crêpe turn");
        }
    }

    private Vector3 SwapYZ(Vector3 vector) {
        float tempZ = vector.z;

        vector.z = vector.y;
        vector.y = tempZ;
        
        return vector;
    }
}
