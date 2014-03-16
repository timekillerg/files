using UnityEngine;
using System.Collections;

public class ScreenMoveRightListener : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		rigidbody.position = new Vector3 
			(
				Mathf.Clamp (rigidbody.position.x, -15, 0), 
				0.0f, 
				0.0f
				);
	}
}
