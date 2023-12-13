using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectBox : MonoBehaviour
{
	private List<GameObject> selectedList;

    // Start is called before the first frame update
    void Start()
    {
        selectedList = new List<GameObject>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

	public void AddIngredientToList(GameObject ingredient) {
		selectedList.Add(ingredient);
		Debug.Log(selectedList.Count);
	}
}
