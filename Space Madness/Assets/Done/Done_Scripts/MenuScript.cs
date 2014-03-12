using UnityEngine;
using System.Collections;
using AssemblyCSharp;

public class MenuScript : MonoBehaviour {	
	private GameObject screenLoadingGameObject;

	void UnlockGame()		
	{
	}
	
	void LockGame()		
	{
	}

	void Start () {
		AppCore.Start ();
	}

	void Awake ()		
	{
		DontDestroyOnLoad(this);		
	}


	void Update()
	{
		LoadBackButtonEvents ();
		LoadMouseEvents ();
	}

	IEnumerator waitAndAction(GameObject touchedGameObject) {
		Animator animator = touchedGameObject.GetComponent<Animator> ();
		Sprite startSprite = ((SpriteRenderer)touchedGameObject.renderer).sprite;

		yield return new WaitForSeconds(1);
		if (touchedGameObject.tag == "FastGameStartButton") {				
			AppCore.SetStatus(AppCore.Status.FAST_GAME);
			AppCore.Load();
		}					
		if (touchedGameObject.tag == "ExitGameButton") {
			AppCore.SetStatus(AppCore.Status.EXIT);
			AppCore.Load();
		}
		if (touchedGameObject.tag == "HistoryButton") {
			AppCore.SetStatus(AppCore.Status.MAPS);
			AppCore.Load();
		}				
		if (touchedGameObject.tag == "ScoresButton") {
			AppCore.SetStatus(AppCore.Status.SCORES);
			AppCore.Load();
		}
		if(AppCore.GetStatus() == AppCore.Status.LOADING)
		{
			AppCore.SetStatus(AppCore.Status.MENU);
			AppCore.Load();
		}
		animator.enabled = false;
		((SpriteRenderer)touchedGameObject.renderer).sprite = startSprite;
	}


	void LoadTouchEvents()
	{
		if (Input.touchCount > 0) {
			Ray ray = Camera.main.ScreenPointToRay (Input.GetTouch(0).position);
			RaycastHit hit;				
			if (Physics.Raycast (ray, out hit, 100)) {
				if(AppCore.GetStatus() == AppCore.Status.LOADING)
				{
					AppCore.SetStatus(AppCore.Status.MENU);
					AppCore.Load();
				}
				else
				{
					if(hit.collider.gameObject.GetComponent<Animator>())
						waitAndAction(hit.collider.gameObject);
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
				if(AppCore.GetStatus() == AppCore.Status.LOADING)
				{
					AppCore.SetStatus(AppCore.Status.MENU);
					AppCore.Load();
				}
			}
		}
	}	


	private void LoadBackButtonEvents()
	{
		if (Input.GetKeyDown(KeyCode.Escape))			
		{
			AppCore.BackButtonPress();
		}
	}
}