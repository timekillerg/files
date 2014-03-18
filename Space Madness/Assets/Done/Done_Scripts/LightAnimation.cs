using UnityEngine;
using System.Collections;
using AssemblyCSharp;

public class LightAnimation : MonoBehaviour {

	public float smooth;

	private float startTime;
		
	void Update ()
	{
		IntensityChanging();
	}

	void Start ()
	{
		startTime = Time.time;
	}
		
	
	void IntensityChanging ()
	{
		if(AppCore.GetCurrentStatus() == AppCore.Status.LOADING)
		{
			if(Time.time > (startTime+0.5))
				light.intensity = Mathf.Lerp(light.intensity, 0.5f, smooth * Time.deltaTime);
		}
		else
		{
			light.intensity = 0.5f;
			light.color = Color.white;
		}
	}

}
