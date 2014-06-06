using UnityEngine;
using System.Collections;
using AssemblyCSharp;

public class ScoreScreenController : MonoBehaviour {
    public GameObject text;
    public GameObject text_devider;
    private bool isScoreLoaded = false;
    	
	void Update () {
        if (AppCore.CurrentStatus == AppCore.Status.SCORES)
        {
            if (!isScoreLoaded && GameObject.Find("Screen Main Menu").transform.position.x < -10 && GameObject.Find("Screen Scores").transform.position.x <2)
            {
                isScoreLoaded = true;
                for (int i = DataCore.GetScores().Count; i > 0; i--)
                {
                    if (DataCore.GetScores()[i - 1].Username != "noname")
                    {
                        GameObject numberObject;
                        numberObject = Instantiate(text) as GameObject;
                        numberObject.name = "ScoreRecordObject";
                        numberObject.transform.position = new Vector3(0.025f, 0.9f - (DataCore.GetScores().Count - i) * 0.03f, 0);
                        numberObject.guiText.text = (DataCore.GetScores().Count - i + 1).ToString() + ". ";

                        GameObject usernameObject;
                        usernameObject = Instantiate(text) as GameObject;
                        usernameObject.name = "ScoreRecordObject";
                        usernameObject.transform.position = new Vector3(0.125f, 0.9f - (DataCore.GetScores().Count - i) * 0.03f, 0);
                        usernameObject.guiText.text = DataCore.GetScores()[i - 1].Username;

                        GameObject scoreValueObject;
                        scoreValueObject = Instantiate(text) as GameObject;
                        scoreValueObject.name = "ScoreRecordObject";
                        scoreValueObject.transform.position = new Vector3(0.7f, 0.9f - (DataCore.GetScores().Count - i) * 0.03f, 0);
                        scoreValueObject.guiText.text = DataCore.GetScores()[i - 1].Score.ToString();

                        GameObject lineObject;
                        lineObject = Instantiate(text_devider) as GameObject;
                        lineObject.name = "ScoreRecordObject";
                        lineObject.transform.position = new Vector3(0.0f, 0.89f - (DataCore.GetScores().Count - i) * 0.03f, 0);
                        lineObject.guiText.text = "_______________________________________________________________________________________________";
                    }
                }
            }
        }
        else
        {
            isScoreLoaded = false;
            Destroy(GameObject.Find("ScoreRecordObject"));
            
        }	
	}
}
