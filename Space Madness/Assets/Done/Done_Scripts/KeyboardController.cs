using UnityEngine;
using System.Collections;
using AssemblyCSharp;

public class KeyboardController : MonoBehaviour {

    private TouchScreenKeyboard keyboard = null;
    private GUIText username;

	void Start () 
    {
        username = GameObject.FindWithTag("TextUsername").guiText;
        keyboard = new TouchScreenKeyboard("", TouchScreenKeyboardType.Default, true, true, false, false, DataCore.CurrentUsername);
        keyboard.active = false;
	}

    void OnMouseDown()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit, 100))
            {
                if (hit.collider.gameObject == gameObject)
                {
                    keyboard = TouchScreenKeyboard.Open(DataCore.CurrentUsername, TouchScreenKeyboardType.Default, true, false, false, false, "Enter your name");
                }
            }
        }
    }

    void Update()
    {
        if (keyboard.active)
            username.text = keyboard.text;
        if (keyboard.done)
        {
            if (keyboard.text.Length > 0)
            {
                username.text = keyboard.text;
                DataCore.CurrentUsername = username.text;
            }
        }
    }
}
