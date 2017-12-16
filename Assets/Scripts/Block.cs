﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block : MonoBehaviour {
	public GameObject brokenPiece;
	public GameObject enemy;
	SceneLoadManager sceneLoadManager;
	public static int breakableCount;
	public int strength;

	void Start () {
		breakableCount++;
		sceneLoadManager = GameObject.Find ("SceneLoadManager").GetComponent<SceneLoadManager> ();

	}

	void Update () {

	}

	void OnCollisionEnter2D (Collision2D collision) {
		HitBlock (collision.gameObject.tag);
	}

	//BlueBlock用
	void OnTriggerEnter2D (Collider2D collider) {
		HitBlock (collider.gameObject.tag);
	}

	void HitBlock (string tag) {
		if (tag == "Ball") {
			strength--;
			if (strength <= 0) {
				breakableCount--;
				Destroy (gameObject);
				// Instantiate (enemy, transform.position, transform.rotation);
				PieceBroken ();

				sceneLoadManager.BlockDestroyed ();
			}
		}
	}

	void PieceBroken () {
		var m = brokenPiece.GetComponent<ParticleSystem> ().main;
		m.startColor = GetComponent<Renderer> ().material.color;
		GameObject partcle = Instantiate (brokenPiece, transform.position, transform.rotation) as GameObject;
		Destroy (partcle, 1f);
	}

}