using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MixStick : MonoBehaviour, IMiniGame
{
	private float counter;

	public float speed = 1f;
	public float diameter = 1f;
	public float threshold = 0.5f;

	private Vector3 defaultPosition;
	private float shakePower;
	public float progress;

	private bool playing;

    // Start is called before the first frame update
    void Start()
    {
		playing = false;
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
		if (playing) {
			Vector3 acceleration = Input.gyro.userAcceleration;

			if (acceleration.x > threshold || acceleration.y > threshold || acceleration.z > threshold){
				shakePower = Mathf.Abs(acceleration.x) + Mathf.Abs(acceleration.y) + Mathf.Abs(acceleration.z);
				progress += shakePower;
			} else {
				shakePower = 0;
			}

			counter += Time.deltaTime * shakePower * speed;

			Vector3 newPosition = transform.position;

			newPosition.x = Mathf.Cos(counter) * diameter + defaultPosition.x;
			newPosition.z = Mathf.Sin(counter) * diameter + defaultPosition.z;

			transform.position = newPosition;
		}
    }

    public void Enable(){ playing = true; }
    public void Disable(){ playing = false; }
}
