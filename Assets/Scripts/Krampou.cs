using UnityEngine;

public enum State {
	Uncooked,
	Cooked,
	TooCooked,
	Cramed
}
public class Krampou : MonoBehaviour
{
	public float force = 300f;
	public float duration;

	public Color colorStart;
	public Color colorCooked;
	public Color colorTooCooked;
	public Color colorCramed;

	public PanMovement pan;
    private Rigidbody rb;
	private MeshRenderer mesh;

	private State state;

    // Start is called before the first frame update
    void Start()
    {
		rb = GetComponent<Rigidbody>();
		mesh = GetComponent<MeshRenderer>();

		state = State.Uncooked;

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
		switch (state) {
			case State.Uncooked:
				ChangeColor(colorStart, colorCooked, State.Cooked);
				break;
			case State.Cooked:
				ChangeColor(colorCooked, colorTooCooked, State.TooCooked);
				break;
			case State.TooCooked:
				ChangeColor(colorTooCooked, colorCramed, State.Cramed);
				break;
			case State.Cramed:
				break;
		}
	}

	private void ChangeColor(Color start, Color target, State next) {
		mesh.material.color = Color.Lerp(colorStart, target, Time.time / duration);
		if (mesh.material.color == target) {
			state = next;
			Debug.Log(state);
		}
	}
}
