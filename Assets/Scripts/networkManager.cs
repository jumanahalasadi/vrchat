using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class networkManager : Photon.MonoBehaviour
{
    public GameObject prefab; 
    public const string VERSION = "1.0";
    private Vector3 spawn; 
	Camera playerCam;

	// Use this for initialization
	void Start () {
        PhotonNetwork.ConnectUsingSettings(VERSION);
        PhotonNetwork.autoJoinLobby = false;

    }


    public virtual void OnConnectedToMaster()
    {
        Debug.Log("Connect to Server ...");
        PhotonNetwork.JoinLobby(TypedLobby.Default);
    }

    public virtual void OnJoinedLobby()
    {
        Debug.Log("Joined lobby");
        PhotonNetwork.JoinRandomRoom();
    }

    public void OnClick(Vector3 pos)
    {
        Debug.Log("passed");
        spawn = pos; 
    }

    public virtual void OnFailedToConnectToPhoton(DisconnectCause cause)
    {
        Debug.LogError("Cause: " + cause);
    }

    public virtual void OnPhotonRandomJoinFailed()
    {
        PhotonNetwork.CreateRoom(null, new RoomOptions() { MaxPlayers = 4 }, null);
    }

	private void Update() {
		if (playerCam) {
			int count = Camera.allCameras.Length;

			//if more than 1 camera 
			if (count > 1) {
				for (int i = 0; i < count; i++) {
					if (Camera.allCameras [i] == playerCam) {
					} else {
						Camera.allCameras [i].enabled = false;
					}
				}
			}

		}

	}

    public void OnJoinedRoom()
    {
		
        Debug.Log("Joined new room");
        GameObject player = PhotonNetwork.Instantiate(prefab.name, spawn,Quaternion.identity,0);
		player.transform.eulerAngles = new Vector3 (0f, 0f, 0f);

		playerCam = player.GetComponentInChildren<Camera> ();

    }

    public void JointRoom(string roomName) {
        PhotonNetwork.JoinRoom(roomName); 
    }

    public void CreateRoom(string roomName) {
        if (PhotonNetwork.JoinOrCreateRoom(roomName, new RoomOptions() { IsVisible = true, IsOpen = true, MaxPlayers = 4 }, TypedLobby.Default)) {
            Debug.Log("create room successfully sent.");
        }
        else
        {
            Debug.Log("create room failed to send");
        }
    }

    public void LeaveRoom() {
        PhotonNetwork.LeaveRoom(); 
    }

    public void OnReceivedRoomListUpdate() {
        Debug.Log("updated room listing");
        Debug.Log("List length: "+ PhotonNetwork.GetRoomList().Length);
        RoomInfo[] rooms = PhotonNetwork.GetRoomList();
        for (int i = 0; i < PhotonNetwork.GetRoomList().Length; i++) {
            RoomReceived(rooms[i]);
        }

        PhotonNetwork.GetRoomList().ToList().ForEach(x => { Debug.Log(x.Name.ToString()); });

    }

    private void RoomReceived(RoomInfo room) {
        Debug.Log("Room: " + room.Name);
    }
 

}
