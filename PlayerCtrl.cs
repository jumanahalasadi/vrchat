﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCtrl : Photon.MonoBehaviour {

    private void Start()
    {
        GetComponentInChildren<TextMesh>().text = PhotonNetwork.playerName;
        if (!photonView.isMine)
        {
            Renderer rand = GetComponentInChildren<Renderer>();
            Texture or = rand.material.GetTexture("_MainTex");
            rand.material.shader = Shader.Find("Chat/Highlight");
            rand.material.SetTexture("", or);
        }

     }

    void Update()
    {

        if (!photonView.isMine)
        {
            Renderer rand = GetComponentInChildren<Renderer>();
            Texture or = rand.material.GetTexture("_MainTex");
            rand.material.shader = Shader.Find("Chat/Highlight");
            rand.material.SetTexture("", or);
            return;
        }
        float x = Input.GetAxis("Horizontal") * Time.deltaTime * 150.0f;
        float z = Input.GetAxis("Vertical") * Time.deltaTime * 30.0f;
        transform.Rotate(0, x, 0);
       	transform.Translate(0, 0, z);

    }
}
