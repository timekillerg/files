using UnityEngine;
using System.Collections;
using AssemblyCSharp;

public class MenuButtonPressListener : MonoBehaviour {

	public Sprite pressedSprite;
	private Sprite notPressedSprite;

	void Start () {
		notPressedSprite = ((SpriteRenderer)renderer).sprite;
	}
	
	void OnMouseDown()
	{
		if ((GameObject.Find ("Screen Main Menu").transform.position.x>=-3 && GameObject.Find ("Screen Main Menu").transform.position.x <= 3)
		    || (GameObject.Find ("Screen Maps").transform.position.x>=-3 && GameObject.Find ("Screen Maps").transform.position.x <= 3))
		if (Input.GetMouseButtonDown(0)) {
			Ray ray = Camera.main.ScreenPointToRay (Input.mousePosition);
			RaycastHit hit;				
			if (Physics.Raycast (ray, out hit, 100)) {
				if(hit.collider.gameObject == gameObject)
				{
					((SpriteRenderer)renderer).sprite = pressedSprite;	
				}
			}
		}
	}

	void OnMouseUp ()
	{
		((SpriteRenderer)renderer).sprite = notPressedSprite;
		if ((GameObject.Find ("Screen Main Menu").transform.position.x>=-3 && GameObject.Find ("Screen Main Menu").transform.position.x <= 3)
		    || (GameObject.Find ("Screen Maps").transform.position.x>=-3 && GameObject.Find ("Screen Maps").transform.position.x <= 3))
		if (Input.GetMouseButtonUp(0)) {
			Ray ray = Camera.main.ScreenPointToRay (Input.mousePosition);
			RaycastHit hit;				
			if (Physics.Raycast (ray, out hit, 100)) {
				if(hit.collider.gameObject == gameObject)
				{						
					MenuItemClicked();
				}
			}
		}
	}

	void MenuItemClicked() {
		switch(tag) {
		case "FastGameStartButton":
			AppCore.CurrentStatus = AppCore.Status.FAST_GAME;	
			break;
		case "ExitGameButton":
            AppCore.CurrentStatus = AppCore.Status.EXIT;
			AppCore.Load();
			break;
		case "HistoryButton":
            AppCore.CurrentStatus = AppCore.Status.MAPS;	
			break;
		case "ScoresButton":
            AppCore.CurrentStatus = AppCore.Status.SCORES;
			break;
		case "DownMapButton":
            AppCore.CurrentStatus = AppCore.Status.LEVELS_DOWN;
			break;
		case "SunMapButton":
            AppCore.CurrentStatus = AppCore.Status.LEVELS_SUN;
			break;
		case "IceMapButton":
            AppCore.CurrentStatus = AppCore.Status.LEVELS_ICE;
			break;
		case "MeteorMapButton":
			AppCore.CurrentStatus =AppCore.Status.LEVELS_METEOR;
			break;
		}
	}
}
