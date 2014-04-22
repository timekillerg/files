using UnityEngine;
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
	
	private bool gameOver;
	private bool restart;
	private int score;
	
	void Start ()
	{
		gameOver = false;
		restart = false;
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
			if(AppCore.CurrentStatus == AppCore.Status.FAST_GAME)
				AppCore.CurrentStatus = AppCore.Status.FAST_GAME_PAUSE;
            else if (AppCore.CurrentStatus == AppCore.Status.FAST_GAME_PAUSE)
					AppCore.CurrentStatus = AppCore.Status.FAST_GAME;
            else if (AppCore.CurrentStatus  == AppCore.Status.ANY_LEVEL)
                AppCore.CurrentStatus = AppCore.Status.ANY_LEVEL_PAUSE;
            else if (AppCore.CurrentStatus == AppCore.Status.ANY_LEVEL_PAUSE)
                AppCore.CurrentStatus = AppCore.Status.ANY_LEVEL;
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
                
                if(AppCore.CurrentStatus == AppCore.Status.FAST_GAME || AppCore.CurrentStatus == AppCore.Status.ANY_LEVEL)
				    Instantiate (hazard, spawnPosition, spawnRotation);

				yield return new WaitForSeconds (spawnWait);
			}
			yield return new WaitForSeconds (waveWait);
			
			if (gameOver)
			{				
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
        gameOver = true;
        if (AppCore.CurrentStatus == AppCore.Status.FAST_GAME)
            AppCore.CurrentStatus = AppCore.Status.FAST_GAME_OVER;
        else if (AppCore.CurrentStatus == AppCore.Status.ANY_LEVEL)
            AppCore.CurrentStatus = AppCore.Status.ANY_LEVEL_LOSE;
	}
}