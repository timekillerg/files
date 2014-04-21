using UnityEngine;
using System.Collections;
using AssemblyCSharp;

public class KeyboardController : MonoBehaviour {

    private TouchScreenKeyboard keyboard = null;

	void Start () 
    {
        keyboard = new TouchScreenKeyboard("", TouchScreenKeyboardType.Default, true, true, false, false, "");
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
                   TouchScreenKeyboard.Open("", TouchScreenKeyboardType.Default, true, false, false, false, "Enter your name");
                }
            }
        }
    }
}
