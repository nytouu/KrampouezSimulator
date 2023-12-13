using UnityEngine;

public class Krampou : MonoBehaviour
{
	public float force = 300f;
	public float duration;

	public Color colorStart;
	public Color colorEnd;

	public PanMovement pan;
    private Rigidbody rb;
	private MeshRenderer mesh;

	private bool failed;

    // Start is called before the first frame update
    void Start()
    {
		rb = GetComponent<Rigidbody>();
		mesh = GetComponent<MeshRenderer>();

		failed = false;

		transform.position = new Vector3(pan.transform.position.x, pan.transform.position.y + 20, pan.transform.position.z);
    }

    // Update is called once per frame
    void Update()
    {

    }

	public void JumpFlip() {
		rb.AddForce(new Vector3(0f, force, 0f));
		rb.angularVelocity.Set(force * 1000f, 0f, 0f);
	}

	public void Cook(){
		if (!failed) {
			mesh.material.color = Color.Lerp(colorStart, colorEnd, Time.time / duration);

			if (mesh.material.color == colorEnd) {
				failed = true;
				Debug.Log("Cramed");
			}
		}
	}
}
