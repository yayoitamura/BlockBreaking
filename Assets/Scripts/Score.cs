using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour {

	private Paddle paddle;
	private Text scoreText;
	private Text lifeText;

	// Use this for initialization
	void Start () {
		scoreText = GameObject.Find ("ScoreText").GetComponent<Text> ();
		lifeText = GameObject.Find ("LifeText").GetComponent<Text> ();
		paddle = GameObject.Find ("Paddle").GetComponent<Paddle> ();

	}

	// Update is called once per frame
	void Update () {

		scoreText.text = "× " + paddle.score;
		lifeText.text = "× " + paddle.hp;
	}
}