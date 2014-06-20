using UnityEngine;
using System.Collections;

public class TouchMoveButtons : MonoBehaviour {
	public Sprite buttonSprite;
	public Sprite buttonSpritePressed;
	private bool isPressed;
	
	void Start () {
		isPressed = false;
		SetSprite ();
	}

	private void SetSprite()
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
					isPressed = true;
					SetSprite();
				}
			}
		}
	}
	
	void OnMouseUp ()
	{
		isPressed = false;
		SetSprite();
	}

	void OnMouseExit ()
	{
		isPressed = false;
		SetSprite();
	}
}
