using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class FinishButton : MonoBehaviour, IMiniGame
{
	private Button button;
	private Image buttonImage;
	public TextMeshProUGUI text;

    // Start is called before the first frame update
    void Start()
    {
		button = GetComponent<Button>();
		buttonImage = GetComponent<Image>();

		button.enabled = false;
		buttonImage.enabled = false;
		text.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

	public void OnClick(){

	}

    public void Enable()
    { 
		button.enabled = true;
		buttonImage.enabled = true;
		text.enabled = true;
	}

    public void Disable()
    {
		button.enabled = false;
		buttonImage.enabled = false;
		text.enabled = false;
    }
}
