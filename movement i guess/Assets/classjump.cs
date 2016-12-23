using UnityEngine;
using System.Collections;

public class classjump : MonoBehaviour {

    public float gravity;
    public float jumpStrength;
    public Vector3 yVelo;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.Space)) {

            // set the yvelocity to equal (0,jumpStrength,0) when we press space
            yVelo = new Vector3(0, jumpStrength, 0);

            transform.position += yVelo;
        }
        transform.position += yVelo * Time.deltaTime;
        if(transform.position.y > 1)
        {
            yVelo.y -= gravity;
        }
        else
        {
            yVelo.y = 0;
            transform.position = new Vector3(0, 1.0f, 0);
        }

        Debug.Log(yVelo);

	}
}
