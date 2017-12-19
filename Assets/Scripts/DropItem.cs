using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropItem : MonoBehaviour {

	public GameObject bomb;
	public int point;
	public int hp;

	void Start () {

	}

	// Update is called once per frame
	void Update () {

	}

	void OnCollisionEnter2D (Collision2D other) {
		Destroy (gameObject);
		GameObject drop = Instantiate (bomb, transform.position, transform.rotation);
		Destroy (drop, 0.1f);
	}
}