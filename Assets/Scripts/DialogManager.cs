using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DialogManager : MonoBehaviour, IMiniGame
{
	public TextMeshProUGUI textBox;
	public Button button;
	public Image buttonImage;

	public MiniGameManager gameManager;

	private int clickCount;

    // Start is called before the first frame update
    void Start()
    {
		Enable();
		textBox.text = "Bonjour et bienvenue dans ma crêperie !";
    }

    // Update is called once per frame
    void Update()
    {
    }

	public void OnClick(){
		if (gameManager.CurrentGame == GameState.Dialog){
			clickCount++;
			switch (clickCount) {
				case 1:
					textBox.text = "Tu vas m’aider à préparer les commandes des clients cette semaine.";
					break;
				case 2:
					textBox.text = "Aujourd’hui, je vais t’apprendre à préparer les crêpes de froment.";
					break;
				case 3:
					textBox.text = "On va faire comme si j’étais un client, d’accord ?";
					break;
				case 4:
					textBox.text = "“Bonjour, je voudrais une crêpe de froment au caramel, s’il vous plaît.”";
					break;
				case 5:
					textBox.text = "Maintenant, passe en cuisine.";
					break;
				default:
					gameManager.NextGame();
					return;
			}
		}
		if (gameManager.CurrentGame == GameState.Shelf){
			clickCount++;
			switch (clickCount) {
				case 1:
					textBox.text = "Tu dois choisir les ingrédients pour composer une pâte adaptée à celle que le client t’a demandé.";
					break;
				case 2:
					textBox.text = "";
					break;
			}
		}
	}

    public void Enable() {
		textBox.enabled = true;
		button.enabled = true;
		buttonImage.enabled = true;
		clickCount = 0;
	}

    public void Disable() {
		textBox.enabled = false;
		button.enabled = false;
		buttonImage.enabled = false;
	}
}
