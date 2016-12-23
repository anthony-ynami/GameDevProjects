using UnityEngine;
using System.Collections;

public class camtriggah : MonoBehaviour {
    public GameObject camtoActivate;

    public int camNumber;

    public camcontrollerclass controller;

	void triggah(Collider other)
    {
        controller.DeactivateCameras();
        camtoActivate.SetActive(true);
    }
}
