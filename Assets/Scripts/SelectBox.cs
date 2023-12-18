using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectBox : MonoBehaviour, IMiniGame
{
	private List<GameObject> selectedList;
	[SerializeField] private List<ShelfItem> shelfItems;

	public MiniGameManager gameManager;

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

		if (selectedList.Count == 3){
			gameManager.NextGame();
		}
	}

    public void Disable() {
		foreach (ShelfItem item in shelfItems)
		{
		    item.Disable();
		}
    }

    public void Enable() {
		foreach (ShelfItem item in shelfItems)
		{
			item.Enable();
		}
    }
}
