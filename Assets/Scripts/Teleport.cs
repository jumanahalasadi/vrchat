using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using UnityEngine.UI;

public class Teleport : MonoBehaviour {
	float mfieldOfView;
	//public Camera camera;

    private Camera sceneCamera;
    private Camera playerCamera;
    private networkManager networkmgn; 
	private Button EmojiBtn;
	private Button ExitBtn;
	private GameObject title;


	// Use this for initialization
	void Start () {
		title = GameObject.Find ("ActiveChats");
		EmojiBtn = GameObject.Find ("EmojiBtn").GetComponent<Button>();
		ExitBtn = GameObject.Find ("ExitBtn").GetComponent<Button>();
		mfieldOfView = 60.0f;
        sceneCamera = Camera.main;
        playerCamera = gameObject.GetComponentInChildren<Camera>();
        networkmgn = new networkManager(); 
    }
	
	// Update is called once per frame
	void Update () {
		
		RaycastHit hit;
		Ray ray =playerCamera.ScreenPointToRay(Input.mousePosition);
		//sceneCamera = Camera.main;

        //sceneCamera.fieldOfView = mfieldOfView;

		if (Input.GetMouseButtonDown (0)) {

			if (Physics.Raycast (ray, out hit)) {
				Transform objectHit = hit.transform;

				if (objectHit.gameObject.tag == "chat") {

					title .SetActive (false);

					EmojiBtn.interactable = true;
					ExitBtn.interactable = true;

                    networkmgn.OnClick(new Vector3(objectHit.position.x, -18f, objectHit.position.z));
                    gameObject.transform.position = new Vector3 (objectHit.position.x, -18f, objectHit.position.z);
                    ToggleCameraON();
                }
			}
		}


		if (Input.GetKey(KeyCode.Escape)){

           // ToggleCameraOFF();
			EmojiBtn.interactable = false;
			ExitBtn.interactable = false;
			title .SetActive (true);

          	gameObject.transform.position = new Vector3 (0, 0, 0);
			gameObject.transform.eulerAngles = new Vector3 (0,  -62.587f, 0);

		}
	}
    //onclick change camera between scene and FPV
    public void ToggleCameraON() {
//         sceneCamera.enabled = false;
//         playerCamera.enabled = true;

    }
    public void ToggleCameraOFF()
    {
//        sceneCamera.enabled = true;
//        playerCamera.enabled = false;

    }

}
