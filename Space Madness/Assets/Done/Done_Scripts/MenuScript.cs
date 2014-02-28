using UnityEngine;
using System.Collections;

public class MenuScript : MonoBehaviour {	
	public GameObject mainLoadObject;
	public GameObject mainMenuObject;
	private enum Status {LOADING, MENU, FAST_GAME, EXIT};
	private Status currentStatus;
	private static bool isStart = true;

	void UnlockGame()		
	{
	}
	
	void LockGame()		
	{
	}

	void Start () {
		if (isStart) 
		{
			currentStatus = Status.LOADING;
		}
		else 
		{
			currentStatus = Status.MENU;
			Load();
		}
	}
	
	//а эта функция вызывается еще раньше чем Start (),	
	//здесь мы указываем, что меню уничтожать не надо,	
	//даже когда стартует следующая сцена.	
	//ведь мы будем еще вызывать его по нажатию Escape	
	void Awake ()		
	{
		DontDestroyOnLoad(this);		
	}

	private void Load()
	{
		switch (currentStatus) 
		{
		case Status.FAST_GAME:
			StartFastGame();
			break;
		case Status.MENU:
			ShowMainMenu();
			break;
		case Status.EXIT:
			ExitGame();
			break;
		case Status.LOADING:
			ShowLoadingScreen();
			break;
		}
	}

	void StartFastGame()
	{
		Application.LoadLevel(1);
	}

	void ShowMainMenu()
	{
		Destroy(mainLoadObject);		
		mainMenuObject.transform.position = new Vector3 (0.0f,0.0f,0.0f);
	}

	void ExitGame()
	{
		Application.Quit();
	}

	void ShowLoadingScreen()
	{

	}

	void Update()
	{
		LoadTouchEvents ();
		LoadBackButtonEvents ();
		LoadMouseEvents ();
	}

	void BackToMenu()
	{
		isStart = false;
		Application.LoadLevel(0);
	}

	private void LoadTouchEvents()
	{
		if (Input.touchCount > 0) {
			Ray ray = Camera.main.ScreenPointToRay (Input.GetTouch(0).position);
			RaycastHit hit;				
			if (Physics.Raycast (ray, out hit, 100)) {					
				if (hit.collider.tag == "FastGameStartButton") {
					currentStatus = Status.FAST_GAME;
					Load();
				}					
				if (hit.collider.tag == "ExitGameButton") {
					currentStatus = Status.EXIT;
					Load();
				}
				if(currentStatus == Status.LOADING)
				{
					currentStatus = Status.MENU;
					Load();
				}
			}
		}
	}

	private void LoadMouseEvents()
	{
		if (Input.GetMouseButton(0)) {
			Ray ray = Camera.main.ScreenPointToRay (Input.mousePosition);
			RaycastHit hit;				
			if (Physics.Raycast (ray, out hit, 100)) {					
				if (hit.collider.tag == "FastGameStartButton") {
					currentStatus = Status.FAST_GAME;
					Load();
				}					
				if (hit.collider.tag == "ExitGameButton") {
					currentStatus = Status.EXIT;
					Load();
				}
				if(currentStatus == Status.LOADING)
				{
					currentStatus = Status.MENU;
					Load();
				}
			}
		}
	}


	private void LoadBackButtonEvents()
	{
		if (Input.GetKeyDown(KeyCode.Escape))			
		{
			switch (currentStatus)
			{
			case Status.LOADING:
				currentStatus = Status.MENU;
				Load();
				break;
			case Status.MENU:
				currentStatus = Status.EXIT;
				Load();
				break;
			case Status.FAST_GAME:
				currentStatus = Status.MENU;
				BackToMenu();
				break;
			}
		}
	}
}