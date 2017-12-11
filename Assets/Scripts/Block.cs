using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block : MonoBehaviour {
	public GameObject BlockBreakParticle;
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
			Destroy (gameObject);
			GameObject partcle = Instantiate (BlockBreakParticle, transform.position, transform.rotation) as GameObject;

			breakableCount--;

			sceneLoadManager.BlockDestroyed ();
		}

	}
}