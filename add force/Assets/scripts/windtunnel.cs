using UnityEngine;
using System.Collections;

public class windtunnel : MonoBehaviour {

    public Rigidbody target;
    public bool blowing;
    public float windSpeed;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnTriggerStay(Collider other)
    {
        blowing = true;
        target = other.attachedRigidBody;
    }
    
    }
}
