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

    // Start is called before the first frame update
    void Start()
    {
		Disable();
    }

    // Update is called once per frame
    void Update()
    {

    }

	public void OnClick(){
		textBox.text = "boujour";
	}

    public void Enable() { 
		textBox.enabled = true;
		button.enabled = true;
		buttonImage.enabled = true;
	}

    public void Disable() { 
		textBox.enabled = false;
		button.enabled = false;
		buttonImage.enabled = false;
	}
}
