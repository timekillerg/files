using UnityEngine;
using System.Collections;

public class AppearMenuButtons : MonoBehaviour {

	// Use this for initialization
	void Start () {
		rigidbody.velocity = Vector3.right*4;
	}

	void FixedUpdate ()
	{
		rigidbody.position = new Vector3 
			(
				Mathf.Clamp (rigidbody.position.x, -11.0f, 0.0f), 
				Mathf.Clamp (rigidbody.position.z, -50.0f, 50.0f), 
				Mathf.Clamp (rigidbody.position.z, -50.0f, 50.0f)
			);
	}
}
