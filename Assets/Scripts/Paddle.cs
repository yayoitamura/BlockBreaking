using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Paddle : MonoBehaviour {

	private const float MAX_MOVE_RANGE = 2.9f;
	private const float MIN_MOVE_RANGE = -2.9f;
	private const int GAMEOVER = 7;
	public int hp;
	public int score;
	SceneLoadManager sceneLoadManager;
	GameObject ball;

	void Start () {
		ball = GameObject.Find ("Ball");

		if (SceneManager.GetActiveScene ().buildIndex == 1) {
			PlayerPrefs.DeleteAll ();
		}

		hp = PlayerPrefs.GetInt ("HPkey", 3);
		score = PlayerPrefs.GetInt ("SCOREkey", 0);

	}

	// Update is called once per frame
	void Update () {
		Vector2 mousePosi = Camera.main.ScreenToWorldPoint (Input.mousePosition);
		mousePosi.y = transform.position.y;
		mousePosi.x = Mathf.Clamp (mousePosi.x, MIN_MOVE_RANGE, MAX_MOVE_RANGE);
		transform.position = mousePosi;

		if (hp <= 0) {
			PlayerPrefs.DeleteAll ();
		} else {
			DataSeve ();
		}
	}

	private void OnCollisionEnter2D (Collision2D other) {
		if (other.gameObject.tag == "Enemy") {
			hp += other.gameObject.GetComponent<DropItem> ().hp;

			if (hp <= 0) {
				PaddleDead ();
			}
		}

		if (other.gameObject.tag == "Hp") {
			// hp += other.gameObject.GetComponent<DropItem> ().hp;
			hp = Mathf.Clamp ((other.gameObject.GetComponent<DropItem> ().hp) + hp, 0, 3);
		}

		if (other.gameObject.tag == "Coin") {
			score += other.gameObject.GetComponent<DropItem> ().point;
		}
	}

	private void PaddleDead () {
		sceneLoadManager = GameObject.Find ("SceneLoadManager").GetComponent<SceneLoadManager> ();
		sceneLoadManager.LoadScene (GAMEOVER);
	}

	private void DataSeve () {
		PlayerPrefs.SetInt ("HPkey", hp);
		PlayerPrefs.SetInt ("SCOREkey", score);
	}

	public void ballSupply () {
		if (hp <= 0) {
			PaddleDead ();
		} else {
			ball.transform.position = new Vector2 (transform.position.x, transform.position.y + 0.2f);
			ball.SetActive (true);
			ball.GetComponent<Ball> ().ready ();
		}
	}

}