using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PanMovement : MonoBehaviour
{
    private Vector3 currentAngle;
    private Vector3 rotation;

    // Start is called before the first frame update
    void Start()
    {
        // init gyro
        Input.gyro.enabled = true;

        currentAngle = Vector3.zero;
    }

    // Update is called once per frame
    void Update()
    {
        /* currentAngle.x = -Input.gyro.attitude.eulerAngles.x; */
        /* currentAngle.y = -Input.gyro.attitude.eulerAngles.z; */
        /* currentAngle.z = Input.gyro.attitude.eulerAngles.y; */

        /* Debug.Log(currentAngle); */

        /* rotation.x = Input.gyro.rotationRateUnbiased.x; */
        /* rotation.y = -Input.gyro.rotationRateUnbiased.z; */
        /* rotation.z = Input.gyro.rotationRateUnbiased.y; */

        /* transform.rotation = new Quaternion(currentAngle.x, currentAngle.x, currentAngle.z, currentAngle.y); */
        /* transform.rotation = Quaternion.Euler(-currentAngle); */
        transform.rotation = Input.gyro.attitude;
        /* transform.Rotate(rotation); */
    }
}
