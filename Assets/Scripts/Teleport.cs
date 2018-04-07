using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class Teleport : MonoBehaviour {
	float mfieldOfView;
	//public Camera camera;

    private Camera sceneCamera;
    private Camera playerCamera;
    private networkManager networkmgn; 

	// Use this for initialization
	void Start () {
		mfieldOfView = 60.0f;
        sceneCamera = Camera.main;
        playerCamera = gameObject.GetComponentInChildren<Camera>();
        networkmgn = new networkManager(); 
    }
	
	// Update is called once per frame
	void Update () {
		RaycastHit hit;
		Ray ray = sceneCamera.ScreenPointToRay(Input.mousePosition);
        sceneCamera.fieldOfView = mfieldOfView;

		if (Input.GetMouseButtonDown (0)) {

			if (Physics.Raycast (ray, out hit)) {
				Transform objectHit = hit.transform;

				if (objectHit.gameObject.tag == "chat") {
                    networkmgn.OnClick(new Vector3(objectHit.position.x, 1.75f, objectHit.position.z));
                    gameObject.transform.position = new Vector3 (objectHit.position.x, 1.75f, objectHit.position.z);
                    ToggleCameraON();
                }
			}
		}


		if (Input.GetKey(KeyCode.Escape)){

            ToggleCameraOFF();
            sceneCamera.transform.position = new Vector3 (0, 17f, 0);

		}
	}
    //onclick change camera between scene and FPV
    public void ToggleCameraON() {
         sceneCamera.enabled = false;
         playerCamera.enabled = true;

    }
    public void ToggleCameraOFF()
    {
        sceneCamera.enabled = true;
        playerCamera.enabled = false;

    }

}
