using System;
using UnityEngine;
using System.Text;

namespace AssemblyCSharp
{
    public enum Maps { MeteorRain, IceAnomaly, DownFall, SunStorm, Unknown }

	public static class GameCore
	{
        public static Maps mapType;

        private static GameParameters gameParameters;

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
                    mapType = Maps.MeteorRain;
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
}
