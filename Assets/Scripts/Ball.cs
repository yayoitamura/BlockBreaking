using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour {
	Rigidbody2D rb2d;
	private float thrust = 15f;
	private const float PADDLE_TO_BALL_VECTOR = 0.2f;
	private GameObject paddle;
	private Vector2 paddlePositon;

	private enum GAME_STATE {
		READY,
		PLAY,
		};
		private GAME_STATE game = GAME_STATE.READY;

		void Start () {
		rb2d = GetComponent<Rigidbody2D> ();
		paddle = GameObject.Find ("Paddle");

	}

	void Update () {

		switch (game) {
			case GAME_STATE.READY:

				paddlePositon = paddle.transform.position;
				paddlePositon.y += PADDLE_TO_BALL_VECTOR;
				transform.position = paddlePositon;

				if (Input.GetMouseButton (0)) {
					rb2d.velocity = new Vector2 (Random.Range (-0.5f, 0.5f), thrust);
					game = GAME_STATE.PLAY;

				}
				break;

			case GAME_STATE.PLAY:
				if (rb2d.velocity.magnitude != 15) { }

				break;
		}
	}
	// void OnCollisionEnter2D (Collision2D collision) {

		// if (rb2d.velocity.y <= 10) {
		// 	rb2d.velocity = new Vector2 (rb2d.velocity.x, thrust);
		// }
		// Vector2 tweak = new Vector2 (Random.Range (0f, 0.2f), Random.Range (0f, 0.2f));
		// GetComponent<Rigidbody2D> ().velocity += tweak;
	// }
}