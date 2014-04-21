using UnityEngine;
using System.Collections;
using AssemblyCSharp;

public class LightAnimation : MonoBehaviour {

	public float smooth;
	private float startTime;
	public Texture meteorLevelsFont;
	public Texture iceLevelsFont;
	public Texture downLevelsFont;
	public Texture sunLevelsFont;
	public Texture mainFont;
	public Texture gameLoadingFont;
	public GameObject planMenu;
	private Texture initialFont;
		
	void Update ()
	{
		IntensityChanging();
	}

	void Start ()
	{
		startTime = Time.time;
	}

	private void ChangeBackground(Texture texture)
	{
		if(!(planMenu.renderer.material.mainTexture == texture && light.intensity >=0.45))
		{
			if(planMenu.renderer.material.mainTexture != texture)
				light.intensity = Mathf.Lerp(light.intensity, 0.0f, smooth*10* Time.deltaTime);

			if (light.intensity <= 0.05)
				planMenu.renderer.material.mainTexture = texture;

			if(planMenu.renderer.material.mainTexture == texture)
				light.intensity = Mathf.Lerp(light.intensity, 0.5f, smooth*10* Time.deltaTime);
		}
	}
		
	
	void IntensityChanging ()
	{
        switch (AppCore.CurrentStatus)
		{
		case AppCore.Status.LOADING:
			if(Time.time > (startTime+0.75))
				light.intensity = Mathf.Lerp(light.intensity, 0.5f, smooth * Time.deltaTime);
			break;
		case AppCore.Status.LEVELS_ICE:
			ChangeBackground(iceLevelsFont);
			break;
		case AppCore.Status.LEVELS_DOWN:
			ChangeBackground(downLevelsFont);
			break;
		case AppCore.Status.LEVELS_METEOR:
			ChangeBackground(meteorLevelsFont);
			break;
		case AppCore.Status.LEVELS_SUN:
			ChangeBackground(sunLevelsFont);
			break;
		case AppCore.Status.MAPS:
			ChangeBackground(mainFont);
			break;
		case AppCore.Status.FAST_GAME:
			ChangeBackground(gameLoadingFont);
			break;
        case AppCore.Status.ANY_LEVEL:
            break;
		default:
			planMenu.renderer.material.mainTexture = mainFont;
			light.intensity = 0.5f;
			light.color = Color.white;
			break;
		}
	}
}
