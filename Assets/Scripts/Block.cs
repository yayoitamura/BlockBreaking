using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block : MonoBehaviour {

	SceneLoadManager sceneLoadManager;
	public static int breakableCount;
	void Start () {
		breakableCount++;
		sceneLoadManager = GameObject.Find ("SceneLoadManager").GetComponent<SceneLoadManager> ();
	}

	void Update () {

	}

	void OnCollisionEnter2D (Collision2D other) {
		Destroy (gameObject);
		breakableCount--;
		sceneLoadManager.BlockDestroyed ();

	}
}