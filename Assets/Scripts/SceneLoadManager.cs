using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoadManager : MonoBehaviour {

	public void LoadScene (int scene) {
		SceneManager.LoadScene (scene);
	}

	private IEnumerator BeforeLoadScene (int scene) {
		yield return new WaitForSeconds (2.5f);
		LoadScene (scene);
	}

	public void BlockDestroyed () {
		if (Block.breakableCount <= 0) {
			StartCoroutine ("BeforeLoadScene", SceneManager.GetActiveScene ().buildIndex + 1);
		}
	}
}