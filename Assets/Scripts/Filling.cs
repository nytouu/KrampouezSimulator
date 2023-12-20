using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Filling : MonoBehaviour, ITouchable, IMiniGame
{
	public TouchManager touchManager;
	public float clipDistance;

	private bool playing;
	private bool selected;

	public Ingredient type;
	public GameObject popup;
	public Sprite sprite;

	private GameObject popupInstance;

	public Vector3 offset;

    public void OnTouchedDown(Vector3 touchPosition)
    {
        if (!selected && playing) {
			popupInstance = Instantiate(popup);
			SpriteRenderer spriteRenderer = popupInstance.gameObject.GetComponent<SpriteRenderer>();
			spriteRenderer.sprite = sprite;
        }
    }

    public void OnTouchedStay(Vector3 touchPosition)
    {
        if (!selected && playing) {
            popupInstance.transform.position = touchPosition + offset;
        }
    }

    public void OnTouchedUp()
    {
        if (!selected && playing) {
			Destroy(popupInstance);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
		selected = false;
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void Disable() { playing = false; }

    public void Enable() {
		selected = false;
		playing = true;
		touchManager.clipDistance = clipDistance;
    }
}
