using UnityEngine;
using System.Collections;

public class TouchMoveButtons : MonoBehaviour {

	
	void FixedUpdate ()
	{
		if (Input.touchCount > 0) {
			Ray ray = Camera.main.ScreenPointToRay (Input.GetTouch(0).position);
			RaycastHit hit;				
			if (Physics.Raycast (ray, out hit, 100)) {					
				if (hit.collider.tag == "LeftButton") {
					GameObject gm = GameObject.FindGameObjectsWithTag("LeftButton")[0];
					gm.renderer.enabled = false;
					gm = GameObject.FindGameObjectsWithTag("LeftButtonPressed")[0];
					gm.renderer.enabled = true;


				}					
				if (hit.collider.tag == "RightButton") {
					GameObject gm = GameObject.FindGameObjectsWithTag("RightButton")[0];
					gm.renderer.enabled = false;
					gm = GameObject.FindGameObjectsWithTag("RightButtonPressed")[0];
					gm.renderer.enabled = true;
				}
			}
		}
		if (Input.touchCount == 0) {
			GameObject gm = GameObject.FindGameObjectsWithTag("LeftButton")[0];
			gm.renderer.enabled = true;
			gm = GameObject.FindGameObjectsWithTag("RightButton")[0];
			gm.renderer.enabled = true;
			gm = GameObject.FindGameObjectsWithTag("LeftButtonPressed")[0];
			gm.renderer.enabled = false;
			gm = GameObject.FindGameObjectsWithTag("RightButtonPressed")[0];
			gm.renderer.enabled = false;
		}
	}
}
