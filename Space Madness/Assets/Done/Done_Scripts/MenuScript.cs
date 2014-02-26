using UnityEngine;

using System.Collections;



//объявляем класс Menu

//обратите внимание, имя класса обязательно совпадает

//с именем скрипта

public class MenuScript : MonoBehaviour {
	
	public GameObject SplashPlane; //эти параметры будут доступны в юнити
	
	public GameObject MenuPlane;   //сюда мы присвоим наши плэйны	
	
	
	//далее идут константы состояний
	
	//программа должна знать, в каком состоянии она находится,
	
	//заставка это, меню или игра уже началась.
	
	private const int ST_SPLASH = 0;
	
	private const int ST_MAINMENU = 1;
	
	private const int ST_QUIT = 2;
	
	private const int ST_GAME = 3;
	
	
	
	
	
	//а это состояния меню-
	
	//главное меню, опции или «об игре»
	
	private const int MP_NONE = 0;
	
	private const int MP_MAIN = 1;
	
	private const int MP_OPTIONS = 2;
	
	private const int MP_ABOUT = 3;
	
	
	
	
	
	//а вот и переменные, которые будут хранить
	
	//в себе состояния игры и меню.
	
	private int appState;
	
	private int menuPage;
	
	
	
	//эта переменная нужна, чтобы определить,
	
	//это первый старт меню, или же оно вызвано из игры.
	
	//а нужно это для того, чтобы корректно отображать кнопки
	
	//«старт» и «продолжить».
	
	private bool _firstRun = true;
	
	
	
	
	
	//функции-заглушки.
	
	//позже мы их заполним, когда в игре появятся объекты,
	
	//нуждающиеся в блокировке на время паузы.
	
	void UnlockGame()
		
	{ 
		
	}
	
	void LockGame()
		
	{  
		
	}
	
	
	
	
	
	//эта функция вызывается во время запуска сцены
	
	//установим состояние игры – Сплэш-заставка,
	
	//и пустую страницу меню.
	
	void Start () {
		
		appState = ST_SPLASH;
		
		menuPage = MP_NONE;
		
	}
	
	
	
	//а эта функция вызывается еще раньше чем Start (),
	
	//здесь мы указываем, что меню уничтожать не надо,
	
	//даже когда стартует следующая сцена.
	
	//ведь мы будем еще вызывать его по нажатию Escape
	
	void Awake ()
		
	{
		
		DontDestroyOnLoad(this);
		
	}
	
	
	
	
	
	//следующая функция будет вызываться каждый кадр.
	
	//здесь мы отлавливаем нажатие клавиши Escape,
	
	//и в зависимости от текущего состояния устанавливаем другое
	
	//состояние.

	void FixedUpdate()
	{
		if (Input.touchCount > 0) {
			Ray ray = Camera.main.ScreenPointToRay (Input.GetTouch(0).position);
			RaycastHit hit;				
			if (Physics.Raycast (ray, out hit, 100)) {					
				if (hit.collider.tag == "FastGameStartButton") {
					appState = ST_GAME;					
					menuPage = MP_NONE;
					OnGUI();
				}					
				if (hit.collider.tag == "ExitGameButton") {
					appState = ST_QUIT;					
					menuPage = MP_NONE;
					OnGUI();
				}
				if(appState == ST_SPLASH)
				{
					appState = ST_MAINMENU;					
					menuPage = MP_MAIN;
					OnGUI();
				}
			}
		}
	}
	
	void Update () {
		
		if (Input.GetKeyDown(KeyCode.Escape))
			
		{			
			switch (appState)
				
			{
				
			case ST_SPLASH:
				
				appState = ST_MAINMENU;
				
				menuPage = MP_MAIN;
				
				break;
				
			case ST_MAINMENU:
				
				switch (menuPage)
					
				{
					
				case MP_MAIN:
					
					
					
					if (_firstRun)
						
					{
						
						appState = ST_MAINMENU;
						
						menuPage = MP_MAIN;
						appState = ST_QUIT;
						OnGUI();
					}
					
					else
						
					{
						
						appState = ST_GAME;
						
						menuPage = MP_NONE;
						
						UnlockGame();
						
					}
					
					break;
					
				case MP_OPTIONS:
					
					menuPage = MP_MAIN;
					
					break;
					
				case MP_ABOUT:
					
					menuPage = MP_MAIN;
					
					break;
					
				}
				
				break;
				
			case ST_GAME:
				Application.LoadLevel(0);
				_firstRun = true;
				appState = ST_MAINMENU;					
				menuPage = MP_MAIN;
				OnGUI();
				
				break;
				
			}
			
			
			
		}
		
	}
	
	
	
	
	
	//эта функция будет вызываться при отрисовке ГУИ.
	
	//тоже проверяется текущее состояние и в зависимости от него
	
	//вызывается соответствующая функция отрисовки
	
	void OnGUI()		
	{
		
		switch (appState)			
		{			
		case ST_SPLASH:			
			//рисуем сплэш			
			DrawSplashGUI();			
			break;			
		case ST_MAINMENU:			
			switch (menuPage)				
			{				
			case MP_MAIN:				
				//рисуем главную страницу меню
				
				DrawMainMenuPage();
				
				break;
				
			case MP_OPTIONS:
				
				
				
				//рисуем страницу меню «настройки»
				
				DrawOptionsMenuPage();
				
				break;
				
			case MP_ABOUT:
				
				
				
				//рисуем страницу меню «об игре»
				
				DrawAboutMenuPage();
				
				break;
				
			}
			
			
			

			
			
			break;
			
		case ST_QUIT:
			
			
			
			//выходим из игры
			
			AppQuit();
			
			break;
			
			
			
		case ST_GAME:
			
			
			
			if (_firstRun)
				
			{
				
				//загружаем сцену под номером 1
				
				Application.LoadLevel(1);
				
				_firstRun = false;
				
			}
			
			else
				
			{
				
			}
			
			break;
			
		}
		
	}
	
	
	
	void DrawSplashGUI()		
	{		
		//далее идет отрисовка надписи стандартной функцией Юнити

	}

	//рисуем главную страницу меню:
	
	void DrawMainMenuPage()		
	{		
		if (_firstRun){
			
			Destroy(SplashPlane);
			
			Vector3 dir;
			
			dir.x = 0;
			
			dir.y = 0;
			
			dir.z = 0;
			
			MenuPlane.transform.position = dir;
			
		}
		
		int _buttonHeight = 30;
		
		int _buttonWidth = 150;
		
		int _space = 5;
		
		
		
		int _left = -4000; //was 40
		
		int _top = -4000; 
		
		
		
		Rect _posNew = new Rect(_left, _top, _buttonWidth, _buttonHeight);
		
		Rect _posOptions = new Rect(_left, _top + _buttonHeight + _space, _buttonWidth, _buttonHeight);
		
		Rect _posAbout = new Rect(_left, _top + (_buttonHeight * 2) + _space * 2, _buttonWidth, _buttonHeight);
		
		Rect _posQuit = new Rect(_left, _top + (_buttonHeight * 3) + _space * 3, _buttonWidth, _buttonHeight);
		
		
		
		string _lbl;
		
		if (_firstRun)
			
		{
			
			_lbl = "Старт";
			
		}
		
		else
			
		{
			
			_lbl = "Продолжить";
			
		}
		
		if (GUI.Button(_posNew, _lbl))
			
		{
			
			appState = ST_GAME;
			
			menuPage = MP_NONE;
			
			if (!_firstRun) UnlockGame();
			
			
			
		}
		
		if (GUI.Button(_posOptions, "Настройки"))
			
		{
			
			menuPage = MP_OPTIONS;
			
		}
		
		if (GUI.Button(_posAbout, "Об игре"))
			
		{
			
			menuPage = MP_ABOUT;
			
		}
		
		if (GUI.Button(_posQuit, "Выход"))
			
		{
			
			appState = ST_QUIT;
			
			menuPage = MP_NONE;
			
		}
		
	}
	
	
	
	//рисуем страницу меню «настройки»
	
	void DrawOptionsMenuPage()
		
	{
		
		int _buttonHeight = 30;
		
		int _buttonWidth = 150;
		
		int _left = -4000; // was 40
		
		int _top = -4000; // was 40
		
		Rect _posBack = new Rect(_left, _top, _buttonWidth, _buttonHeight);
		
		if (GUI.Button(_posBack, "Назад"))
			
		{
			
			menuPage = MP_MAIN;
			
		}
		
	}
	
	
	
	
	
	//рисуем страницу меню «об игре»
	
	void DrawAboutMenuPage()
		
	{
		
		int _buttonHeight = 30;
		
		int _buttonWidth = 150;
		
		int _left = 40;
		
		int _top = 40;
		
		Rect _posBack = new Rect(_left, _top, _buttonWidth, _buttonHeight);
		
		if (GUI.Button(_posBack, "Назад"))
			
		{
			
			menuPage = MP_MAIN;
			
		}
		
	}
		
	
	
	//выходим из игры
	
	void AppQuit()		
	{		
		Application.Quit();		
	}	
}