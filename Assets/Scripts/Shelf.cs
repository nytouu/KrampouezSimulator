using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shelf : MonoBehaviour, IMiniGame
{
	[SerializeField] private List<ShelfItem> shelfItems;

    public void Disable()
    {
		foreach (ShelfItem item in shelfItems)
		{
		    item.Disable();
		}
    }

    public void Enable()
    {
		foreach (ShelfItem item in shelfItems)
		{
			item.Enable();
		}
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
