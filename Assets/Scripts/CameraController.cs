using UnityEngine;
using System.Collections;

public class CameraController : MonoBehaviour {

	GameObject player;
	Vector3 offset;
	bool tracking = false;

	public void TrackPlayer (GameObject player_to_track)
	{
		player = player_to_track;
		offset = transform.position - player.transform.position;
		tracking = true;
	}
	
	// Update is called once per frame
	void LateUpdate () {
		if (tracking) {
			transform.position = player.transform.position + offset;
		}
	}
}
