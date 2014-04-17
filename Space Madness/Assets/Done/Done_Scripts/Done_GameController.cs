﻿using UnityEngine;
using System.Collections;
using AssemblyCSharp;

public class Done_GameController : MonoBehaviour
{
	public GameObject[] hazards;
	public Vector3 spawnValues;
	public int hazardCount;
	public float spawnWait;
	public float startWait;
	public float waveWait;
	
	public GUIText scoreText;
	public GUIText restartText;
	public GUIText gameOverText;
	
	private bool gameOver;
	private bool restart;
	private int score;
	
	void Start ()
	{
		gameOver = false;
		restart = false;
		restartText.text = "";
		gameOverText.text = "";
		score = 0;
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
		if (Input.GetKeyDown(KeyCode.Escape))			
		{
			if(AppCore.GetCurrentStatus() == AppCore.Status.FAST_GAME)
				AppCore.SetStatus(AppCore.Status.FAST_GAME_PAUSE);
			else if(AppCore.GetCurrentStatus() == AppCore.Status.FAST_GAME_PAUSE)
					AppCore.SetStatus(AppCore.Status.FAST_GAME);
            else if (AppCore.GetCurrentStatus() == AppCore.Status.ANY_LEVEL)
                AppCore.SetStatus(AppCore.Status.ANY_LEVEL_PAUSE);
            else if (AppCore.GetCurrentStatus() == AppCore.Status.ANY_LEVEL_PAUSE)
                AppCore.SetStatus(AppCore.Status.ANY_LEVEL);
		}
	}
	
	IEnumerator SpawnWaves ()
	{
		yield return new WaitForSeconds (startWait);
		while (true)
		{
			for (int i = 0; i < hazardCount; i++)
			{
				GameObject hazard = hazards [Random.Range (0, hazards.Length)];
				Vector3 spawnPosition = new Vector3 (Random.Range (-spawnValues.x, spawnValues.x), spawnValues.y, spawnValues.z);
				Quaternion spawnRotation = Quaternion.identity;
				Instantiate (hazard, spawnPosition, spawnRotation);
				yield return new WaitForSeconds (spawnWait);
			}
			yield return new WaitForSeconds (waveWait);
			
			if (gameOver)
			{
				restartText.text = "Press 'R' for Restart";
				restart = true;
				break;
			}
		}
	}
	
	public void AddScore (int newScoreValue)
	{
		score += newScoreValue;
		UpdateScore ();
	}
	
	void UpdateScore ()
	{
		scoreText.text = "Score:  " + score;
	}
	
	public void GameOver ()
	{
		gameOverText.text = "Game Over!";
		gameOver = true;
	}
}