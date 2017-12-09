using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour {

	private const float PADDLE_TO_BALL_VECTOR = 0.3f;
	private GameObject paddle;
	private Vector2 paddlePositon;
	void Start () {
		paddle = GameObject.Find ("Paddle");

	}

	// Update is called once per frame
	void Update () {
		paddlePositon = paddle.transform.position;
		paddlePositon.y += PADDLE_TO_BALL_VECTOR;
		transform.position = paddlePositon;

	}
}