using System;
using UnityEngine;
using System.Text;

namespace AssemblyCSharp
{
    public enum Maps { MeteorRain, IceAnomaly, DownFall, SunStorm, Unknown }
    public enum WeaponType { Default, Rocket, Laser, Plasma, Acid }

	public static class GameCore
	{
        public static WeaponType CurrentWeaponType;
        public static float WeaponStartTime;

        public static Maps mapType;
        public static String levelName;

        private static GameParameters gameParameters;

        public static bool isShowStartCountDown = false;
        private static float timeScale = 0.0f;

        public static int Score { get; set; }

        private static int countForMultiplicator;
        public static int CountForMultiplicator
        {
            get { return GameCore.countForMultiplicator; }
            set { GameCore.countForMultiplicator = value; }
        }

        private static int multiplicator;

        public static int Multiplicator
        {
            get { return GameCore.multiplicator; }
            set { GameCore.multiplicator = value; }
        }

        public static void StopGame()
        {
            if(Time.timeScale !=0.0f)
            {
                timeScale = Time.timeScale;
                Time.timeScale = 0.0f;
            }
        }

        public static void ResumeGame()
        {
            if (Time.timeScale == 0.0f)
            {
                Time.timeScale = timeScale;
                timeScale = 0.0f;
            }
        }

        public static GameParameters GameParameters
        {
            get { return gameParameters; }
            set { gameParameters = value; }
        }
        private static GameTask gameTask;

        public static GameTask GameTask
        {
            get { return gameTask; }
            set { gameTask = value; }
        }

        public static void Initialize(String levelButtonName)
        {
            levelName = levelButtonName;
            InitializeGameParamters(levelButtonName);
        }

        private static void InitializeGameParamters(String levelButtonName)
        {
            switch (levelButtonName)
            {
                case "Meteor Level 1":
                    mapType = Maps.MeteorRain;
                    gameParameters = new GameParameters();
                    gameParameters.Acceleration = 1;

                    gameTask = new GameTask();
                    gameTask.CountEnemiesToDestroy = 5;
                    gameTask.CountMeteorsToDestroy = 10;
                    gameTask.SurviveTime = 0;
                    break;
                case "Meteor Level 2":
                    mapType = Maps.MeteorRain;
                    gameParameters = new GameParameters();
                    gameParameters.Acceleration = 1.25f;

                    gameTask = new GameTask();
                    gameTask.CountEnemiesToDestroy = 6;
                    gameTask.CountMeteorsToDestroy = 12;
                    gameTask.SurviveTime = 0;
                    break;
                case "Meteor Level 3":
                    mapType = Maps.MeteorRain;
                    gameParameters = new GameParameters();
                    gameParameters.Acceleration = 1.5f;

                    gameTask = new GameTask();
                    gameTask.CountEnemiesToDestroy = 7;
                    gameTask.CountMeteorsToDestroy = 14;
                    gameTask.SurviveTime = 0;
                    break;
                case "Meteor Level 4":
                    mapType = Maps.MeteorRain;
                    gameParameters = new GameParameters();
                    gameParameters.Acceleration = 1.75f;

                    gameTask = new GameTask();
                    gameTask.CountEnemiesToDestroy = 8;
                    gameTask.CountMeteorsToDestroy = 16;
                    gameTask.SurviveTime = 0;
                    break;
                case "Meteor Level 5":
                    mapType = Maps.MeteorRain;
                    gameParameters = new GameParameters();
                    gameParameters.Acceleration = 2f;

                    gameTask = new GameTask();
                    gameTask.CountEnemiesToDestroy = 9;
                    gameTask.CountMeteorsToDestroy = 18;
                    gameTask.SurviveTime = 0;
                    break;
                case "Meteor Level 6":
                    mapType = Maps.MeteorRain;
                    gameParameters = new GameParameters();
                    gameParameters.Acceleration = 2.25f;

                    gameTask = new GameTask();
                    gameTask.CountEnemiesToDestroy = 10;
                    gameTask.CountMeteorsToDestroy = 20;
                    gameTask.SurviveTime = 0;
                    break;
                case "Meteor Level 7":
                    mapType = Maps.MeteorRain;
                    gameParameters = new GameParameters();
                    gameParameters.Acceleration = 2.5f;

                    gameTask = new GameTask();
                    gameTask.CountEnemiesToDestroy = 12;
                    gameTask.CountMeteorsToDestroy = 22;
                    gameTask.SurviveTime = 0;
                    break;
                case "Meteor Level 8":
                    mapType = Maps.MeteorRain;
                    gameParameters = new GameParameters();
                    gameParameters.Acceleration = 2.75f;

                    gameTask = new GameTask();
                    gameTask.CountEnemiesToDestroy = 12;
                    gameTask.CountMeteorsToDestroy = 22;
                    gameTask.SurviveTime = 0;
                    break;
                case "Ice Level 1":
                    mapType = Maps.IceAnomaly;
                    gameParameters = new GameParameters();
                    gameParameters.Acceleration = 1;

                    gameTask = new GameTask();
                    gameTask.CountEnemiesToDestroy = 5;
                    gameTask.CountMeteorsToDestroy = 10;
                    gameTask.SurviveTime = 0;
                    break;
                case "Ice Level 2":
                    mapType = Maps.IceAnomaly;
                    gameParameters = new GameParameters();
                    gameParameters.Acceleration = 1.25f;

                    gameTask = new GameTask();
                    gameTask.CountEnemiesToDestroy = 6;
                    gameTask.CountMeteorsToDestroy = 12;
                    gameTask.SurviveTime = 0;
                    break;
                case "Ice Level 3":
                    mapType = Maps.IceAnomaly;
                    gameParameters = new GameParameters();
                    gameParameters.Acceleration = 1.5f;

                    gameTask = new GameTask();
                    gameTask.CountEnemiesToDestroy = 7;
                    gameTask.CountMeteorsToDestroy = 14;
                    gameTask.SurviveTime = 0;
                    break;
                case "Ice Level 4":
                    mapType = Maps.IceAnomaly;
                    gameParameters = new GameParameters();
                    gameParameters.Acceleration = 1.75f;

                    gameTask = new GameTask();
                    gameTask.CountEnemiesToDestroy = 8;
                    gameTask.CountMeteorsToDestroy = 16;
                    gameTask.SurviveTime = 0;
                    break;
                case "Ice Level 5":
                    mapType = Maps.IceAnomaly;
                    gameParameters = new GameParameters();
                    gameParameters.Acceleration = 2f;

                    gameTask = new GameTask();
                    gameTask.CountEnemiesToDestroy = 9;
                    gameTask.CountMeteorsToDestroy = 18;
                    gameTask.SurviveTime = 0;
                    break;
                case "Ice Level 6":
                    mapType = Maps.IceAnomaly;
                    gameParameters = new GameParameters();
                    gameParameters.Acceleration = 2.5f;

                    gameTask = new GameTask();
                    gameTask.CountEnemiesToDestroy = 10;
                    gameTask.CountMeteorsToDestroy = 20;
                    gameTask.SurviveTime = 0;
                    break;
                case "Ice Level 15":
                    mapType = Maps.IceAnomaly;
                    gameParameters = new GameParameters();
                    gameParameters.Acceleration = 15f;
                    gameTask = new GameTask();
                    gameTask.CountEnemiesToDestroy = 10;
                    gameTask.CountMeteorsToDestroy = 20;
                    gameTask.SurviveTime = 0;
                    break;
                default:
                    if(levelButtonName.Contains("Meteor Level"))
                        mapType = Maps.MeteorRain;
                    else if (levelButtonName.Contains("Ice Level"))
                        mapType = Maps.IceAnomaly;
                    else if (levelButtonName.Contains("Sun Level"))
                        mapType = Maps.SunStorm;
                    else if (levelButtonName.Contains("Down Level"))
                        mapType = Maps.DownFall;
                    gameParameters = new GameParameters();
                    gameTask = new GameTask();
                    break;
            }
                 
        }
	}

    public class GameParameters
    {
        private float acceleration;

        public float Acceleration
        {
            get { return acceleration; }
            set { acceleration = value; }
        }   
                
        public GameParameters()
        {
            this.acceleration = 1.0f;
        }
    }

    public class GameTask
    {
        private int countMeteorsToDestroy;

        public int CountMeteorsToDestroy
        {
            get { return countMeteorsToDestroy; }
            set { countMeteorsToDestroy = value; }
        }
        private int countEnemiesToDestroy;

        public int CountEnemiesToDestroy
        {
            get { return countEnemiesToDestroy; }
            set { countEnemiesToDestroy = value; }
        }
        private int surviveTime;

        public int SurviveTime
        {
            get { return surviveTime; }
            set { surviveTime = value; }
        }

        public GameTask()
        {
            countMeteorsToDestroy = 0;
            countEnemiesToDestroy = 0;
            surviveTime = 0;
        }
    }

    [System.Serializable]
    public class Weapon
    {
        public string Name;
        public GameObject Bolt;
        public float PeriodBetweenShots;
    }
}
