using UnityEngine;
using System.Collections;

public class PlayIfAtscreen : MonoBehaviour {

	void Start()
	{
		(gameObject.GetComponent<Animator>()).enabled = false;
	}
	
	// Update is called once per frame
	void Update () {
		if (gameObject.transform.parent.transform.position.x >= -1f && gameObject.transform.parent.transform.position.x <= 1f)
			(gameObject.GetComponent<Animator>()).enabled = true;	
	}
}
