﻿using UnityEngine;
using System.Collections;

public class GameController : MonoBehaviour {

	public GameObject hazard;
	public Vector3 spawnValues;
	public int hazardCount;
	public float spawnWait;
	public float startWait;
	public float waveWait;
	public GUIText scoretext;
	private int score;
	public GUIText restartText;
	public GUIText gameOvertext;

	private bool gameOver;
	private bool restart;

	void Start() {
		score = 0;
		gameOver = false;
		restart = false;
		restartText.text = "";
		gameOvertext.text = "";
		UpdateScore ();
		StartCoroutine (SpawnWaves ());
	}

	void Update ()
	{
		if (restart)
		{
			if (Input.GetKeyDown (KeyCode.R))
			{
				Application.LoadLevel (Application.loadedLevel);
			}
		}
	}

	IEnumerator  SpawnWaves() {
		yield return new WaitForSeconds (startWait);

		while (true)
		{
			for(int i=0; i<hazardCount; i++) 
			{
				Vector3 spawnPosition = new Vector3 (Random.Range(-spawnValues.x,spawnValues.x),spawnValues.y,spawnValues.z);
				Quaternion spawnRotation = Quaternion.identity;
				Instantiate (hazard, spawnPosition, spawnRotation);
				yield return new WaitForSeconds (spawnWait);
			}
			if (gameOver)
			{
				restartText.text = "Press 'R' for Restart";
				restart = true;
				break;
			}
			yield return new WaitForSeconds (waveWait);
		}
	}

	public void AddScore(int newScoreValue)
	{
		score += newScoreValue;
		UpdateScore ();
	}

	public void GameOver() 
	{
		gameOver = true;
		gameOvertext.text = "Game Over!";
	}

	void UpdateScore() 
	{
		scoretext.text = "Score: " + score;
	}
}
