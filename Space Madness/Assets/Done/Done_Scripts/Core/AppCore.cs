using System;
using UnityEngine;
using System.Collections;

namespace AssemblyCSharp
{
	public class AppCore
	{
        public enum Status { LOADING, MENU, FAST_GAME, MAPS, LEVELS, SCORES, EXIT, LEVELS_METEOR, LEVELS_ICE, LEVELS_SUN, LEVELS_DOWN, FAST_GAME_PAUSE, RESTART_FAST_GAME, ANY_LEVEL, ANY_LEVEL_PAUSE, RESTART_ANY_LEVEL, FAST_GAME_OVER, ANY_LEVEL_COMPLETE, ANY_LEVEL_FAILED };
		
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

        private static Vector3 V3_LEFT = new Vector3(-14f, 0.0f, 0.0f);
        private static Vector3 V3_RIGHT = new Vector3(14f, 0.0f, 0.0f);

        private static Status currentStatus;

        public static Status CurrentStatus
        {
            get { return AppCore.currentStatus; }
            set { AppCore.currentStatus = value; }
        }

        public static bool IsSlowMotion { get; set; }
        public static bool IsFastMotion { get; set; }
        public static bool IsGodMod { get; set; }
        

		public static void Start () {
			if (isStart) 
			{
				currentStatus = Status.LOADING;
			}
			else 
			{
                if (GameObject.Find("Screen First Loading"))
                {
                    MonoBehaviour.Destroy(GameObject.Find("Screen First Loading"));                    
                }
                if (currentStatus != Status.SCORES && currentStatus != Status.LEVELS_METEOR && currentStatus != Status.LEVELS_SUN && currentStatus != Status.LEVELS_ICE && currentStatus != Status.LEVELS_DOWN)
                    currentStatus = Status.MENU;
                else
                {
                    GameObject.Find("Screen Main Menu").transform.position = V3_LEFT;
                    GameObject.Find("Screen Maps").transform.position = V3_LEFT;
                }
                switch (currentStatus)
                {
                    case Status.SCORES:
                        GameObject.Find("Screen Main Menu").transform.position = V3_LEFT;
                        GameObject.Find("Screen Maps").transform.position = V3_RIGHT;
                        GameObject.Find("Screen Levels Meteor").transform.position = V3_RIGHT;
                        GameObject.Find("Screen Levels Ice").transform.position = V3_RIGHT;
                        GameObject.Find("Screen Levels Sun").transform.position = V3_RIGHT;
                        GameObject.Find("Screen Levels Down").transform.position = V3_RIGHT;
                        break;
                }
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
            case Status.ANY_LEVEL:
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

