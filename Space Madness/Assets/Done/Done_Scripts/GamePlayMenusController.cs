using UnityEngine;
using System.Collections;
using AssemblyCSharp;

public class GamePlayMenusController : MonoBehaviour {
    private GameObject scPauseMenuGO;
    private GameObject scFastGameOverMenuGO;
    private GameObject scLevelCompleteMenuGO;
    private GameObject scLevelFailedMenuGO;

    public GameObject scFastGameOverTextGO;
    public GameObject BigTextLevelCompleteGO;
    public GameObject BigTextLevelFailedGO;

    public GUIText gameOverUsernameTextField;
    public GUIText gameOverScoreTextField;
    public GUIText scoreText;
	private float speed;
	private Vector3 V3_LEFT = new Vector3 (-14f, 0.0f, 6.0f);
	private Vector3 V3_CENTER = new Vector3 (0.0f, 0.0f, 6.0f);
	private Vector3 V3_DELTA = new Vector3 (0.2f, 0.2f, 0.2f);
    private Vector3 V3_TEXT_HIDEN = new Vector3(0f, 2f, 18f);
    private Vector3 V3_TEXT_UP = new Vector3(0f, 2f, 12f);
    private Vector3 V3_MENU_HIDEN = new Vector3(14.0f, 0f, 6f);

    private bool isScoreAlreadySaved = false;
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
        if (go != null)
        {
            go.rigidbody.velocity = Vector3.zero;
            go.rigidbody.transform.position = Vector3.Lerp(go.transform.position, expectedPosition, Time.fixedDeltaTime * speed);
            if (go.rigidbody.position.x >= (expectedPosition.x - V3_DELTA.x) && go.rigidbody.position.x <= (expectedPosition.x + V3_DELTA.x))
            {
                go.rigidbody.velocity = Vector3.zero;
            }

            if (go == scFastGameOverTextGO || go == BigTextLevelCompleteGO || go == BigTextLevelFailedGO)
                if (go.rigidbody.position.z >= (expectedPosition.z - V3_DELTA.z) && go.rigidbody.position.z <= (expectedPosition.z + V3_DELTA.z))
                {
                    isMenuTextAppeared = true;
                }
        }        
	}

    private void SaveScore()
    {
        if(gameOverScoreTextField.text != " ")
            if (!isScoreAlreadySaved && int.Parse(gameOverScoreTextField.text) > 5 && gameOverUsernameTextField.text.Length > 0)
            {
                DataCore.SaveScore(gameOverUsernameTextField.text, int.Parse(gameOverScoreTextField.text));
                isScoreAlreadySaved = true;
            }
    }

    private void InitializeMenuObject()
    {
        if (scFastGameOverMenuGO == null)
            scFastGameOverMenuGO = GameObject.FindGameObjectWithTag("Menu_GameOver_Buttons");
        if (scPauseMenuGO == null)
            scPauseMenuGO = GameObject.FindGameObjectWithTag("Menu_Pause_Buttons");
        if (scLevelCompleteMenuGO == null)
            scLevelCompleteMenuGO = GameObject.FindGameObjectWithTag("Menu_LevelComplete_Buttons");
        if (scLevelFailedMenuGO == null)
            scLevelFailedMenuGO = GameObject.FindGameObjectWithTag("Menu_LevelFailed_Buttons");
    }

	void Update()
	{
        InitializeMenuObject();

		switch(AppCore.CurrentStatus)
		{
		case AppCore.Status.FAST_GAME_PAUSE:
        case AppCore.Status.ANY_LEVEL_PAUSE:
			GameCore.StopGame();
            MoveAndStopStopAtPosition(scPauseMenuGO,V3_CENTER);
			break;
		case AppCore.Status.MENU:
            SaveScore();
            HideText();
			MoveAndStopStopAtPosition(scPauseMenuGO,V3_LEFT);
            MoveAndStopStopAtPosition(scFastGameOverMenuGO, V3_MENU_HIDEN);
            MoveAndStopStopAtPosition(scFastGameOverTextGO, V3_TEXT_HIDEN);
            if ((scPauseMenuGO != null && scPauseMenuGO.transform.position.x <= -12) || (scFastGameOverMenuGO!=null && scFastGameOverMenuGO.transform.position.x >= 12))
			{
                Destroy(scFastGameOverMenuGO);
                Destroy(scPauseMenuGO);
                GameCore.ResumeGame();
				AppCore.BackToMenu();
			}
			break;
        case AppCore.Status.SCORES:
            SaveScore();
            MoveAndStopStopAtPosition(scFastGameOverMenuGO, V3_MENU_HIDEN);
            MoveAndStopStopAtPosition(scFastGameOverTextGO, V3_TEXT_HIDEN);
            HideText();
            if (scFastGameOverMenuGO.transform.position.x >= 12)
            {
                Destroy(scFastGameOverMenuGO);
                Destroy(scPauseMenuGO);
                GameCore.ResumeGame();
                AppCore.BackToMenu();                
            }
            break;
        case AppCore.Status.LEVELS_DOWN:
        case AppCore.Status.LEVELS_ICE:
        case AppCore.Status.LEVELS_METEOR:
        case AppCore.Status.LEVELS_SUN:
            HideText();
            MoveAndStopStopAtPosition(scPauseMenuGO, V3_LEFT);   
            MoveAndStopStopAtPosition(scLevelCompleteMenuGO, V3_MENU_HIDEN);
            MoveAndStopStopAtPosition(scLevelFailedMenuGO, V3_MENU_HIDEN);
            MoveAndStopStopAtPosition(BigTextLevelCompleteGO, V3_TEXT_HIDEN);
            MoveAndStopStopAtPosition(BigTextLevelFailedGO, V3_TEXT_HIDEN);
            if ((scPauseMenuGO != null && scPauseMenuGO.transform.position.x <= -12) || (scLevelCompleteMenuGO != null && scLevelCompleteMenuGO.transform.position.x >= 12) || (scLevelFailedMenuGO != null && scLevelFailedMenuGO.transform.position.x >= 12))
            {
                Destroy(scPauseMenuGO);
                Destroy(scLevelCompleteMenuGO);
                Destroy(scLevelFailedMenuGO);
                GameCore.ResumeGame();
                AppCore.BackToMenu();
            }
            break;
		case AppCore.Status.RESTART_FAST_GAME:
            SaveScore();
            HideText();			
			MoveAndStopStopAtPosition(scPauseMenuGO,V3_LEFT);
            MoveAndStopStopAtPosition(scFastGameOverMenuGO, V3_MENU_HIDEN);
            MoveAndStopStopAtPosition(scFastGameOverTextGO, V3_TEXT_HIDEN);
            if ((scPauseMenuGO != null && scPauseMenuGO.transform.position.x <= -12) || (scFastGameOverMenuGO != null && scFastGameOverMenuGO.transform.position.x >= 12))
			{
                Destroy(scFastGameOverMenuGO);
                Destroy(scPauseMenuGO);
                GameCore.ResumeGame();
				AppCore.CurrentStatus = AppCore.Status.FAST_GAME;
				Application.LoadLevel(1);                
			}
			break;
        case AppCore.Status.RESTART_ANY_LEVEL:
            HideText();
            MoveAndStopStopAtPosition(scPauseMenuGO, V3_LEFT);
            MoveAndStopStopAtPosition(scLevelCompleteMenuGO, V3_MENU_HIDEN);
            MoveAndStopStopAtPosition(scLevelFailedMenuGO, V3_MENU_HIDEN);
            MoveAndStopStopAtPosition(BigTextLevelCompleteGO, V3_TEXT_HIDEN);
            MoveAndStopStopAtPosition(BigTextLevelFailedGO, V3_TEXT_HIDEN);
            if ((scPauseMenuGO != null && scPauseMenuGO.transform.position.x <= -12) || (scLevelCompleteMenuGO != null && scLevelCompleteMenuGO.transform.position.x >= 12) || (scLevelFailedMenuGO != null && scLevelFailedMenuGO.transform.position.x >= 12))
            {
                GameCore.ResumeGame();
                Destroy(scPauseMenuGO);
                Destroy(scLevelCompleteMenuGO);
                Destroy(scLevelFailedMenuGO);
                AppCore.CurrentStatus = AppCore.Status.ANY_LEVEL;
                Application.LoadLevel(1);
            }
            break;
        case AppCore.Status.FAST_GAME:
            HideText();           
            MoveAndStopStopAtPosition(scPauseMenuGO, V3_LEFT);
            if (scPauseMenuGO!= null && scPauseMenuGO.transform.position.x <= -12)
                Destroy(scPauseMenuGO);
            break;
        case AppCore.Status.ANY_LEVEL:
            HideText();
            MoveAndStopStopAtPosition(scPauseMenuGO, V3_LEFT);
            if (scPauseMenuGO!= null && scPauseMenuGO.transform.position.x <= -12)
                Destroy(scPauseMenuGO);            
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
                    gameOverScoreTextField.text = scoreText.text.Replace("Score: ", "");
                    gameOverUsernameTextField.text = DataCore.CurrentUsername;
                }
            }
            break;
         case AppCore.Status.ANY_LEVEL_COMPLETE:
            if (!isMenuTextAppeared) speed = 1.5f;
            else speed = 3f;
            MoveAndStopStopAtPosition(BigTextLevelCompleteGO, V3_TEXT_UP);
            if (isMenuTextAppeared)
            {
                MoveAndStopStopAtPosition(scLevelCompleteMenuGO, V3_CENTER);
                if (scLevelCompleteMenuGO.rigidbody.velocity == Vector3.zero && scLevelCompleteMenuGO.transform.position.x >= -0.2f && scLevelCompleteMenuGO.transform.position.x <= 0.2f)
                {
                    gameOverScoreTextField.text = scoreText.text.Replace("Score: ", "");
                }
            }
            break;
         case AppCore.Status.ANY_LEVEL_FAILED:
            if (!isMenuTextAppeared) speed = 1.5f;
            else speed = 3f;
            MoveAndStopStopAtPosition(BigTextLevelFailedGO, V3_TEXT_UP);
            if (isMenuTextAppeared)
            {
                MoveAndStopStopAtPosition(scLevelFailedMenuGO, V3_CENTER);
                if (scLevelFailedMenuGO.rigidbody.velocity == Vector3.zero && scLevelFailedMenuGO.transform.position.x >= -0.2f && scLevelFailedMenuGO.transform.position.x <= 0.2f)
                {
                    gameOverScoreTextField.text = scoreText.text.Replace("Score: ", "");
                }
            }
            break;
		}
	}
}
