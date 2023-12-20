using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;
using UnityEngine.SceneManagement;

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
    }

    // Update is called once per frame
    void Update()
    {
    }

	public void OnClick(){
		clickCount++;
		switch (gameManager.CurrentGame){
			case GameState.Dialog:
				TextDialog();
				break;
			case GameState.Shelf:
				TextShelf();
				break;
			case GameState.Mixing:
				TextMixing();
				break;
			case GameState.Krampou:
				TextKrampou();
				break;
			case GameState.Fillings:
				TextFillings();
				break;
			case GameState.Serving:
				ServingText();
				break;
		}
	}

    private void ServingText()
    {
		switch (clickCount) {
			case 1:
				if (gameManager.Score >= 5){
					textBox.text = "La crêpe est parfaite ! Merci !";
				} else {
					textBox.text = "ahem...";
				}
				break;
			case 2:
				Disable();
				SceneManager.LoadScene(0);
				break;
		}
    }

    private void TextFillings()
    {
		switch (clickCount) {
			case 1:
				Disable();
				break;
		}
    }

    private void TextKrampou()
    {
		switch (clickCount) {
			case 1:
				textBox.text = "Veilles à bien cuire des deux côtés !";
				break;
			case 2:
				Disable();
				break;
		}
    }

    private void TextMixing()
    {
		switch (clickCount) {
			case 1:
				textBox.text = "Secoue la pâte dans le bol avec le fouet à ta disposition.";
				break;
			case 2:
				Disable();
				break;
		}
    }

    private void TextShelf(){
		switch (clickCount) {
			case 1:
				textBox.text = "Choisis les ingrédients nécessaires pour la pâte à crêpe en les glissant dans le bol.";
				break;
			case 2:
				Disable();
				break;
		}
	}

	private void TextDialog(){
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
				textBox.text = "“Bonjour, je voudrais une crêpe au caramel, s’il vous plaît.”";
				break;
			case 5:
				textBox.text = "Maintenant, passe en cuisine.";
				break;
			default:
				gameManager.NextGame();
				return;
		}
	}

    public void Enable() {
		textBox.enabled = true;
		button.enabled = true;
		buttonImage.enabled = true;
		clickCount = 0;

		switch (gameManager.CurrentGame){
			case GameState.Dialog:
				textBox.text = "Bonjour et bienvenue dans ma crêperie !";
				break;
			case GameState.Shelf:
				textBox.text = "Tu dois choisir les ingrédients pour composer une pâte adaptée à celle que le client t’a demandé.";
				break;
			case GameState.Mixing:
				textBox.text = "Super ! Maintenant, tu vas pouvoir passer au mélange de la préparation.";
				break;
			case GameState.Krampou:
				textBox.text = "Tu dois maintenant cuire la crêpe.";
				break;
			case GameState.Fillings:
				textBox.text = "Selectionnes maintenant des toppings pour ta crêpe.";
				break;
			case GameState.Serving:
				textBox.text = "Je vais déguster pour voir si tu as bien fait ton travail.";
				break;

		}
	}

    public void Disable() {
		textBox.enabled = false;
		button.enabled = false;
		buttonImage.enabled = false;
	}
}
