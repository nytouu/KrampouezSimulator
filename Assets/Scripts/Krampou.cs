using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Krampou : MonoBehaviour
{
	public float force = 300f;

    private Rigidbody rb;

    // Start is called before the first frame update
    void Start()
    {
		rb = GetComponent<Rigidbody>();
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
