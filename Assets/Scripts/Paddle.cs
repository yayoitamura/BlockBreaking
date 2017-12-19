using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paddle : MonoBehaviour {

	private const float MAX_MOVE_RANGE = 3.5f;
	private const float MIN_MOVE_RANGE = -3.5f;
	private int hp = 3;
	public int score = 0;
	SceneLoadManager sceneLoadManager;

	void Start () {

	}

	// Update is called once per frame
	void Update () {
		Vector2 mousePosi = Camera.main.ScreenToWorldPoint (Input.mousePosition);
		mousePosi.y = transform.position.y;
		mousePosi.x = Mathf.Clamp (mousePosi.x, MIN_MOVE_RANGE, MAX_MOVE_RANGE);
		transform.position = mousePosi;
	}

	private void OnCollisionEnter2D (Collision2D other) {
		if (other.gameObject.tag == "Enemy") {
			Debug.Log (other.gameObject.GetComponent<DropItem> ().hp);
			hp += other.gameObject.GetComponent<DropItem> ().hp;
			// PaddleBroken ();
		}
		if (other.gameObject.tag == "Coin") {
			Debug.Log (score);
			Debug.Log (other.gameObject.GetComponent<DropItem> ().point);
			score += other.gameObject.GetComponent<DropItem> ().point;
			Debug.Log (score);
		}
	}

	private void PaddleBroken () {
		sceneLoadManager = GameObject.Find ("SceneLoadManager").GetComponent<SceneLoadManager> ();
		sceneLoadManager.LoadScene (7);
	}

}