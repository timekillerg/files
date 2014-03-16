using UnityEngine;
using System.Collections;
using AssemblyCSharp;

public class ScreenMoveLeftRightListener : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		switch(AppCore.GetPresiousStatus())
		{
			case AppCore.Status.MENU:
			rigidbody.position = new Vector3 (Mathf.Clamp (rigidbody.position.x, 0, 15), 0.0f, 0.0f);
			break;
			case AppCore.Status.MAPS:
			if(AppCore.GetCurrentStatus() != AppCore.Status.MENU)
				rigidbody.position = new Vector3 (Mathf.Clamp (rigidbody.position.x, -15, 1), 0.0f, 0.0f);
			break;

			case AppCore.Status.LEVELS_DOWN:
			case AppCore.Status.LEVELS_ICE:
			case AppCore.Status.LEVELS_METEOR:
			case AppCore.Status.LEVELS_SUN:
			rigidbody.position = new Vector3 (Mathf.Clamp (rigidbody.position.x, -15, 0), 0.0f, 0.0f);
			break;
		}

	}
}
