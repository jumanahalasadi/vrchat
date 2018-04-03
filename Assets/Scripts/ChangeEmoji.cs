using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeEmoji : MonoBehaviour {

	//set these in the editor
	public Material mHappy;
	public Material mFunny; 
	public Material mTongue;
	public Material mWink;
	public Material mLove;
	public Material mShy;


	// Use this for initialization
	void Start () {
		gameObject.GetComponentInChildren<MeshRenderer> ().material = mHappy;

	}
	
	// Update is called once per frame
	void Update () {


		//Happy Emoji
		if (Input.GetKey("1")){
			gameObject.GetComponentInChildren<MeshRenderer> ().material = mHappy;
		}
		if (Input.GetKey("2")){
			gameObject.GetComponentInChildren<MeshRenderer> ().material = mFunny;
		}
		if (Input.GetKey("3")){
			gameObject.GetComponentInChildren<MeshRenderer> ().material = mTongue;
		}
		if (Input.GetKey("4")){
			gameObject.GetComponentInChildren<MeshRenderer> ().material = mWink;
		}
		if (Input.GetKey("5")){
			gameObject.GetComponentInChildren<MeshRenderer> ().material = mLove;
		}
	}
}
