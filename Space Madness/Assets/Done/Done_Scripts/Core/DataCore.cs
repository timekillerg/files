using System;
using UnityEngine;
using System.Text;
using System.Collections.Generic;

namespace AssemblyCSharp
{
    public class DataCore
    {
        private static String[] separator = new string[] { "[separator]" };
        private static string LEVEL_CODE = "!@#%%%^74380444hjhjgiwfg";
        private static int countOfScoreValues = 28;
        private static List<ScoreRecord> ScoreRecords;

        public static string CurrentUsername
        {
            get
            {
                if (!PlayerPrefs.HasKey("CurrentUsername"))
                {
                    PlayerPrefs.SetString("CurrentUsername", "me");
                    PlayerPrefs.Save();
                }
                return PlayerPrefs.GetString("CurrentUsername");
            }
            set
            {
                if (value.Length > 0)
                {
                    PlayerPrefs.SetString("CurrentUsername", value);
                    PlayerPrefs.Save();
                }
            }
        }

        public static int IsSoundOn
        {
            get
            {
                if (!PlayerPrefs.HasKey("IsSoundOn"))
                {
                    PlayerPrefs.SetInt("IsSoundOn", 1);
                    PlayerPrefs.Save();
                }
                return PlayerPrefs.GetInt("IsSoundOn");
            }
            set
            {
                PlayerPrefs.SetInt("IsSoundOn", value);
                PlayerPrefs.Save();
            }
        }

        private static void InitializeScoreTable()
        {
            for (int i = 0; i < countOfScoreValues; i++)
            {
                if (!PlayerPrefs.HasKey("ScoreValue" + i.ToString()))
                {                   
                    PlayerPrefs.SetString("ScoreValue" + i.ToString(), "noname"+separator[0]+"0");
                    PlayerPrefs.Save();
                }
            }
        }
        public static void SaveScore(string username, int score)
        {
            InitializeScoreTable();
            List<ScoreRecord> scores = new List<ScoreRecord>();
            scores = GetScores();
            scores.Add(new ScoreRecord(username, score));
            scores.Sort(delegate(ScoreRecord sc1, ScoreRecord sc2)
            {
                return sc1.Score.CompareTo(sc2.Score);
            });
            scores.RemoveAt(0);
            for (int i = 0; i < countOfScoreValues; i++)
            {
                PlayerPrefs.SetString("ScoreValue" + i.ToString(), scores[i].Username + separator[0].ToString() + scores[i].Score.ToString());
                PlayerPrefs.Save();
            }
            ScoreRecords = scores;
        }

        public static List<ScoreRecord> GetScores()
        {
            if (ScoreRecords == null || ScoreRecords.Count == 0)
            {
                ScoreRecords = new List<ScoreRecord>();
                for (int i = 0; i < countOfScoreValues; i++)
                {
                    string key = "ScoreValue" + i.ToString();
                    if (PlayerPrefs.HasKey(key))
                    {
                        string[] scoreRecordValuePair = PlayerPrefs.GetString(key).Split(separator, StringSplitOptions.RemoveEmptyEntries);

                        if (scoreRecordValuePair.Length != 2)
                        {
                            PlayerPrefs.SetString(key, "noname" + separator[0] + "0");
                            PlayerPrefs.Save();
                            scoreRecordValuePair = PlayerPrefs.GetString(key).Split(separator, StringSplitOptions.RemoveEmptyEntries);
                        }
                        ScoreRecords.Add(new ScoreRecord(scoreRecordValuePair[0], int.Parse(scoreRecordValuePair[1])));
                    }
                }
                ScoreRecords.Sort(delegate(ScoreRecord sc1, ScoreRecord sc2)
                {
                    return sc1.Score.CompareTo(sc2.Score);
                });
            }
            return ScoreRecords;
        }

        public static int GetLevelCountOfStars(string levelName)
        {
            if (PlayerPrefs.HasKey(LEVEL_CODE + levelName))
                return PlayerPrefs.GetInt(LEVEL_CODE + levelName);
            else
            {
                PlayerPrefs.SetInt(LEVEL_CODE + levelName, 0);
                PlayerPrefs.Save();
                return 0;
            }
        }

        public static void SetLevelCountOfStars(string levelName, int countOfStars)
        {
            if (PlayerPrefs.HasKey(LEVEL_CODE + levelName) && PlayerPrefs.GetInt(LEVEL_CODE + levelName) >= countOfStars)
                return;
            else
            {
                PlayerPrefs.SetInt(LEVEL_CODE + levelName, countOfStars);
                PlayerPrefs.Save();
            }
        }
    }

    public class ScoreRecord
    {
        private String username;
        public String Username
        {
            get { return username; }
            set { username = value; }
        }

        private int score;
        public int Score
        {
            get { return score; }
            set { score = value; }
        }

        public ScoreRecord(String _username, int _score)
        {
            Username = _username;
            Score = _score;
        }
    }
}
