using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectBox : MonoBehaviour, IMiniGame
{
	[SerializeField] private List<ShelfItem> shelfItems;

	private List<GameObject> selectedList;
	public List<GameObject> SelectedList { get => selectedList; }

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
