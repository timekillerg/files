
using System;
using UnityEngine;
using System.Collections;

namespace AssemblyCSharp
{
	public class AppCore
	{
		public enum Status {LOADING, MENU, FAST_GAME, MAPS, LEVELS, SCORES, EXIT};
		private static Status currentStatus;
		private static bool isStart = true;

		public static void SetStatus(Status status)
		{
			currentStatus = status;
		}

		public static Status GetStatus()
		{
			return currentStatus;
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
			case Status.LOADING:
				ShowLoadingScreen();
				break;
			}
		}
		
		static void StartFastGame()
		{
			Application.LoadLevel(1);
		}
		
		static void ShowMainMenu()
		{
			if (GameObject.Find ("Screen First Loading"))
				MonoBehaviour.Destroy (GameObject.Find ("Screen First Loading"));
			GameObject.Find ("Screen Main Menu").transform.position = new Vector3 (0.0f,0.0f,0.0f);
			GameObject.Find ("Screen Levels").transform.position = new Vector3 (-50f,0.0f,0.0f);
			GameObject.Find ("Screen Maps").transform.position = new Vector3 (-50f,0.0f,0.0f);
			GameObject.Find ("Screen Scores").transform.position = new Vector3 (-50f,0.0f,0.0f);
			
		}
		
		static void ShowMaps()
		{
			GameObject.Find ("Screen Main Menu").transform.position = new Vector3 (-50.0f,0.0f,0.0f);
			GameObject.Find ("Screen Levels").transform.position = new Vector3 (-50f,0.0f,0.0f);
			GameObject.Find ("Screen Maps").transform.position = new Vector3 (0.0f,0.0f,0.0f);
			GameObject.Find ("Screen Scores").transform.position = new Vector3 (-50f,0.0f,0.0f);
		}
		
		static void ShowScores()
		{
			GameObject.Find ("Screen Main Menu").transform.position = new Vector3 (-50.0f,0.0f,0.0f);
			GameObject.Find ("Screen Levels").transform.position = new Vector3 (-50f,0.0f,0.0f);
			GameObject.Find ("Screen Maps").transform.position = new Vector3 (-50f,0.0f,0.0f);
			GameObject.Find ("Screen Scores").transform.position = new Vector3 (0.0f,0.0f,0.0f);
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
		}

		public static void BackButtonPress()
		{
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
			case Status.FAST_GAME:
				SetStatus(AppCore.Status.MENU);
				BackToMenu();
				break;
			}
		}

	}
}

