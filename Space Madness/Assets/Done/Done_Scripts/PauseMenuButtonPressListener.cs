using UnityEngine;
using System.Collections;
using AssemblyCSharp;

public class PauseMenuButtonPressListener : MonoBehaviour {
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
			AppCore.SetStatus(AppCore.Status.FAST_GAME);
			break;
		case "Exit Pause Menu Button":
			AppCore.SetStatus(AppCore.Status.MENU);
			break;
		case "Restart Pause Menu Button":
			AppCore.SetStatus(AppCore.Status.RESTART_FAST_GAME);
			break;		
		case "Top Pause Button":
			AppCore.SetStatus(AppCore.Status.FAST_GAME_PAUSE);
			break;
		}
	}
}
