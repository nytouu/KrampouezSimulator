using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class CameraManager : MonoBehaviour
{
	public CinemachineVirtualCamera leftCamera, clientCamera, shelfCamera, 
		   krampouCamera, fillingsCamera;

	[SerializeField] private GameState defaultCamera;

    // Start is called before the first frame update
    void Start()
    {
		ChangeCamera(defaultCamera);
    }

    // Update is called once per frame
    void Update()
    {

    }

	public void ChangeCamera(GameState type){
		switch (type) {
			case GameState.Dialog:
				Select(clientCamera);
				break;
			case GameState.Mixing:
				Select(leftCamera);
				break;
			case GameState.Shelf:
				Select(shelfCamera);
				break;
			case GameState.Krampou:
				Select(krampouCamera);
				break;
			case GameState.Fillings:
				Select(fillingsCamera);
				break;
			case GameState.Serving:
				Select(clientCamera);
				break;
		}
	}

	private void ResetAllCameras() {
		clientCamera.Priority = 10;
		leftCamera.Priority = 10;
		shelfCamera.Priority = 10;
	}

	private void Select(CinemachineVirtualCamera v) {
		ResetAllCameras();
		v.Priority = 15;
	}
}
