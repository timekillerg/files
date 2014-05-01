using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
using AssemblyCSharp;

class PauseMenu_ExitButton : MonoBehaviour
{
    void OnMouseUp()
    {        
        if (Input.GetMouseButtonUp(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit, 100))
            {
                if (hit.collider.gameObject == gameObject)
                {
                    PauseMenu_ExitButton_Action();
                }
            }
        }
    }

    private void PauseMenu_ExitButton_Action()
    {
        if (AppCore.CurrentStatus == AppCore.Status.FAST_GAME_PAUSE || AppCore.CurrentStatus == AppCore.Status.FAST_GAME_OVER)
            AppCore.CurrentStatus = AppCore.Status.MENU;
        else if (AppCore.CurrentStatus == AppCore.Status.ANY_LEVEL_PAUSE || AppCore.CurrentStatus == AppCore.Status.ANY_LEVEL_COMPLETE || AppCore.CurrentStatus == AppCore.Status.ANY_LEVEL_FAILED)
        {
            switch (GameCore.mapType)
            {
                case Maps.DownFall:
                    AppCore.CurrentStatus = AppCore.Status.LEVELS_DOWN;
                    break;
                case Maps.IceAnomaly:
                    AppCore.CurrentStatus = AppCore.Status.LEVELS_ICE;
                    break;
                case Maps.SunStorm:
                    AppCore.CurrentStatus = AppCore.Status.LEVELS_SUN;
                    break;
                case Maps.MeteorRain:
                    AppCore.CurrentStatus = AppCore.Status.LEVELS_METEOR;
                    break;
            }
        }
    }
}
