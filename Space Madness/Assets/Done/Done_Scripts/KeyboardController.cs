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
	
	void Update () 
    {
        if(AppCore.GetCurrentStatus() == AppCore.Status.FAST_GAME_OVER)
            TouchScreenKeyboard.Open("",TouchScreenKeyboardType.Default,true,false,false,false,"username");
	}
}
