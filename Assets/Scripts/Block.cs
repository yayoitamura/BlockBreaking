using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block : MonoBehaviour {
	public GameObject brokenPiece;
	SceneLoadManager sceneLoadManager;
	public static int breakableCount;
	public int strength;

	void Start () {
		breakableCount++;
		sceneLoadManager = GameObject.Find ("SceneLoadManager").GetComponent<SceneLoadManager> ();

	}

	void Update () {

	}

	void OnCollisionEnter2D (Collision2D other) {
		strength--;
		if (strength <= 0) {
			breakableCount--;
			Destroy (gameObject);
			PieceBroken ();

			sceneLoadManager.BlockDestroyed ();
		}
	}

	void PieceBroken () {
		var m = brokenPiece.GetComponent<ParticleSystem> ().main;
		m.startColor = GetComponent<Renderer> ().material.color;
		GameObject partcle = Instantiate (brokenPiece, transform.position, transform.rotation) as GameObject;
		Destroy (partcle, 1f);
	}

}