
using System;
using UnityEngine;
using System.Collections;

namespace AssemblyCSharp
{
	public class AppCore
	{
		public enum Status {LOADING, MENU, FAST_GAME, MAPS, LEVELS, SCORES, EXIT, LEVELS_METEOR, LEVELS_ICE, LEVELS_SUN,LEVELS_DOWN};
		private static Status currentStatus;
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

		public static Status GetCurrentStatus()
		{
			return currentStatus;
		}

		public static void Start () {
			if (isStart) 
			{
				currentStatus = Status.LOADING;
			}
			else 
			{
				currentStatus = Status.MENU;
				if(GameObject.Find ("Screen First Loading"))
					MonoBehaviour.Destroy (GameObject.Find ("Screen First Loading"));
			}
		}
		
		private AppCore () {}
		
		public static void Load()
		{
			switch (currentStatus) 
			{
			case Status.FAST_GAME:
				Application.LoadLevel(1);
				break;			
			case Status.EXIT:
				Application.Quit();
				break;
			}
		}
		
		public static void BackToMenu()
		{
			isStart = false;
			Application.LoadLevel(0);
		}

		public static void BackButtonPress()
		{
			goMaps = GameObject.Find ("Screen Maps");
			goMain = GameObject.Find ("Screen Main Menu");
			goScores = GameObject.Find ("Screen Scores");
			goMeteorLevel = GameObject.Find ("Screen Levels Meteor");
			goIceLevel = GameObject.Find ("Screen Levels Ice");
			goSunLevel = GameObject.Find ("Screen Levels Sun");
			goDownLevel = GameObject.Find ("Screen Levels Down");
			if((goMain.rigidbody.position.x <= 3 && goMain.rigidbody.position.x >= -3)
			   || (goMaps.rigidbody.position.x <= 3 && goMaps.rigidbody.position.x >= -3)
			   || (goScores.rigidbody.position.x <= 3 && goScores.rigidbody.position.x >= -3)
			   || (goIceLevel.rigidbody.position.x <= 3 && goIceLevel.rigidbody.position.x >= -3)			   
			   || (goDownLevel.rigidbody.position.x <= 3 && goDownLevel.rigidbody.position.x >= -3)			   
			   || (goMeteorLevel.rigidbody.position.x <= 3 && goMeteorLevel.rigidbody.position.x >= -3)
			   || (goSunLevel.rigidbody.position.x <= 3 && goSunLevel.rigidbody.position.x >= -3))
			{					
					switch (currentStatus)
					{
					case Status.MAPS:				
					case Status.SCORES:
					case Status.LOADING:				
						currentStatus = Status.MENU;
						break;
					case Status.LEVELS_METEOR:
					case Status.LEVELS_ICE:
					case Status.LEVELS_SUN:
					case Status.LEVELS_DOWN:
						currentStatus = Status.MAPS;
						break;
					case Status.MENU:
						Application.Quit();
						break;
			}
			}
		}
	}
}

