using UnityEngine;
using System.Collections;
using AssemblyCSharp;
using System;

public class JoysticController : MonoBehaviour
{
    public GameObject playerGameObject;
    public GameObject joysticGameObject;
    public Sprite joyStartSprite;
    public Sprite joyPressSprite;

    public float PlayerSpeed;
    public float JoysticSpeed;
    public float JoyTrip;
    public float JoyTripMultiplier;
    public float PlayerTilt;

    private float vector;
    private readonly Vector3 TRIP = new Vector3(6, 0, 0);
    private Vector3 JoyPosition;

    void Start()
    {
        JoyPosition = joysticGameObject.transform.position;
    }

    void Update()
    {
        if (playerGameObject != null)
        {
            playerGameObject.rigidbody.rotation = Quaternion.Euler(270 - vector * PlayerTilt, 270, 0.0f);
            if (vector != 0)
                playerGameObject.transform.position = Vector3.MoveTowards(playerGameObject.transform.position,
                    TRIP * Math.Abs(vector) / vector,
                    PlayerSpeed * Time.deltaTime * Math.Abs(vector));
        }

        JoyPosition.x = vector * JoyTrip * JoyTripMultiplier;
        if (Math.Abs(JoyPosition.x) > JoyTrip)
            JoyPosition.x = JoyTrip * Math.Abs(JoyPosition.x) / JoyPosition.x;
        if (JoyPosition != joysticGameObject.transform.position)
            joysticGameObject.transform.position = Vector3.Lerp(joysticGameObject.transform.position, JoyPosition, JoysticSpeed * Time.deltaTime);
    }

    void OnMouseDown()
    {
        SetVector(Input.mousePosition.x);
        ChangeJoySprite(joyPressSprite);
    }

    void OnMouseUp()
    {
        ChangeJoySprite(joyStartSprite);
        vector = 0;
    }

    void OnMouseDrag()
    {
        SetVector(Input.mousePosition.x);
    }

    private void SetVector(float v3x)
    {
        vector = (v3x - Screen.width / 2) * 4 / Screen.width;
        if (Mathf.Abs(vector) > 1) vector = 1 * Mathf.Abs(vector) / vector;
    }

    private void ChangeJoySprite(Sprite expSprite)
    {
        if (((SpriteRenderer)joysticGameObject.GetComponent("SpriteRenderer")).sprite != expSprite)
            ((SpriteRenderer)joysticGameObject.GetComponent("SpriteRenderer")).sprite = expSprite;
    }
}
