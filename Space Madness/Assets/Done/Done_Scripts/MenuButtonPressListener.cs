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
	}
	
	void OnMouseDown()
	{
		if ((GameObject.Find ("Screen Main Menu").transform.position.x>=-0.2 && GameObject.Find ("Screen Main Menu").transform.position.x <= 0.2)
		    || (GameObject.Find ("Screen Maps").transform.position.x>=-0.2 && GameObject.Find ("Screen Maps").transform.position.x <= 0.2))
		if (Input.GetMouseButtonDown(0)) {
			Ray ray = Camera.main.ScreenPointToRay (Input.mousePosition);
			RaycastHit hit;				
			if (Physics.Raycast (ray, out hit, 100)) {
				if(hit.collider.gameObject == gameObject)
				{
					((SpriteRenderer)renderer).sprite = pressedSprite;					
					pressedTime = Time.time;
				}
			}
		}
	}

	void OnMouseUp ()
	{
		((SpriteRenderer)renderer).sprite = notPressedSprite;
		if ((GameObject.Find ("Screen Main Menu").transform.position.x>=-0.2 && GameObject.Find ("Screen Main Menu").transform.position.x <= 0.2)
		    || (GameObject.Find ("Screen Maps").transform.position.x>=-0.2 && GameObject.Find ("Screen Maps").transform.position.x <= 0.2))
		if (Input.GetMouseButtonUp(0)) {
			Ray ray = Camera.main.ScreenPointToRay (Input.mousePosition);
			RaycastHit hit;				
			if (Physics.Raycast (ray, out hit, 100)) {
				if(hit.collider.gameObject == gameObject)
				{										
					pressedTime = 0;
					MenuItemClicked();
				}
			}
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
