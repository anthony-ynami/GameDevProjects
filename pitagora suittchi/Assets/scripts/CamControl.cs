using UnityEngine;
using System.Collections;

public class CamControl : MonoBehaviour
{


    public GameObject[] Cameras;
    private int currentCam;


    // Use this for initialization
    void Start()
    {

        DeactivateCameras();
        Cameras[0].SetActive(true);
        currentCam = 0;

    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKeyDown(KeyCode.Space))
        {

            DeactivateCameras();

            if (currentCam < Cameras.Length - 1)
            {
                currentCam += 1;
            }
            else
            {
                currentCam = 0;
            }


            Cameras[currentCam].SetActive(true);

        }

    }

    public void activateCamera(int _camNumber)
    {

        Cameras[_camNumber - 1].SetActive(true);
        currentCam = _camNumber - 1;
    }

    public void DeactivateCameras()
    {
        for (int i = 0; i < Cameras.Length; i++)
        {
            Cameras[i].SetActive(false);
        }

    }
}
