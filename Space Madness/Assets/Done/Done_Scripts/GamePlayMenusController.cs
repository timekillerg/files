using UnityEngine;
using System.Collections;
using AssemblyCSharp;

public class GamePlayMenusController : MonoBehaviour {
	public GameObject scPauseMenuGO;
	private float speed;
	private Vector3 V3_LEFT = new Vector3 (-14f, 0.0f, 5.0f);
	private Vector3 V3_CENTER = new Vector3 (0.0f, 0.0f, 5.0f);
	private Vector3 V3_DELTA = new Vector3 (0.2f, 0.2f, 0.2f);
	
	void Start () {
		speed = 3.2f;
	}
	
	private void moveAndStopStopAtPosition(GameObject go, Vector3 expectedPosition)
	{
		go.rigidbody.velocity = Vector3.zero;
		go.rigidbody.transform.position = Vector3.Lerp(go.transform.position,expectedPosition, Time.fixedDeltaTime * speed);
		if(go.rigidbody.position.x >=(expectedPosition.x-V3_DELTA.x) && go.rigidbody.position.x <=(expectedPosition.x+V3_DELTA.x))
			go.rigidbody.velocity = Vector3.zero;
	}
	
	void Update()
	{
		switch(AppCore.GetCurrentStatus())
		{
		case AppCore.Status.FAST_GAME_PAUSE:
			moveAndStopStopAtPosition(scPauseMenuGO,V3_CENTER);
			break;
		case AppCore.Status.FAST_GAME:
			moveAndStopStopAtPosition(scPauseMenuGO,V3_LEFT);
			break;
		default:
			moveAndStopStopAtPosition(scPauseMenuGO,V3_LEFT);
			break;
		}
	}
}
