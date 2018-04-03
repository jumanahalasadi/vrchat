using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateModel : MonoBehaviour {
	public float speed = 0f; //how fast the object should rotate
	public float offset = 0.0f;

	public GameObject humanObject;
	// Use this for initialization
	void Start () {
		

	}

	// Update is called once per frame
	void Update () {
		var objects = GameObject.FindGameObjectsWithTag("chat");
		var objectCount = objects.Length;
		foreach (var obj in objects) {
			obj.transform.Rotate(0,10*Time.deltaTime,0);

		}

	}
}