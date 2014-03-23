using UnityEngine;
using System.Collections;

public class LevelButtonPressListener : MonoBehaviour {	
	public Sprite lockedLevelSprite;
	public Sprite lockedLevelSpritePressed;
	public Sprite levelSprite;
	public Sprite levelSpritePressed;
	public GameObject star1;
	public GameObject star2;
	public GameObject star3;

	private bool isLevelAvailable;
	private int countOfStars;
		
	void Start () {
		countOfStars = 1;
		isLevelAvailable = true;

		if (gameObject.transform.parent.gameObject.name.Contains ("11"))
			countOfStars = 3;
		if (gameObject.transform.parent.gameObject.name.Contains ("12"))
		{
			countOfStars = 0;
			isLevelAvailable = false;
		}

		LoadStarsOnScreen ();
		SetSprite (false);
	}

	private void LoadStarsOnScreen()
	{
		switch(countOfStars)
		{
		case 0:
			star1.renderer.enabled = false;
			star2.renderer.enabled = false;
			star3.renderer.enabled = false;
			break;
		case 1:
			star1.renderer.enabled = true;
			star2.renderer.enabled = false;
			star3.renderer.enabled = false;
			break;
		case 2:
			star1.renderer.enabled = true;
			star2.renderer.enabled = true;
			star3.renderer.enabled = false;
			break;
		case 3:
			star1.renderer.enabled = true;
			star2.renderer.enabled = true;
			star3.renderer.enabled = true;
			break;
		}
	}

	private void SetSprite(bool isPressed)
	{
		if(!isLevelAvailable)
			if(isPressed)
				ChangeSprite(lockedLevelSpritePressed);
			else
				ChangeSprite(lockedLevelSprite);				
		else
			if(isPressed)
				ChangeSprite(levelSpritePressed);
			else
				ChangeSprite(levelSprite);
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
					//MenuItemClicked();
				}
			}
		}
	}
}
