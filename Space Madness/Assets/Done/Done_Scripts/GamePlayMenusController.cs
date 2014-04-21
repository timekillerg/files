using UnityEngine;
using System.Collections;
using AssemblyCSharp;

public class GamePlayMenusController : MonoBehaviour {
	public GameObject scPauseMenuGO;
    public GameObject scFastGameOverGO;
	private float speed;
	private Vector3 V3_LEFT = new Vector3 (-14f, 0.0f, 6.0f);
	private Vector3 V3_CENTER = new Vector3 (0.0f, 0.0f, 6.0f);
	private Vector3 V3_DELTA = new Vector3 (0.2f, 0.2f, 0.2f);
	private float timeScale = 0.0f;
	
	void Start () {
		speed = 3.2f;
	}
	
	private void MoveAndStopStopAtPosition(GameObject go, Vector3 expectedPosition)
	{
		go.rigidbody.velocity = Vector3.zero;
		go.rigidbody.transform.position = Vector3.Lerp(go.transform.position,expectedPosition, Time.fixedDeltaTime * speed);
		if(go.rigidbody.position.x >=(expectedPosition.x-V3_DELTA.x) && go.rigidbody.position.x <=(expectedPosition.x+V3_DELTA.x))
			go.rigidbody.velocity = Vector3.zero;
	}

	private void StopGame()
	{
		if (timeScale ==0.0f)
			timeScale = Time.timeScale;
		Time.timeScale = 0.0f;
	}

	private void ResumeGame()
	{
		if(Time.timeScale == 0.0f)
			Time.timeScale = timeScale;
		timeScale = 0.0f;
	}
	
	void Update()
	{
		switch(AppCore.GetCurrentStatus())
		{
		case AppCore.Status.FAST_GAME_PAUSE:
        case AppCore.Status.ANY_LEVEL_PAUSE:
			StopGame();
			MoveAndStopStopAtPosition(scPauseMenuGO,V3_CENTER);
			break;
		case AppCore.Status.MENU:           
			MoveAndStopStopAtPosition(scPauseMenuGO,V3_LEFT);
			if(scPauseMenuGO.transform.position.x <= -12)
			{
				ResumeGame();
				AppCore.BackToMenu();
			}
			break;
        case AppCore.Status.LEVELS_DOWN:
        case AppCore.Status.LEVELS_ICE:
        case AppCore.Status.LEVELS_METEOR:
        case AppCore.Status.LEVELS_SUN:
            MoveAndStopStopAtPosition(scPauseMenuGO, V3_LEFT);
            if (scPauseMenuGO.transform.position.x <= -12)
            {
                ResumeGame();
                AppCore.BackToMenu();
            }
            break;
		case AppCore.Status.RESTART_FAST_GAME:            
			MoveAndStopStopAtPosition(scPauseMenuGO,V3_LEFT);
			if(scPauseMenuGO.transform.position.x <= -12)
			{
				ResumeGame();
				AppCore.SetStatus(AppCore.Status.FAST_GAME);
				Application.LoadLevel(1);
			}
			break;
        case AppCore.Status.RESTART_ANY_LEVEL:
            MoveAndStopStopAtPosition(scPauseMenuGO, V3_LEFT);
            if (scPauseMenuGO.transform.position.x <= -12)
            {
                ResumeGame();
                AppCore.SetStatus(AppCore.Status.ANY_LEVEL);
                Application.LoadLevel(1);
            }
            break;
        case AppCore.Status.FAST_GAME:
            if (GameCore.isShowStartCountDown)
            {
                MoveAndStopStopAtPosition(scPauseMenuGO, V3_LEFT);
                if (scPauseMenuGO.transform.position.x <= -12)
                {
                    GameCore.timeScale = timeScale;
                }
            }
            break;
        case AppCore.Status.ANY_LEVEL:
            if (GameCore.isShowStartCountDown)
            {
                MoveAndStopStopAtPosition(scPauseMenuGO, V3_LEFT);
                if (scPauseMenuGO.transform.position.x <= -12)
                {
                    GameCore.timeScale = timeScale;
                }
            }
            break;
         case AppCore.Status.FAST_GAME_OVER:
            //StopGame();
            speed = 2f;
            MoveAndStopStopAtPosition(scFastGameOverGO, V3_CENTER);
            break;
		}
	}
}
