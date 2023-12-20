using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShelfItem : MonoBehaviour, IMiniGame, ITouchable
{
	public float clipDistance;
	public TouchManager touchManager;

    private bool selected;
    private Vector3 defaultPosition;
    private MeshRenderer currentMesh;

	public SelectBox box;

	private bool playing;

    public void OnTouchedDown(Vector3 touchPosition)
    {
        if (!selected && playing) {
            currentMesh.material.color = Color.red;
        }
    }

    public void OnTouchedStay(Vector3 touchPosition)
    {
        if (!selected && playing) {
            transform.position = touchPosition;
        }
    }

    public void OnTouchedUp()
    {
        if (!selected && playing) {
            transform.position = defaultPosition;
            currentMesh.material.color = Color.white;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        selected = false;

        defaultPosition = transform.position;
        currentMesh = GetComponent<MeshRenderer>();
    }

    // Update is called once per frame
    void Update()
    {

    }

	public void SelectAndMove(SelectBox box) {
		selected = true;
		currentMesh.material.color = Color.green;
		transform.position = box.transform.position;
		box.AddIngredientToList(gameObject);
	}

	private void OnTriggerEnter(Collider collision){
		if (playing){
			box = collision.gameObject.GetComponent<SelectBox>();

			if (box) {
				SelectAndMove(box);
			}
		}
	}

    public void Enable(){
		playing = true;
		selected = false;
		touchManager.clipDistance = clipDistance;
	}
    public void Disable(){ playing = false; }
}
