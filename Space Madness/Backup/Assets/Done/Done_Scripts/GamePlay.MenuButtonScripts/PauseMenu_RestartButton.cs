using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
using AssemblyCSharp;


class PauseMenu_RestartButton : MonoBehaviour
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
                    PauseMenu_RestartButton_Action();
                }
            }
        }
    }

    private void PauseMenu_RestartButton_Action()
    {
        if (AppCore.CurrentStatus == AppCore.Status.FAST_GAME_PAUSE || AppCore.CurrentStatus == AppCore.Status.FAST_GAME_OVER)
            AppCore.CurrentStatus = AppCore.Status.RESTART_FAST_GAME;
        else if (AppCore.CurrentStatus == AppCore.Status.ANY_LEVEL_PAUSE || AppCore.CurrentStatus == AppCore.Status.ANY_LEVEL_COMPLETE || AppCore.CurrentStatus == AppCore.Status.ANY_LEVEL_FAILED)
            AppCore.CurrentStatus = AppCore.Status.RESTART_ANY_LEVEL;
    }
}