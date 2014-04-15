using UnityEngine;
using System.Collections;
using AssemblyCSharp;

public class StartCountdown : MonoBehaviour
{
    private GameObject number1;
    private GameObject number2;
    private GameObject number3;
    private GameObject wordGo;
    private float timeScale = 0.0f;
    private float speed  = 4f;

    private Vector3 V3_LEFT = new Vector3(-10f, 6.0f, 6.0f);
    private Vector3 V3_RIGHT = new Vector3(10f, 6.0f, 6.0f);
    private Vector3 V3_CENTER = new Vector3(0, 6.0f, 6.0f);
    private Vector3 V3_DELTA = new Vector3(0.2f, 0.0f, 0.0f);

    private bool is1Shown = false;
    private bool is2Shown = false;
    private bool is3Shown = false;
    private bool isGoShown = false;

    void Start()
    {
        StopGame();
        number1 = GameObject.Find("Number 1");
        number2 = GameObject.Find("Number 2");
        number3 = GameObject.Find("Number 3");
        wordGo = GameObject.Find("Word Go");
        is1Shown = false;
        is2Shown = false;
        is3Shown = false;
        isGoShown = false;

	}

    private void moveAndStopStopAtPosition(GameObject go, Vector3 expectedPosition)
    {
        go.rigidbody.velocity = Vector3.zero;
        go.rigidbody.transform.position = Vector3.Lerp(go.transform.position, expectedPosition, Time.fixedDeltaTime * speed);
        if (go.rigidbody.position.x >= (expectedPosition.x - V3_DELTA.x) && go.rigidbody.position.x <= (expectedPosition.x + V3_DELTA.x))
        {           
            go.rigidbody.velocity = Vector3.zero;
            if (go == number1)
                is1Shown = true;  
            if (go == number2)
                is2Shown = true;  
            if (go == number3)           
                is3Shown = true; 
            if (go == wordGo)
                isGoShown = true;
        }
    }

    void Update()
    {
        if (GameCore.isShowStartCountDown && GameCore.timeScale!=0.0f)
        {
            GameCore.isShowStartCountDown = false; 
            is1Shown = false;
            is2Shown = false;
            is3Shown = false;
            isGoShown = false;            
            timeScale = GameCore.timeScale;
        }
        if (timeScale != 0.0f)
        {
            if (!is3Shown)
            {
                moveAndStopStopAtPosition(number3, V3_CENTER);                
            }
            if (is3Shown)
            {
                moveAndStopStopAtPosition(number3, V3_RIGHT);
                if (!is2Shown)
                    moveAndStopStopAtPosition(number2, V3_CENTER);
            }
            if (is2Shown)
            {
                moveAndStopStopAtPosition(number2, V3_RIGHT);
                if (!is1Shown)
                    moveAndStopStopAtPosition(number1, V3_CENTER);
            }
            if (is1Shown)
            {
                moveAndStopStopAtPosition(number1, V3_RIGHT);
                if (!isGoShown)
                    moveAndStopStopAtPosition(wordGo, V3_CENTER);
            }
            if (isGoShown)
            {
                moveAndStopStopAtPosition(wordGo, V3_RIGHT);
            }
            if (wordGo.rigidbody.position.x > 9.7f)
            {
                number1.rigidbody.position = V3_LEFT;
                number2.rigidbody.position = V3_LEFT;
                number3.rigidbody.position = V3_LEFT;
                wordGo.rigidbody.position = V3_LEFT;                
                ResumeGame();
            }
        }        
    }
	
    private void StopGame()
    {
        if (timeScale == 0.0f)
            timeScale = Time.timeScale;
        Time.timeScale = 0.0f;
    }

    private void ResumeGame()
    {        
        GameCore.timeScale = 0.0f;
        if (Time.timeScale == 0.0f)
            Time.timeScale = timeScale;
        timeScale = 0.0f;
    }
}
