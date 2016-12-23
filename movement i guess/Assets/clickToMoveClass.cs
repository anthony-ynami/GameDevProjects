using UnityEngine;
using System.Collections;

public class clickToMoveClass : MonoBehaviour {
    public Vector3 destination;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetMouseButton(0))
        {
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            if(Physics.Raycast(ray, out hit) && hit.collider.tag == "ground")
            {
                destination = hit.point;
                Vector3 move;

                move = destination - transform.position;
                move = move.normalized;
                transform.position += move;
               // transform.position = Vector3.Lerp(transform.position, destination, .2f);
            }
        }
	}
}
