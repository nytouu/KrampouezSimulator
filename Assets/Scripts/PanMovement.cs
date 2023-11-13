using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PanMovement : MonoBehaviour
{
    public float matchSpeed = 10f;
    public float flipThreshold = 2.0f;

    private Vector3 currentAngle;
    private Vector3 defaultPosition;
    private Vector3 rotation;

    // Start is called before the first frame update
    void Start()
    {
        currentAngle = Vector3.zero;
        defaultPosition = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        currentAngle.x = Input.acceleration.x * 36;
        currentAngle.y = Input.acceleration.y * 36;
        currentAngle.z = Input.acceleration.z * 36;

        // move pan up
        if (Mathf.Abs(currentAngle.z) >= flipThreshold) {
            Vector3 targetPosition = transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z * currentAngle.z * 1000f);
            transform.position = Vector3.Lerp(transform.position, targetPosition, Time.deltaTime * matchSpeed * 3.0f);
        }

        // smooth rotation
        Quaternion targetRotation = Quaternion.Euler(currentAngle);
        transform.rotation = Quaternion.Lerp(transform.rotation, targetRotation, Time.deltaTime * matchSpeed);
    }
}
