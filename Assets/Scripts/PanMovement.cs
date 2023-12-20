using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PanMovement : MonoBehaviour, IMiniGame
{
    public float forceThreshold = 3f;
    public float distanceThreshold = 2.5f;
    public Krampou krampouez;
	public ParticleSystem particles;

	public MiniGameManager gameManager;

    private Rigidbody rb;

	private bool playing;

	private float startTime;
    public float StartTime { get => startTime; }

    // Start is called before the first frame update
    void Start()
    {
		particles.Stop();
		startTime = 0;
		playing = false;

        rb = GetComponent<Rigidbody>();
        Input.compensateSensors = true;
        Input.gyro.enabled = true;

        Screen.sleepTimeout = SleepTimeout.NeverSleep;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
		if (playing){
			Vector3 rotation = Input.gyro.attitude.eulerAngles;

			// magic stuff
			rotation = SwapYZ(rotation);

			rb.MoveRotation(Quaternion.Euler(-rotation));

			if (Input.gyro.userAcceleration.z >= forceThreshold &&
					Vector3.Distance(transform.position, krampouez.transform.position) <= distanceThreshold) {
				krampouez.JumpFlip();
			}
		}
    }

    private Vector3 SwapYZ(Vector3 vector) {
        float tempZ = vector.z;

        vector.z = vector.y;
        vector.y = tempZ;

        return vector;
    }

	private void OnCollisionStay(Collision collision){
		if (playing){
			krampouez = collision.gameObject.GetComponent<Krampou>();

			if (krampouez) {
				krampouez.Cook();
				particles.Play();
			}
		}
	}

    public void Enable(){ 
		startTime = Time.time;
		playing = true; 
	}
    public void Disable(){ playing = false; }
}
