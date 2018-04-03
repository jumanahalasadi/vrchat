using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class Teleport : MonoBehaviour {
	float mfieldOfView;
	public Camera camera;

	// Use this for initialization
	void Start () {
		mfieldOfView = 60.0f;

	}
	
	// Update is called once per frame
	void Update () {
		RaycastHit hit;
		Ray ray = camera.ScreenPointToRay(Input.mousePosition);
		camera.fieldOfView = mfieldOfView;

		if (Input.GetMouseButtonDown (0)) {
			if (Physics.Raycast (ray, out hit)) {
				Transform objectHit = hit.transform;

				if (objectHit.gameObject.tag == "chat") {
					camera.transform.position = new Vector3 (objectHit.position.x, 1.75f, objectHit.position.z);
					mfieldOfView = 40f;

				}
			}
		}


		if (Input.GetKey(KeyCode.Escape)){

			camera.transform.position = new Vector3 (0, 17f, 0);

		}
	}
}
