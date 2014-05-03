using UnityEngine;
using System.Collections;
using AssemblyCSharp;

public class LevelButtonPressListener : MonoBehaviour {	
	public Sprite lockedLevelSprite;
	public Sprite lockedLevelSpritePressed;
	public Sprite levelSprite;
	public Sprite levelSpritePressed;
	public GameObject star1;
	public GameObject star2;
	public GameObject star3;

	private bool isLevelAvailable = false;
    private int countOfStars = 0;
    private string levelName;
		
	void Start () {
        levelName = gameObject.transform.parent.gameObject.name;
        countOfStars = DataCore.GetLevelCountOfStars(levelName);

        LoadStarsOnScreen(countOfStars);

        if (countOfStars > 0)
            isLevelAvailable = true;
        Debug.Log(levelName+isLevelAvailable);
        if ((countOfStars == 0) && (levelName == "Down Level 1" || levelName == "Sun Level 1" || levelName == "Ice Level 1" || levelName == "Meteor Level 1"))
            isLevelAvailable = true;
        Debug.Log(levelName + isLevelAvailable);
        if ((countOfStars == 0) && !isLevelAvailable)
            CheckIsPreviousLevelOpened();

        Debug.Log(levelName + isLevelAvailable);

		SetSprite (false);
	}

    private void CheckIsPreviousLevelOpened()
    {       
        string[] levelNameBeginings = { "Down Level ", "Sun Level ", "Ice Level ", "Meteor Level " };

        foreach(string levelNameBegin in levelNameBeginings)
        {
            if (levelName.Contains(levelNameBegin))
            {
                string temp = levelName;
                int levelNumber = int.Parse(levelName.Replace(levelNameBegin, ""));
                levelName = temp;
                if(levelNumber>0 && DataCore.GetLevelCountOfStars(levelNameBegin+(levelNumber-1).ToString()) > 0)
                    isLevelAvailable = true;
            }
        }
    }

    private void LoadStarsOnScreen(int countOfStars)
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
                if (hit.collider.gameObject == gameObject && isLevelAvailable)
				{						
					LevelButtonClicked();
				}
			}
		}
	}

    private void LevelButtonClicked()
    {
        AppCore.CurrentStatus = AppCore.Status.ANY_LEVEL;
        GameCore.Initialize(gameObject.transform.parent.gameObject.name);
    }
}
