using UnityEngine;
using UnityEngine.UI;
using System.Collections;

using Photon;

public class MatchMaker : PunBehaviour {

	public Camera playerCamera;
	public Text countText;
	public Text winText;

	public override void OnJoinedLobby()
	{
		Debug.Log ("Joined the lobby!");
		PhotonNetwork.JoinRandomRoom ();
	}

	public override void OnJoinedRoom()
	{
		// PhotonNetwork.playerList.Length;
		Debug.Log ("Joined a room!!!!");
		float x_coordinate = -8.0f + (5 * PhotonNetwork.playerList.Length);
		GameObject player = PhotonNetwork.Instantiate("Player", new Vector3(x_coordinate, 0.5f, 0f), Quaternion.identity, 0);
		PlayerController player_controller = player.GetComponent<PlayerController> ();
		player_controller.enabled = true;
		player_controller.countText = countText;
		player_controller.winText = winText;

		CameraController camera_controller = playerCamera.GetComponent<CameraController> ();
		camera_controller.enabled = true;
		camera_controller.TrackPlayer (player);

		if (PhotonNetwork.isMasterClient) {
			Debug.Log ("I'm the master, so I'm creating the Pick Ups");
			PhotonNetwork.InstantiateSceneObject("Pick Ups", new Vector3(0f, 0.5f, 0f), Quaternion.identity, 0, null);
		}
	}
		
	// Private
	// -------
	void Start()
	{
		PhotonNetwork.ConnectUsingSettings ("0.1");
	}

	void onGUI()
	{
		// GUILayout.Label(PhotonNetwork.connectionStateDetailed.ToString());
		Debug.Log (PhotonNetwork.connectionStateDetailed.ToString());
	}
		
	void OnPhotonRandomJoinFailed()
	{
		Debug.Log("Couldn't join a room, so making one.");
		PhotonNetwork.CreateRoom (null);
	}

}
