using UnityEngine;
using System.Collections;
using AssemblyCSharp;
using System;

public class MenuButtonAnimation : MonoBehaviour {
	// Use this for initialization
	private Animator animator;
	private Sprite startSprite;

	void Start () {
		animator = GetComponent<Animator> ();
		animator.enabled = false;
		startSprite = ((SpriteRenderer)renderer).sprite;
	}

	IEnumerator MyMethod() {
		yield return new WaitForSeconds(1);

		if (tag == "FastGameStartButton") {
			AppCore.SetStatus(AppCore.Status.FAST_GAME);	
			AppCore.Load();
		}					
		if (tag == "ExitGameButton") {
			AppCore.SetStatus(AppCore.Status.EXIT);
			AppCore.Load();
		}
		if (tag == "HistoryButton") {
			AppCore.SetStatus(AppCore.Status.MAPS);
			AppCore.Load();
		}				
		if (tag == "ScoresButton") {
			AppCore.SetStatus(AppCore.Status.SCORES);			
			AppCore.Load();
		}
		animator.enabled = false;
		((SpriteRenderer)renderer).sprite = startSprite;
	}

	
	void OnMouseDown()
	{
		animator.enabled = true;
		StartCoroutine (MyMethod ());
	}
}
