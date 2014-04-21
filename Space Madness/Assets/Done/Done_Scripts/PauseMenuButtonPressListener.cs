using UnityEngine;
using System.Collections;
using AssemblyCSharp;

public class PauseMenuButtonPressListener : MonoBehaviour
{
	public Sprite buttonSprite;
	public Sprite buttonSpritePressed;

	void Start () {
		LoadStarsOnScreen ();
		SetSprite (false);
	}
	
	private void LoadStarsOnScreen()
	{

	}
	
	private void SetSprite(bool isPressed)
	{
		if(isPressed)
			ChangeSprite(buttonSpritePressed);
		else
			ChangeSprite(buttonSprite);
	}
	
	private void ChangeSprite(Sprite expSprite)
	{
		if(((SpriteRenderer)renderer).sprite != expSprite)
			((SpriteRenderer)renderer).sprite = expSprite;
	}
	
	void OnMouseDown()
	{
        if (gameObject.name == "Top Pause Button" && Time.timeScale == 0.0f)
            return;

		if (Input.GetMouseButtonDown(0)) {
			Ray ray = Camera.main.ScreenPointToRay (Input.mousePosition);
			RaycastHit hit;				
			if (Physics.Raycast (ray, out hit, 100)) {
				if(hit.collider.gameObject == gameObject)
				{
					SetSprite(true);
				}
			}
		}
	}
	
	void OnMouseUp ()
	{
        if (gameObject.name == "Top Pause Button" && Time.timeScale == 0.0f)
            return;
		SetSprite(false);
		if (Input.GetMouseButtonUp(0)) {
			Ray ray = Camera.main.ScreenPointToRay (Input.mousePosition);
			RaycastHit hit;				
			if (Physics.Raycast (ray, out hit, 100)) {
				if(hit.collider.gameObject == gameObject)
				{						
					PauseMenuButtonClicked();
				}
			}
		}
	}

	void PauseMenuButtonClicked()
	{
		switch (gameObject.name) {
		case "Resume Pause Menu Button":        
            GameCore.isShowStartCountDown = true;
                if(AppCore.CurrentStatus == AppCore.Status.FAST_GAME_PAUSE)
			        AppCore.CurrentStatus = AppCore.Status.FAST_GAME;
                else if(AppCore.CurrentStatus == AppCore.Status.ANY_LEVEL_PAUSE)
                    AppCore.CurrentStatus =AppCore.Status.ANY_LEVEL;
			break;

		case "Exit Pause Menu Button":
        case "Game Over Exit Button":
            if (AppCore.CurrentStatus == AppCore.Status.FAST_GAME_PAUSE || AppCore.CurrentStatus == AppCore.Status.FAST_GAME_OVER)
                AppCore.CurrentStatus = AppCore.Status.MENU;
            else if (AppCore.CurrentStatus == AppCore.Status.ANY_LEVEL_PAUSE)
            {
                switch (GameCore.mapType)
                {
                    case Maps.DownFall:
                        AppCore.CurrentStatus = AppCore.Status.LEVELS_DOWN;
                        break;
                    case Maps.IceAnomaly:
                        AppCore.CurrentStatus = AppCore.Status.LEVELS_ICE;
                        break;
                    case Maps.SunStorm:
                        AppCore.CurrentStatus = AppCore.Status.LEVELS_SUN;
                        break;
                    case Maps.MeteorRain:
                        AppCore.CurrentStatus = AppCore.Status.LEVELS_METEOR;
                        break;
                }
            }
			break;
		case "Restart Pause Menu Button":
        case "Game Over Restart Button":
            if (AppCore.CurrentStatus == AppCore.Status.FAST_GAME_PAUSE || AppCore.CurrentStatus == AppCore.Status.FAST_GAME_OVER)
                AppCore.CurrentStatus =AppCore.Status.RESTART_FAST_GAME;
            else if (AppCore.CurrentStatus == AppCore.Status.ANY_LEVEL_PAUSE)
                AppCore.CurrentStatus = AppCore.Status.RESTART_ANY_LEVEL;
			break;		
		case "Top Pause Button":
            if (AppCore.CurrentStatus == AppCore.Status.FAST_GAME)
                    AppCore.CurrentStatus = AppCore.Status.FAST_GAME_PAUSE;
            else if (AppCore.CurrentStatus == AppCore.Status.ANY_LEVEL)
                    AppCore.CurrentStatus = AppCore.Status.ANY_LEVEL_PAUSE;
			break;
		}
	}
}
