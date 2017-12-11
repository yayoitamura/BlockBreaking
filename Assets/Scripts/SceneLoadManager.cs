using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoadManager : MonoBehaviour {

	// Use this for initialization
	void Start () { }

	// Update is called once per frame
	void Update () {

	}

	public void LoadScene (int scene) {
		Debug.Log ("Load Scene");
		SceneManager.LoadScene (scene);
	}

	public void BlockDestroyed () {
		if (Block.breakableCount <= 0) {
			// LoadScene (SceneManager.GetActiveScene ().buildIndex + 1);
			LoadScene (4);
		}
	}
}