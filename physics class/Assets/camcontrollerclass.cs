using UnityEngine;
using System.Collections;

public class camcontrollerclass : MonoBehaviour {

    //public GameObject camera1;
    // public GameObject camera2;

    public GameObject[] Cams;

	// Use this for initialization
	void Start () {
        // camera1.SetActive(true);
        //camera2.SetActive(false);
        DeactivateCameras();

     
	}
	
	// Update is called once per frame
	void Update () {

        if (Input.GetKeyDown(KeyCode.Space){
            DeactivateCameras();
            if(currentCam < Cams.Length - 1)
            {
                currentCam += 1;
            }
            else
            {
                currentCam = 0;
            }
        }
	
	}

    public void activateCamera(int _camNumber)
    {
        Cams[_camNumber].SetActive(true);
        currentCam = _camNumber-1;
    }

    public void DeactivateCameras()
    {
        for (int i = 0; i < Cams.Length; i++)
        {
            Cams[i].SetActive(false);
        }
    }
}
