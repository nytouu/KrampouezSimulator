using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MixStick : MonoBehaviour
{
	private float counter;

	public float speed = 1f;
	public float diameter = 1f;
	public float threshold = 0.5f;

	private Vector3 defaultPosition;
	private float shakePower;
	private float progress;

    // Start is called before the first frame update
    void Start()
    {
		defaultPosition = transform.position;
		counter = 0;
		shakePower = 0;
		progress = 0;

        Input.compensateSensors = true;
        Input.gyro.enabled = true;

        Screen.sleepTimeout = SleepTimeout.NeverSleep;
    }

    // Update is called once per frame
    void Update()
    {
		Vector3 acceleration = Input.gyro.userAcceleration;

		if (acceleration.x > threshold || acceleration.y > threshold || acceleration.z > threshold){
			shakePower = Mathf.Abs(acceleration.x) + Mathf.Abs(acceleration.y) + Mathf.Abs(acceleration.z);
			progress += shakePower;
		} else {
			shakePower = 0;
		}

		counter += Time.deltaTime * shakePower * speed;

		float x = Mathf.Cos(counter) * diameter + defaultPosition.x;
		float y = transform.position.y;
		float z = Mathf.Sin(counter) * diameter + defaultPosition.z;

		transform.position = new Vector3(x, y, z);
    }
}
