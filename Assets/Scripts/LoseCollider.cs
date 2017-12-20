using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoseCollider : MonoBehaviour {

	private Paddle paddle;

	void Start () {
		paddle = GameObject.Find ("Paddle").GetComponent<Paddle> ();
	}

	void Update () {

	}

	private void OnTriggerEnter2D (Collider2D other) {
		if (other.gameObject.tag == "Ball") {
			paddle.hp--;
			other.gameObject.SetActive (false);
			paddle.ballSupply ();
		} else {
			Destroy (other.gameObject);
		}
	}
}