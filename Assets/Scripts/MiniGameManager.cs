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
	[SerializeField] private GameObject krampouGame;
	[SerializeField] private GameObject shelfGame;
	[SerializeField] private GameObject dialogGame;
	[SerializeField] private GameObject mixingGame;

	[SerializeField] private CameraManager cameraManager;

	[SerializeField] private GameState currentGame;
	public GameState CurrentGame { get => currentGame; }

    // Start is called before the first frame update
    void Start()
    {
		/* SwitchGame(GameState.Dialog, dialogGame); */
    }

    // Update is called once per frame
    void Update()
    {
        
    }

	private void SwitchGame(GameObject newInstance, GameObject oldInstance) {
		IMiniGame newGame = newInstance.gameObject.GetComponent<IMiniGame>();
		IMiniGame oldGame = oldInstance.gameObject.GetComponent<IMiniGame>();

		if (newGame != null && oldGame != null){
			currentGame++;
			oldGame.Disable();
			cameraManager.ChangeCamera(currentGame);
			newGame.Enable();
		}
	}

	public void NextGame(){
		switch (currentGame) {
			case GameState.Dialog: 
				SwitchGame(shelfGame, dialogGame);
				break;
			case GameState.Shelf: 
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
