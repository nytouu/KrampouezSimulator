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
    }

    // Update is called once per frame
    void Update()
    {

    }

	public void OnClick(){
		clickCount++;
		switch (clickCount) {
			case 1:
				textBox.text = "Bien sûr";
				break;
			case 2:
				gameManager.NextGame();
				break;
			default:
				return;
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
