using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Block : MonoBehaviour {
	public GameObject brokenPiece;
	public GameObject[] FallingObjects;
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
		HitBlock ();
	}

	//BlueBlock用
	void OnTriggerEnter2D (Collider2D collider) {
		HitBlock ();
	}

	void HitBlock () {
		strength--;
		if (strength <= 0) {
			breakableCount--;

			PieceBroken ();
			BrokenParticle ();
			EnemyAppear ();
			sceneLoadManager.BlockDestroyed ();
		}
	}

	void PieceBroken () {
		Destroy (gameObject);
	}

	void BrokenParticle () {
		var m = brokenPiece.GetComponent<ParticleSystem> ().main;
		m.startColor = GetComponent<Renderer> ().material.color;
		GameObject partcle = Instantiate (brokenPiece, transform.position, transform.rotation) as GameObject;
		Destroy (partcle, 1f);
	}

	void EnemyAppear () {
		// if (SceneManager.GetActiveScene ().buildIndex >= 4) {
		if (Random.Range (0, 5) == 1) {
			GameObject drop = FallingObjects[Random.Range (0, FallingObjects.Length)];
			Instantiate (drop, transform.position, transform.rotation);
		}
	}

}