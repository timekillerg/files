using UnityEngine;
using System.Collections;
using AssemblyCSharp;

public class LevelInfoScript : MonoBehaviour {

	public Sprite iceLevelSprite;
	public Sprite downLevelSprite;
	public Sprite sunLevelSprite;
	public Sprite meteorLevelSprite;

	private void ChangeLevelInfo(Sprite levelInfoSprite)
	{
		if(((SpriteRenderer)renderer).sprite != levelInfoSprite)
			((SpriteRenderer)renderer).sprite = levelInfoSprite;
	}

	void Update()
	{
		switch(AppCore.GetCurrentStatus())
		{
		case AppCore.Status.LEVELS_ICE:				
			ChangeLevelInfo(iceLevelSprite);
			break;
		case AppCore.Status.LEVELS_DOWN:				
			ChangeLevelInfo(downLevelSprite);
			break;
		case AppCore.Status.LEVELS_METEOR:
			ChangeLevelInfo(meteorLevelSprite);
			break;
		case AppCore.Status.LEVELS_SUN:				
			ChangeLevelInfo(sunLevelSprite);
			break;
		}
	}
}
