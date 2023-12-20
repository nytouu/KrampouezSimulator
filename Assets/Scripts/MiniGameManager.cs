using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum GameState {
	Dialog,
	Shelf,
	Mixing,
	Krampou,
	Fillings,
	Serving,
}

public class MiniGameManager : MonoBehaviour
{
	[SerializeField] private PanMovement krampouGame;
	[SerializeField] private SelectBox shelfGame;
	[SerializeField] private DialogManager dialogGame;
	[SerializeField] private MixStick mixingGame;
	[SerializeField] private Fillings fillingsGame;

	[SerializeField] private CameraManager cameraManager;

	[SerializeField] private GameState currentGame;
	public GameState CurrentGame { get => currentGame; }

	private IMiniGame currentInstance;

	private List<GameObject> selectedIngredients;

    // Start is called before the first frame update
    void Start()
    {
		currentInstance =  dialogGame;
		/* SwitchGame(GameState.Dialog, dialogGame); */
    }

    // Update is called once per frame
    void Update()
    {
        
    }

	private IMiniGame SwitchGame<T>(T newInstance) where T : IMiniGame {
		currentGame++;
		currentInstance.Disable();
		cameraManager.ChangeCamera(currentGame);
		newInstance.Enable();

		return newInstance;
	}

	public void NextGame(){
		switch (currentGame) {
			case GameState.Dialog: 
				currentInstance = SwitchGame(shelfGame);
				break;
			case GameState.Shelf: 
				selectedIngredients = shelfGame.SelectedList;
				currentInstance = SwitchGame(mixingGame);
				break;
			case GameState.Mixing: 
				currentInstance = SwitchGame(krampouGame);
				break;
			case GameState.Krampou: 
				currentInstance = SwitchGame(fillingsGame);
				break;
			case GameState.Fillings: 
				currentInstance = SwitchGame(dialogGame);
				break;
			case GameState.Serving: 
				break;
		}
	}
}
