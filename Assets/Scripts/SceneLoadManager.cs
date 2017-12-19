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
		Debug.Log (scene);
		SceneManager.LoadScene (scene);
	}

	// private IEnumerator LoadSceneCol (int scene) {

	// }

	private IEnumerator SceneLoad (int scene) {

		yield return new WaitForSeconds (2f);
		SceneManager.LoadScene (scene);
	}

	public void BlockDestroyed () {
		if (Block.breakableCount <= 0) {
			// LoadScene (SceneManager.GetActiveScene ().buildIndex + 1);
			StartCoroutine ("SceneLoad", SceneManager.GetActiveScene ().buildIndex + 1);
		}
	}
}