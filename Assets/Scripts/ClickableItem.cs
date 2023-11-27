using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickableItem : MonoBehaviour, ITouchable
{
    private bool selected;

    private Vector3 defaultPosition;

    private MeshRenderer currentMesh;

    private Vector3 selectedPosition;

    public void OnTouchedDown(Vector3 touchPosition)
    {
        if (!selected) {
            currentMesh.material.color = Color.red;
        }
    }

    public void OnTouchedStay(Vector3 touchPosition)
    {
        if (!selected) {
            transform.position = touchPosition;
        }
    }

    public void OnTouchedUp()
    {
        if (!selected) {
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

    void OnCollisionEnter(Collision collision) {
        selected = true;
        transform.position = selectedPosition;
        Debug.Log("touch");
    }
}
