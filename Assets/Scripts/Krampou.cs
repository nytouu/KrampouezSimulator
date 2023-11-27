using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Krampou : MonoBehaviour
{
	public float force = 300f;

	public PanMovement pan;
    private Rigidbody rb;

    // Start is called before the first frame update
    void Start()
    {
		rb = GetComponent<Rigidbody>();

		transform.position = new Vector3(pan.transform.position.x, pan.transform.position.y + 20, pan.transform.position.z);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

	public void JumpFlip() {
		Debug.Log("JumpFlip");

		rb.AddForce(new Vector3(0f, force, 0f));
		rb.angularVelocity.Set(force * 1000f, 0f, 0f);
	}
}
