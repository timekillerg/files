using UnityEngine;
using System.Collections;
using AssemblyCSharp;

public class MenuScript : MonoBehaviour {
	private GameObject scMainMenuGO;
	private GameObject scMapsGO;	
	private GameObject scScoresGO;	
	private GameObject scLevelsMeteorGO;	
	private GameObject scLevelsIceGO;
	private GameObject scLevelsDownGO;
	private GameObject scLevelsSunGO;

	private float startTime;
	private float speed;
	private Vector3 V3_LEFT = new Vector3 (-14f, 0.0f, 0.0f);
	private Vector3 V3_RIGHT = new Vector3 (14f, 0.0f, 0.0f);
	private Vector3 V3_CENTER = Vector3.zero;
	private Vector3 V3_DELTA = new Vector3 (0.2f, 0.0f, 0.0f);

	void Start () {
		AppCore.Start ();
		startTime = Time.time;
		speed = 3.2f;		
		scMainMenuGO = GameObject.Find("Screen Main Menu");
		scMapsGO = GameObject.Find("Screen Maps");	
		scScoresGO = GameObject.Find("Screen Scores");	
		scLevelsMeteorGO = GameObject.Find ("Screen Levels Meteor");	
		scLevelsIceGO = GameObject.Find ("Screen Levels Ice");		
		scLevelsSunGO = GameObject.Find ("Screen Levels Sun");
		scLevelsDownGO = GameObject.Find ("Screen Levels Down");
	}

	private void moveAndStopStopAtPosition(GameObject go, Vector3 expectedPosition)
	{
		go.rigidbody.transform.position = Vector3.Lerp(go.transform.position,expectedPosition, Time.deltaTime * speed);
		if(go.rigidbody.position.x >=(expectedPosition.x-V3_DELTA.x) && go.rigidbody.position.x <=(expectedPosition.x+V3_DELTA.x))
			go.rigidbody.velocity = Vector3.zero;
	}

	void Update()
	{
		LoadBackButtonEvents ();
		switch(AppCore.GetCurrentStatus())
		{
			case AppCore.Status.SCORES:
				moveAndStopStopAtPosition(scScoresGO,V3_CENTER);
				moveAndStopStopAtPosition(scMainMenuGO,V3_LEFT);
				break;
			case AppCore.Status.MAPS:
				moveAndStopStopAtPosition(scMapsGO,V3_CENTER);
				moveAndStopStopAtPosition(scMainMenuGO,V3_LEFT);
				moveAndStopStopAtPosition(scLevelsMeteorGO,V3_RIGHT);
				moveAndStopStopAtPosition(scLevelsIceGO,V3_RIGHT);
				moveAndStopStopAtPosition(scLevelsDownGO,V3_RIGHT);
				moveAndStopStopAtPosition(scLevelsSunGO,V3_RIGHT);
				break;
			case AppCore.Status.MENU:				
				moveAndStopStopAtPosition(scMainMenuGO,V3_CENTER);
				moveAndStopStopAtPosition(scScoresGO,V3_RIGHT);
				moveAndStopStopAtPosition(scMapsGO,V3_RIGHT);
				moveAndStopStopAtPosition(scLevelsMeteorGO,V3_RIGHT);
				moveAndStopStopAtPosition(scLevelsIceGO,V3_RIGHT);
				moveAndStopStopAtPosition(scLevelsDownGO,V3_RIGHT);
				moveAndStopStopAtPosition(scLevelsSunGO,V3_RIGHT);
				break;
			case AppCore.Status.LEVELS_ICE:				
				moveAndStopStopAtPosition(scLevelsIceGO,V3_CENTER);
				moveAndStopStopAtPosition(scMapsGO,V3_LEFT);
				break;
			case AppCore.Status.LEVELS_DOWN:				
				moveAndStopStopAtPosition(scLevelsDownGO,V3_CENTER);			
				moveAndStopStopAtPosition(scMapsGO,V3_LEFT);
				break;
			case AppCore.Status.LEVELS_METEOR:
				moveAndStopStopAtPosition(scLevelsMeteorGO,V3_CENTER);
				moveAndStopStopAtPosition(scMapsGO,V3_LEFT);
				break;
			case AppCore.Status.LEVELS_SUN:				
				moveAndStopStopAtPosition(scLevelsSunGO,V3_CENTER);			
				moveAndStopStopAtPosition(scMapsGO,V3_LEFT);
				break;
			case AppCore.Status.LOADING:
				if(Time.time > (startTime + 2))
				{
					if(GameObject.Find ("Screen First Loading"))
						MonoBehaviour.Destroy (GameObject.Find ("Screen First Loading"));
					AppCore.SetStatus(AppCore.Status.MENU);
				}
				break;
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