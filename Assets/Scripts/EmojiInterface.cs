using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;


public class EmojiInterface : MonoBehaviour {

	public GameObject Panel;
	int counter;
	private void FixedUpdate(){

		if (Input.GetKey ("e")) {
			showhidePanel ();
		}
	}

	public void showhidePanel()
	{
		counter++;
		if (counter % 2 == 1)
		{
			Panel.gameObject.SetActive(true);
		}
		else {
			Panel.gameObject.SetActive(false);
		}
	}

}
