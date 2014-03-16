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