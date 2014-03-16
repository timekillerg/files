using UnityEngine;
using System.Collections;
using AssemblyCSharp;

public class MenuButtonPressListener : MonoBehaviour {

	public Sprite pressedSprite;
	private Sprite notPressedSprite;
	private float pressedTime;


	void Start () {
		notPressedSprite = ((SpriteRenderer)renderer).sprite;
	}
	
	void Update () {
		if ((GameObject.Find ("Screen Main Menu").transform.position.x>-1 && GameObject.Find ("Screen Main Menu").transform.position.x< 1)
			 || (GameObject.Find ("Screen Maps").transform.position.x>-1 && GameObject.Find ("Screen Maps").transform.position.x< 1))
		{
			if (Input.touchCount > 0) {
			Ray ray = Camera.main.ScreenPointToRay (Input.GetTouch(0).position);
			RaycastHit hit;				
			if (Physics.Raycast (ray, out hit, 100)) {
				if(hit.collider.gameObject == gameObject)
				{
					((SpriteRenderer)renderer).sprite = pressedSprite;
					MenuItemClicked();
					pressedTime = Time.time;

				}
			}
		}
		}
		if (Time.time > pressedTime + 0.5f) {
			if(((SpriteRenderer)renderer).sprite!=notPressedSprite)
			{
				((SpriteRenderer)renderer).sprite = notPressedSprite;
				pressedTime = 0;
			}
		}
	}
	
	void OnMouseDown()
	{
		pressedTime = Time.time;
		if ((GameObject.Find ("Screen Main Menu").transform.position.x>-1 && GameObject.Find ("Screen Main Menu").transform.position.x< 1)
		 || (GameObject.Find ("Screen Maps").transform.position.x>-1 && GameObject.Find ("Screen Maps").transform.position.x< 1))
		{
			((SpriteRenderer)renderer).sprite = pressedSprite;
		}
	}
	
	void OnMouseUp ()
	{
		if ((GameObject.Find ("Screen Main Menu").transform.position.x>-1 && GameObject.Find ("Screen Main Menu").transform.position.x< 1)
		 || (GameObject.Find ("Screen Maps").transform.position.x>-1 && GameObject.Find ("Screen Maps").transform.position.x< 1))
		{
			((SpriteRenderer)renderer).sprite = notPressedSprite;
			MenuItemClicked();
		}
	}

	void MenuItemClicked() {
		AppCore.SetPreviousStatus(AppCore.GetCurrentStatus());
		switch(tag) {
		case "FastGameStartButton":
			AppCore.SetStatus(AppCore.Status.FAST_GAME);	
			AppCore.Load();
			break;
		case "ExitGameButton":
			AppCore.SetStatus(AppCore.Status.EXIT);	
			AppCore.Load();
			break;
		case "HistoryButton":
			AppCore.SetStatus(AppCore.Status.MAPS);	
			AppCore.Load();
			break;
		case "ScoresButton":
			AppCore.SetStatus(AppCore.Status.SCORES);	
			AppCore.Load();
			break;
		case "DownMapButton":
			AppCore.SetStatus(AppCore.Status.LEVELS_DOWN);	
			AppCore.Load();
			break;
		case "SunMapButton":
			AppCore.SetStatus(AppCore.Status.LEVELS_SUN);	
			AppCore.Load();
			break;
		case "IceMapButton":
			AppCore.SetStatus(AppCore.Status.LEVELS_ICE);	
			AppCore.Load();
			break;
		case "MeteorMapButton":
			AppCore.SetStatus(AppCore.Status.LEVELS_METEOR);	
			AppCore.Load();
			break;
		}
	}
}
