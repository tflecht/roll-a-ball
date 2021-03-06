﻿using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PlayerController : Photon.MonoBehaviour {

	public float speed;

	public Text countText;
	public Text winText;

	private Rigidbody rb;
	private int count;

	void Start ()
	{
		rb = GetComponent<Rigidbody> ();
		count = 0;
		SetCountText ();
		winText.text = "";
	}

	void FixedUpdate ()
	{
		float moveHorizontal = Input.GetAxis ("Horizontal");
		float moveVertical = Input.GetAxis ("Vertical");

		Vector3 movement = new Vector3 (moveHorizontal, 0.0f, moveVertical);

		rb.AddForce (movement * speed);
	}

	void OnCollisionEnter(Collision collision)
	{
		Debug.Log ("OnCollisionEnter with " + collision.gameObject.ToString());
	}

	void OnTriggerEnter(Collider other) {
		if (! photonView.isMine) {
			return;
		}
		if (other.gameObject.CompareTag ("Pick Up")) {
			//other.gameObject.SetActive (false);
			other.GetComponent<PickUpController> ().PickUp ();
			++count;
			SetCountText ();
			if (count >= 15) {
				winText.text = "You Win!";
			}

		}
	}

	void SetCountText()
	{
		countText.text = "Count: " + count.ToString ();
	}
}
