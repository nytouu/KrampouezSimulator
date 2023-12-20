using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Ingredient {
	Jambon,
	Banane,
	Andouille,
	Champignon,
	Chevre,
	Fromage,
	Creme
}

public class Fillings : MonoBehaviour, IMiniGame
{
	[SerializeField] private List<Filling> fillings;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void Disable() {
		foreach (Filling item in fillings)
		{
		    item.Disable();
		}
    }

    public void Enable() {
		foreach (Filling item in fillings)
		{
			item.Enable();
		}
    }
}
