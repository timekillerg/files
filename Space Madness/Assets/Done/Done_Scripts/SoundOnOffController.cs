using UnityEngine;
using System.Collections;
using AssemblyCSharp;

public class SoundOnOffController : MonoBehaviour {
    public Sprite buttonSpriteON;
    public Sprite buttonSpriteON_Pressed;

    public Sprite buttonSpriteOFF;
    public Sprite buttonSpriteOFF_Pressed;

    private bool isSoundOn = false;

    void Start()
    {
        if(DataCore.IsSoundOn == 1)
            isSoundOn = true;
        else if (DataCore.IsSoundOn == 0)
            isSoundOn = false;
        SetSprite(false);
    }


    private void SetSprite(bool isPressed)
    {
        if(isSoundOn)
            if (isPressed)
                ChangeSprite(buttonSpriteON_Pressed);
            else
                ChangeSprite(buttonSpriteON);
        else
            if (isPressed)
                ChangeSprite(buttonSpriteOFF_Pressed);
            else
                ChangeSprite(buttonSpriteOFF);
    }

    private void ChangeSprite(Sprite expSprite)
    {
        if (((SpriteRenderer)renderer).sprite != expSprite)
            ((SpriteRenderer)renderer).sprite = expSprite;
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
                    SetSprite(true);
                }
            }
        }
    }

    void OnMouseUp()
    {
        SetSprite(false);
        if (Input.GetMouseButtonUp(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit, 100))
            {
                if (hit.collider.gameObject == gameObject)
                {
                    SoundOnOrOff();
                }
            }
        }
    }

    void SoundOnOrOff()
    {
        if (isSoundOn)
        {
            isSoundOn = false;
            DataCore.IsSoundOn = 0;
            AudioListener.pause = true;
        }
        else
        {
            isSoundOn = true;
            DataCore.IsSoundOn = 1;
            AudioListener.pause = false;
        }
        SetSprite(false);            
    }
}
