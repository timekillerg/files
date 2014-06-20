using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
using AssemblyCSharp;

class GameTop_PauseButton : MonoBehaviour
{
    public GameObject menuPauseButtons;

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
                    GameTop_PauseButton_Action();
                }
            }
        }
    }

    private void GameTop_PauseButton_Action()
    {
        if (AppCore.CurrentStatus == AppCore.Status.FAST_GAME)
        {
            Instantiate(menuPauseButtons);
            AppCore.CurrentStatus = AppCore.Status.FAST_GAME_PAUSE;
        }
        else if (AppCore.CurrentStatus == AppCore.Status.ANY_LEVEL)
        {
            Instantiate(menuPauseButtons);
            AppCore.CurrentStatus = AppCore.Status.ANY_LEVEL_PAUSE;
        }
    }
}
