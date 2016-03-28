using UnityEngine;
using System.Collections;

public class PickUpController : Photon.MonoBehaviour {

	public void PickUp()
	{
		photonView.RPC ("disable", PhotonTargets.AllBufferedViaServer);
	}

	[PunRPC]
	void disable()
	{
		gameObject.SetActive (false);
	}

	// Update is called once per frame
	void Update () {
		transform.Rotate (new Vector3 (15, 30, 45) * Time.deltaTime);
	}
		
}
