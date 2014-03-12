using UnityEngine;
using System.Collections;

public class MenuButtonScript : MonoBehaviour {

	// Use this for initialization
	private Animator animator;
	void Start () {
		animator = GetComponent<Animator> ();
		animator.enabled = false;
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnMouseDown()
	{
		animator.enabled = true;
	}
}
