using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

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

	[SerializeField] private Button finishButton;
	[SerializeField] private Image finishImage;
	[SerializeField] private TextMeshProUGUI finishText;

	[SerializeField] private GameState currentGame;
	public GameState CurrentGame { get => currentGame; }

    private IMiniGame currentInstance;

	private List<GameObject> selectedIngredients;
	private List<GameObject> selectedFillings;
	private KrampouState krampouState;

	private int score;
	public int Score { get => score; }

    // Start is called before the first frame update
    void Start()
    {
		currentInstance =  dialogGame;
		score = 0;
		DisableButton();
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
				EnableButton();
				currentInstance = SwitchGame(shelfGame);
				dialogGame.Enable();
				break;

			case GameState.Shelf: 
				DisableButton();
				selectedIngredients = shelfGame.SelectedList;
				score += CheckForIngredients(selectedIngredients);
				currentInstance = SwitchGame(mixingGame);
				dialogGame.Enable();
				break;

			case GameState.Mixing: 
				EnableButton();
				currentInstance = SwitchGame(krampouGame);
				dialogGame.Enable();
				break;

			case GameState.Krampou: 
				krampouState = krampouGame.GetKrampouState();
				score += CheckForKrampouez(krampouState);
				currentInstance = SwitchGame(fillingsGame);
				dialogGame.Enable();
				break;

			case GameState.Fillings: 
				DisableButton();
				currentInstance = SwitchGame(dialogGame);
				dialogGame.Enable();
				break;

			case GameState.Serving: 
				dialogGame.Enable();
				break;
		}
	}

	private int CheckForIngredients(List<GameObject> ingredients){
		int total = 0;
		foreach (GameObject ingredient in ingredients){
			if (ingredient.name == "Flour"
					|| ingredient.name == "Eggs"
					|| ingredient.name == "Sugar"
					|| ingredient.name == "Milk"){
				total += 2;
			}
		}

		return total;
	}

	private int CheckForKrampouez(KrampouState state){
		switch (state){
			case KrampouState.Cooked:
				return 5;
			case KrampouState.Cramed:
				return 0;
			case KrampouState.TooCooked:
				return 3;
			case KrampouState.Uncooked:
				return 1;
			default:
				return 0;
		}
	}

	public void OnClick(){
		NextGame();
	}

	public void EnableButton(){
		finishButton.enabled = true;
		finishImage.enabled = true;
		finishText.enabled = true;
	}

	public void DisableButton(){
		finishButton.enabled = false;
		finishImage.enabled = false;
		finishText.enabled = false;
	}
}
