using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum GameState {
	Dialog,
	Shelf,
	Mixing,
	Krampou,
	Serving,
}

public class MiniGameManager : MonoBehaviour
{
	[SerializeField] private PanMovement krampouGame;
	[SerializeField] private SelectBox shelfGame;
	[SerializeField] private DialogManager dialogGame;
	[SerializeField] private MixStick mixingGame;

	[SerializeField] private CameraManager cameraManager;

	[SerializeField] private GameState currentGame;
	public GameState CurrentGame { get => currentGame; }

	private List<GameObject> selectedIngredients;

    // Start is called before the first frame update
    void Start()
    {
		/* SwitchGame(GameState.Dialog, dialogGame); */
    }

    // Update is called once per frame
    void Update()
    {
        
    }

	private void SwitchGame<T,U>(T newInstance, U oldInstance) where T : IMiniGame where  U: IMiniGame {
		currentGame++;
		oldInstance.Disable();
		cameraManager.ChangeCamera(currentGame);
		newInstance.Enable();
	}

	public void NextGame(){
		switch (currentGame) {
			case GameState.Dialog: 
				SwitchGame(shelfGame, dialogGame);
				break;
			case GameState.Shelf: 
				selectedIngredients = shelfGame.SelectedList;
				SwitchGame(mixingGame, shelfGame);
				break;
			case GameState.Mixing: 
				SwitchGame(krampouGame, mixingGame);
				break;
			case GameState.Krampou: 
				SwitchGame(dialogGame, krampouGame);
				break;
			case GameState.Serving: 
				break;
		}
	}
}
