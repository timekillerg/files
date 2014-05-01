using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
using AssemblyCSharp;

class PauseMenu_ResumeButton : MonoBehaviour
{
    public GameObject countdown;

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
                    PauseMenu_ResumeButton_Action();
                }
            }
        }
    }

    private void PauseMenu_ResumeButton_Action()
    {
        Instantiate(countdown);
        if (AppCore.CurrentStatus == AppCore.Status.FAST_GAME_PAUSE)
            AppCore.CurrentStatus = AppCore.Status.FAST_GAME;
        else if (AppCore.CurrentStatus == AppCore.Status.ANY_LEVEL_PAUSE)
            AppCore.CurrentStatus = AppCore.Status.ANY_LEVEL;
    }
}

