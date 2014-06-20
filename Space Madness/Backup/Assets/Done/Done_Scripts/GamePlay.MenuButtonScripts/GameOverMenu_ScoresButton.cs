using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
using AssemblyCSharp;

class GameOverMenu_ScoresButton : MonoBehaviour
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
                    GameOverMenu_ScoresButton_Action();
                }
            }
        }
    }

    private void GameOverMenu_ScoresButton_Action()
    {
        AppCore.CurrentStatus = AppCore.Status.SCORES;
    }
}
