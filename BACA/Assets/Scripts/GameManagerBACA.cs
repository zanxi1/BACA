using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManagerBACA : MonoBehaviour {

	private bool gameHasEnded = false;
	public float delay = 1f;
	public GameObject completeLevelUI;

	public void CompleteLevel() {
		Debug.Log("Win");
		completeLevelUI.SetActive(true);
	}

	public void EndGame() {
		if (gameHasEnded == false) {
			gameHasEnded = true;
			Debug.Log("Loss");
			Invoke("Restart", delay);
		}
	}

	private void Restart() {
		SceneManager.LoadScene(SceneManager.GetActiveScene().name);
	}
}
