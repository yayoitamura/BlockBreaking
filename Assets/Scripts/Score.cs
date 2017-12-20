using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Score : MonoBehaviour {

	private Paddle paddle;
	private Text scoreText;
	private Text lifeText;
	private Text clearScore;

	public static int score;
	private int hp;

	private enum GAME_STATE {
		PLAY,
		CLEAR,
		};
		private GAME_STATE game;

		void Start () {
		if (SceneManager.GetActiveScene ().buildIndex == 6) {
		game = GAME_STATE.CLEAR;
		clearScore = GameObject.Find ("Score").GetComponent<Text> ();
		} else {
		game = GAME_STATE.PLAY;
		scoreText = GameObject.Find ("ScoreText").GetComponent<Text> ();
		lifeText = GameObject.Find ("LifeText").GetComponent<Text> ();
		paddle = GameObject.Find ("Paddle").GetComponent<Paddle> ();
		}
	}

	// Update is called once per frame
	void Update () {
		switch (game) {
			case GAME_STATE.PLAY:
				score = paddle.score;
				hp = paddle.hp;
				scoreText.text = "× " + score;
				lifeText.text = "× " + hp;
				break;

			case GAME_STATE.CLEAR:
				clearScore.text = "SCORE : " + score;
				break;
		}
	}
}