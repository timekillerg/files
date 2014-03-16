
using System;
using UnityEngine;
using System.Collections;

namespace AssemblyCSharp
{
	public class AppCore
	{
		public enum Status {LOADING, MENU, FAST_GAME, MAPS, LEVELS, SCORES, EXIT, LEVELS_METEOR, LEVELS_ICE, LEVELS_SUN,LEVELS_DOWN};
		private static Status currentStatus;
		private static Status previousStatus;
		private static bool isStart = true;
		//Screens from Main Menu
		private static GameObject goMaps;
		private static GameObject goMain;
		private static GameObject goScores;
		//Screens from Maps (levels screens)
		private static GameObject goMeteorLevel;
		private static GameObject goSunLevel;
		private static GameObject goIceLevel;
		private static GameObject goDownLevel;


		public static void SetStatus(Status status)
		{
			currentStatus = status;
		}

		public static void SetPreviousStatus(Status status)
		{
			previousStatus = status;
		}

		public static Status GetCurrentStatus()
		{
			return currentStatus;
		}

		public static Status GetPresiousStatus()
		{
			return previousStatus;
		}
		
		void UnlockGame()		
		{
		}
		
		void LockGame()		
		{
		}

		public static void Start () {
			if (isStart) 
			{
				currentStatus = Status.LOADING;
			}
			else 
			{
				currentStatus = Status.MENU;
				Load();
			}
		}
		
		private AppCore () {}
		
		public static void Load()
		{
			goMaps = GameObject.Find ("Screen Maps");
			goMain = GameObject.Find ("Screen Main Menu");
			goScores = GameObject.Find ("Screen Scores");
			goMeteorLevel = GameObject.Find ("Screen Levels Meteor");
			goIceLevel = GameObject.Find ("Screen Levels Ice");
			goSunLevel = GameObject.Find ("Screen Levels Sun");
			goDownLevel = GameObject.Find ("Screen Levels Down");

			goMaps.rigidbody.velocity = Vector3.zero;
			goScores.rigidbody.velocity = Vector3.zero;
			goMain.rigidbody.velocity = Vector3.zero;
			goMaps.rigidbody.angularVelocity  = Vector3.zero;
			goScores.rigidbody.angularVelocity  = Vector3.zero;
			goMain.rigidbody.angularVelocity  = Vector3.zero;

			goMeteorLevel.rigidbody.velocity = Vector3.zero;
			goMeteorLevel.rigidbody.angularVelocity  = Vector3.zero;
			goIceLevel.rigidbody.velocity = Vector3.zero;
			goIceLevel.rigidbody.angularVelocity  = Vector3.zero;
			goSunLevel.rigidbody.velocity = Vector3.zero;
			goSunLevel.rigidbody.angularVelocity  = Vector3.zero;
			goDownLevel.rigidbody.velocity = Vector3.zero;
			goDownLevel.rigidbody.angularVelocity  = Vector3.zero;

			switch (currentStatus) 
			{
			case Status.FAST_GAME:
				StartFastGame();
				break;
			case Status.MENU:
				ShowMainMenu();
				break;
			case Status.EXIT:
				ExitGame();
				break;
			case Status.MAPS:
				ShowMaps();
				break;
			case Status.SCORES:
				ShowScores();
				break;
			case Status.LEVELS_METEOR:
			case Status.LEVELS_ICE:
			case Status.LEVELS_SUN:
			case Status.LEVELS_DOWN:
				ShowLevels();
				break;
			case Status.LOADING:
				ShowLoadingScreen();
				break;
			}
		}

		static void ShowLevels()
		{
			goMeteorLevel.transform.position = new Vector3 (14f,0.0f,0.0f);
			goIceLevel.transform.position = new Vector3 (14f,0.0f,0.0f);
			goDownLevel.transform.position = new Vector3 (14f,0.0f,0.0f);
			goSunLevel.transform.position = new Vector3 (14f,0.0f,0.0f);
			goMaps.rigidbody.AddForce (Vector3.left * 80000 * Time.deltaTime);
			switch (currentStatus) 
			{
			case Status.LEVELS_ICE:
				goIceLevel.rigidbody.AddForce (Vector3.left * 80000 * Time.deltaTime);
				break;
			case Status.LEVELS_SUN:
				goSunLevel.rigidbody.AddForce (Vector3.left * 80000 * Time.deltaTime);
				break;
			case Status.LEVELS_DOWN:
				goDownLevel.rigidbody.AddForce (Vector3.left * 80000 * Time.deltaTime);
				break;
			case Status.LEVELS_METEOR:
				goMeteorLevel.rigidbody.AddForce (Vector3.left * 80000 * Time.deltaTime);
				break;
			}
		}
		
		static void StartFastGame()
		{
			Application.LoadLevel(1);
		}
		
		static void ShowMainMenu()
		{
			if(GameObject.Find ("Screen First Loading"))
				MonoBehaviour.Destroy (GameObject.Find ("Screen First Loading"));

			goMain.transform.position = new Vector3 (-14f,0.0f,0.0f);
			goMain.rigidbody.AddForce (Vector3.right * 80000 * Time.deltaTime);

			if(goMaps.transform.position.x > -2 && goMaps.transform.position.x <2)
				goMaps.rigidbody.AddForce (Vector3.right * 80000 * Time.deltaTime);

			if(goScores.transform.position.x > -2 && goScores.transform.position.x <2)
				goScores.rigidbody.AddForce (Vector3.right * 80000 * Time.deltaTime);

		}
		
		static void ShowMaps()
		{
			if(goIceLevel.transform.position.x > -1 && goIceLevel.transform.position.x <1)
				goIceLevel.rigidbody.AddForce (Vector3.right * 80000 * Time.deltaTime);
			if(goDownLevel.transform.position.x > -1 && goDownLevel.transform.position.x <1)
				goDownLevel.rigidbody.AddForce (Vector3.right * 80000 * Time.deltaTime);
			if(goSunLevel.transform.position.x > -1 && goSunLevel.transform.position.x <1)
				goSunLevel.rigidbody.AddForce (Vector3.right * 80000 * Time.deltaTime);
			if(goMeteorLevel.transform.position.x > -1 && goMeteorLevel.transform.position.x <1)
				goMeteorLevel.rigidbody.AddForce (Vector3.right * 80000 * Time.deltaTime);
			if(goMain.transform.position.x > -1 && goMain.transform.position.x <1)
				goMain.rigidbody.AddForce (Vector3.left * 80000 * Time.deltaTime);

			if(AppCore.GetPresiousStatus() == AppCore.Status.MENU)
			{
				goMaps.transform.position = new Vector3 (14f,0.0f,0.0f);
				goMaps.rigidbody.AddForce (Vector3.left * 80000 * Time.deltaTime);
			}
			else
			{
				goMaps.transform.position = new Vector3 (-14f,0.0f,0.0f);
				goMaps.rigidbody.AddForce (Vector3.right * 80000 * Time.deltaTime);
			}
		}
		
		static void ShowScores()
		{
			goScores.transform.position = new Vector3 (14f,0.0f,0.0f);
			goMaps.transform.position = new Vector3 (14f,0.0f,0.0f);
			goMain.transform.position = new Vector3 (0f,0.0f,0.0f);
			
			goMain.rigidbody.AddForce (Vector3.left * 80000 * Time.deltaTime);
			goScores.rigidbody.AddForce (Vector3.left * 80000 * Time.deltaTime);
		}
		
		static void ExitGame()
		{
			Application.Quit();
		}
		
		static void ShowLoadingScreen()
		{
			
		}

		
		public static void BackToMenu()
		{
			isStart = false;
			Application.LoadLevel(0);
			previousStatus = Status.LOADING;
			currentStatus = Status.MENU;
		}

		public static void BackButtonPress()
		{			
			if((goMain.rigidbody.position.x < 1 && goMain.rigidbody.position.x > -1)
			   || (goMaps.rigidbody.position.x < 1 && goMaps.rigidbody.position.x > -1)
			   || (goScores.rigidbody.position.x < 1 && goScores.rigidbody.position.x > -1)
			   || (goIceLevel.rigidbody.position.x < 1 && goIceLevel.rigidbody.position.x > -1)			   
			   || (goDownLevel.rigidbody.position.x < 1 && goDownLevel.rigidbody.position.x > -1)			   
			   || (goMeteorLevel.rigidbody.position.x < 1 && goMeteorLevel.rigidbody.position.x > -1)
			   || (goSunLevel.rigidbody.position.x < 1 && goSunLevel.rigidbody.position.x > -1))			
					SetPreviousStatus(currentStatus);
			switch (currentStatus)
			{
			case Status.MAPS:				
			case Status.SCORES:
			case Status.LOADING:				
				SetStatus(AppCore.Status.MENU);
				Load();
				break;
			case Status.MENU:
				SetStatus(AppCore.Status.EXIT);
				Load();
				break;
			case Status.LEVELS_METEOR:
			case Status.LEVELS_ICE:
			case Status.LEVELS_SUN:
			case Status.LEVELS_DOWN:
				SetStatus(AppCore.Status.MAPS);
				Load();
				break;
			}
		}
	}
}

