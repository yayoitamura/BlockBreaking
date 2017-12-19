using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour {

	private Paddle paddle;
	private Text scoreText;

	// Use this for initialization
	void Start () {
		scoreText = GameObject.Find ("Score").GetComponent<Text> ();
		paddle = GameObject.Find ("Paddle").GetComponent<Paddle> ();

	}

	// Update is called once per frame
	void Update () {

		scoreText.text = "score :  " + paddle.score;
	}
}