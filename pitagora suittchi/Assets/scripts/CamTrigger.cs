using UnityEngine;
using System.Collections;

public class CamTrigger : MonoBehaviour {

	//public GameObject camToActivate;
	public int camNumber;

	public CamControl controller;

	void OnTriggerEnter(Collider other){

		controller.DeactivateCameras();
		controller.activateCamera(camNumber);

	}
}
