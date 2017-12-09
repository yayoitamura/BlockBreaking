using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paddle : MonoBehaviour {

	private const float MAX_MOVE_RANGE = 2.8f;
	private const float MIN_MOVE_RANGE = -2.8f;
	// Use this for initialization
	void Start () {

	}

	// Update is called once per frame
	void Update () {
		Vector2 mousePosi = Camera.main.ScreenToWorldPoint (Input.mousePosition);
		mousePosi.y = transform.position.y;
		mousePosi.x = Mathf.Clamp (mousePosi.x, MIN_MOVE_RANGE, MAX_MOVE_RANGE);
		transform.position = mousePosi;
	}
}