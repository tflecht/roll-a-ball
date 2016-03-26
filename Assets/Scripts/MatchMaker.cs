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
		Debug.Log ("Joined a room!!!!");
		GameObject player = PhotonNetwork.Instantiate("Player", new Vector3(0f, 0.5f, 0f), Quaternion.identity, 0);
		PlayerController player_controller = player.GetComponent<PlayerController> ();
		player_controller.enabled = true;
		player_controller.countText = countText;
		player_controller.winText = winText;

		CameraController camera_controller = playerCamera.GetComponent<CameraController> ();
		camera_controller.enabled = true;
		camera_controller.TrackPlayer (player);
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
