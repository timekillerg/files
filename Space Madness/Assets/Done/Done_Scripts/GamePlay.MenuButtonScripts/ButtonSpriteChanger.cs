using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

public class ButtonSpriteChanger : MonoBehaviour
{    
    public Sprite pressedSprite;
    private Sprite notPressedSprite;

    void OnMouseDown()
    {
        if (notPressedSprite == null)
            notPressedSprite = ((SpriteRenderer)renderer).sprite;

        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit, 100))
                if (hit.collider.gameObject == this.gameObject)
                {
                    ChangeSprite(true);
                }
        }
    }

    void OnMouseUp()
    {
        ChangeSprite(false);
    }

    void ChangeSprite(bool isPressed)
    {
        if (isPressed)
        {
            if (((SpriteRenderer)renderer).sprite != pressedSprite)
                ((SpriteRenderer)renderer).sprite = pressedSprite;
        }
        else
        {
            if (((SpriteRenderer)renderer).sprite != notPressedSprite)
                ((SpriteRenderer)renderer).sprite = notPressedSprite;
        }
    }
}

