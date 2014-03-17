using UnityEngine;
using System.Collections;
using AssemblyCSharp;

public class MenuScript : MonoBehaviour {	
	private GameObject screenLoadingGameObject;
	private float startTime;

	void UnlockGame()		
	{
	}
	
	void LockGame()		
	{
	}

	void Start () {
		AppCore.Start ();
		startTime = Time.time;
	}

	void Awake ()		
	{
		//DontDestroyOnLoad(this);		
	}

	void Update()
	{
		LoadBackButtonEvents ();
		LoadMouseEvents ();
		if(Time.time > (startTime+2.0f) && AppCore.GetCurrentStatus() == AppCore.Status.LOADING)
		{
			AppCore.SetPreviousStatus(AppCore.Status.LOADING);
			AppCore.SetStatus(AppCore.Status.MENU);
			AppCore.Load();
		}
		switch(AppCore.GetCurrentStatus())
		{
			case AppCore.Status.MENU:
			stopIfStopPosition(GameObject.Find("Screen Main Menu"));
			break;
			case AppCore.Status.MAPS:
			stopIfStopPosition(GameObject.Find("Screen Maps"));
			break;
			case AppCore.Status.SCORES:
			stopIfStopPosition(GameObject.Find("Screen Scores"));
			break;
			case AppCore.Status.LEVELS_ICE:
			stopIfStopPosition(GameObject.Find ("Screen Levels Ice"));
			break;
			case AppCore.Status.LEVELS_METEOR:
			stopIfStopPosition(GameObject.Find ("Screen Levels Meteor"));
			break;
			case AppCore.Status.LEVELS_SUN:
			stopIfStopPosition(GameObject.Find ("Screen Levels Sun"));
			break;
			case AppCore.Status.LEVELS_DOWN:
			stopIfStopPosition(GameObject.Find ("Screen Levels Down"));
			break;
		}
	}

	private void stopIfStopPosition(GameObject go)
	{
		if(go.rigidbody.position.x >=-0.2f && go.rigidbody.position.x <=0.2f)
			go.rigidbody.velocity = Vector3.zero;
	}

	private void LoadMouseEvents()
	{
		if (Input.GetMouseButton(0)) {
			Ray ray = Camera.main.ScreenPointToRay (Input.mousePosition);
			RaycastHit hit;				
			if (Physics.Raycast (ray, out hit, 100)) {
				if(AppCore.GetCurrentStatus() == AppCore.Status.LOADING)
				{
					AppCore.SetPreviousStatus(AppCore.Status.LOADING);
					AppCore.SetStatus(AppCore.Status.MENU);
					AppCore.Load();
				}
			}
		}
	}


	private void LoadBackButtonEvents()
	{
		if (Input.GetKeyDown(KeyCode.Escape))			
		{
			AppCore.BackButtonPress();
		}
	}
}