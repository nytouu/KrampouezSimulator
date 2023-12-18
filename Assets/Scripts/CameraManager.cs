using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public enum CameraType {
	Client,
	Left,
	Shelf,
	Krampou,
}

public class CameraManager : MonoBehaviour
{
	public CinemachineVirtualCamera leftCamera, clientCamera, shelfCamera, krampouCamera;

	[SerializeField] private CameraType currentCamera;
	public CameraType CurrentCamera { get => currentCamera; }

    // Start is called before the first frame update
    void Start()
    {
		ChangeCamera(CameraType.Client);
    }

    // Update is called once per frame
    void Update()
    {

    }

	public void ChangeCamera(CameraType type){
		switch (type) {
			case CameraType.Client:
				Select(CameraType.Client, clientCamera);
				break;
			case CameraType.Left:
				Select(CameraType.Left, leftCamera);
				break;
			case CameraType.Shelf:
				Select(CameraType.Shelf, shelfCamera);
				break;
			case CameraType.Krampou:
				Select(CameraType.Krampou, krampouCamera);
				break;
		}
	}

	private void ResetAllCameras() {
		clientCamera.Priority = 10;
		leftCamera.Priority = 10;
		shelfCamera.Priority = 10;
	}

	private void Select(CameraType newCamera, CinemachineVirtualCamera v) {
		ResetAllCameras();
		currentCamera = newCamera;
		v.Priority = 15;
	}
}
