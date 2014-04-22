using UnityEngine;
using System.Collections;
using AssemblyCSharp;

public class GamePlayMenusController : MonoBehaviour {
	public GameObject scPauseMenuGO;
    public GameObject scFastGameOverMenuGO;
    public GameObject scFastGameOverTextGO;
    public GUIText gameOverUsernameTextField;
    public GUIText gameOverScoreTextField;
	private float speed;
	private Vector3 V3_LEFT = new Vector3 (-14f, 0.0f, 6.0f);
	private Vector3 V3_CENTER = new Vector3 (0.0f, 0.0f, 6.0f);
	private Vector3 V3_DELTA = new Vector3 (0.2f, 0.2f, 0.2f);
	private float timeScale = 0.0f;

    private Vector3 V3_TEXT_HIDEN = new Vector3(0f, 2f, 18f);
    private Vector3 V3_TEXT_APPEAR = new Vector3(0f, 2f, 6f);
    private Vector3 V3_TEXT_UP = new Vector3(0f, 2f, 12.5f);
    

    private Vector3 V3_MENU_HIDEN = new Vector3(14.0f, 0f, 6f);
    private Vector3 V3_MENU_CENTER = new Vector3(0.0f, 0f, 6f);

    private bool isMenuTextAppeared = false;
	
	void Start () {
		speed = 3f;
        gameOverUsernameTextField.text = " ";
        gameOverScoreTextField.text = " ";
	}

    private void HideText()
    {
        if (gameOverUsernameTextField != null && gameOverUsernameTextField.text != "")
            gameOverUsernameTextField.text = " ";
        if (gameOverScoreTextField != null && gameOverScoreTextField.text != "")
            gameOverScoreTextField.text = " ";
    }
	
	private void MoveAndStopStopAtPosition(GameObject go, Vector3 expectedPosition)
	{
		go.rigidbody.velocity = Vector3.zero;
		go.rigidbody.transform.position = Vector3.Lerp(go.transform.position,expectedPosition, Time.fixedDeltaTime * speed);
		if(go.rigidbody.position.x >=(expectedPosition.x-V3_DELTA.x) && go.rigidbody.position.x <=(expectedPosition.x+V3_DELTA.x))
        {
			go.rigidbody.velocity = Vector3.zero;
        }

        if (go.name == scFastGameOverTextGO.name)
            if(go.rigidbody.position.z >=(expectedPosition.z-V3_DELTA.z) && go.rigidbody.position.z <=(expectedPosition.z+V3_DELTA.z))
            {               
                isMenuTextAppeared = true;
            }
        
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
		switch(AppCore.CurrentStatus)
		{
		case AppCore.Status.FAST_GAME_PAUSE:
        case AppCore.Status.ANY_LEVEL_PAUSE:
			StopGame();
			MoveAndStopStopAtPosition(scPauseMenuGO,V3_CENTER);
			break;
		case AppCore.Status.MENU:
			MoveAndStopStopAtPosition(scPauseMenuGO,V3_LEFT);
            MoveAndStopStopAtPosition(scFastGameOverMenuGO, V3_MENU_HIDEN);
            MoveAndStopStopAtPosition(scFastGameOverTextGO, V3_TEXT_HIDEN);
            HideText();
            if (scPauseMenuGO.transform.position.x <= -12 && scFastGameOverMenuGO.transform.position.x >=12)
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
            HideText();
			MoveAndStopStopAtPosition(scPauseMenuGO,V3_LEFT);
            MoveAndStopStopAtPosition(scFastGameOverMenuGO, V3_MENU_HIDEN);
            MoveAndStopStopAtPosition(scFastGameOverTextGO, V3_TEXT_HIDEN);
			if(scPauseMenuGO.transform.position.x <= -12 && scFastGameOverMenuGO.transform.position.x >=12)
			{
				ResumeGame();
				AppCore.CurrentStatus = AppCore.Status.FAST_GAME;
				Application.LoadLevel(1);
			}
			break;
        case AppCore.Status.RESTART_ANY_LEVEL:
            MoveAndStopStopAtPosition(scPauseMenuGO, V3_LEFT);
            if (scPauseMenuGO.transform.position.x <= -12)
            {
                ResumeGame();
                AppCore.CurrentStatus = AppCore.Status.ANY_LEVEL;
                Application.LoadLevel(1);
            }
            break;
        case AppCore.Status.FAST_GAME:
            HideText();
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
            if (!isMenuTextAppeared) speed = 1.5f;
            else speed = 3f;
            MoveAndStopStopAtPosition(scFastGameOverTextGO, V3_TEXT_UP);
            if (isMenuTextAppeared)
            {
                MoveAndStopStopAtPosition(scFastGameOverMenuGO, V3_CENTER);
                if (scFastGameOverMenuGO.rigidbody.velocity == Vector3.zero && scFastGameOverMenuGO.transform.position.x >= -0.2f && scFastGameOverMenuGO.transform.position.x<=0.2f)
                {
                    gameOverScoreTextField.text = "5000";
                    gameOverUsernameTextField.text = "eldar";
                }
            }
            break;
		}
	}
}
