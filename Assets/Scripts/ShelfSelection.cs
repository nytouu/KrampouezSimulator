using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShelfSelection : MonoBehaviour, ITouchable
{
    /* private GameObject selectedObject; */

    public void OnTouchedDown(Vector3 touchPosition)
    {
        Debug.Log(touchPosition);
    }

    public void OnTouchedStay(Vector3 touchPosition)
    {
        transform.position = touchPosition;
    }

    public void OnTouchedUp()
    {

    }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
