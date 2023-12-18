using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class CameraManager : MonoBehaviour
{
	public CinemachineVirtualCamera leftCamera, clientCamera, shelfCamera, krampouCamera;

	[SerializeField] private GameState currentCamera;
	public GameState CurrentCamera { get => currentCamera; }

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
				Select(GameState.Dialog, clientCamera);
				break;
			case GameState.Mixing:
				Select(GameState.Mixing, leftCamera);
				break;
			case GameState.Shelf:
				Select(GameState.Shelf, shelfCamera);
				break;
			case GameState.Krampou:
				Select(GameState.Krampou, krampouCamera);
				break;
		}
	}

	private void ResetAllCameras() {
		clientCamera.Priority = 10;
		leftCamera.Priority = 10;
		shelfCamera.Priority = 10;
	}

	private void Select(GameState newCamera, CinemachineVirtualCamera v) {
		ResetAllCameras();
		currentCamera = newCamera;
		v.Priority = 15;
	}
}
