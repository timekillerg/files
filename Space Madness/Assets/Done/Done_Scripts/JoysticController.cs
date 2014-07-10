using UnityEngine;
using System.Collections;
using AssemblyCSharp;
using System;

public class JoysticController : MonoBehaviour
{
    public GameObject playerGameObject;
    public GameObject joysticGameObject;
    public Sprite joyPressedSprite;
    public Sprite joyInitialSprite;

    public float playerSpeed;

    public float joysticSpeed;
    public float joyMoveXLesser;

    public float xMultiplier;
    public float tilt;
    private float moveXPlayerPos = 0;
    private float moveXJoyPos = 0;

    private Vector3 playerPosition;
    private Vector3 joyPosition;

    private float speedLimiter = 2;   

    void Update()
    {
        playerPosition = playerGameObject.transform.position;
        joyPosition = joysticGameObject.transform.position;

        var differ = Math.Abs(moveXJoyPos);
        differ = 1 + differ / 10;

        if (moveXPlayerPos != 0 && playerPosition.x != moveXPlayerPos)
        {
            playerGameObject.rigidbody.rotation = Quaternion.Euler(270 + (playerPosition.x - moveXPlayerPos) * tilt, 270, 0.0f);
            playerPosition.x = moveXPlayerPos;
            playerGameObject.transform.position = Vector3.MoveTowards(playerGameObject.transform.position, playerPosition, playerSpeed * Time.deltaTime * differ);
          
        }
        else
            playerGameObject.rigidbody.rotation = Quaternion.Euler(270, 270, 0.0f);


        if (moveXJoyPos != joysticGameObject.transform.position.x)
        {
            joyPosition.x = moveXJoyPos;
            joysticGameObject.transform.position = Vector3.Lerp(joysticGameObject.transform.position, joyPosition, joysticSpeed * Time.deltaTime);
        }
    }

    void OnMouseDown()
    {
        ChangeMovePosition(Input.mousePosition.x);
        ChangeJoySprite(joyInitialSprite);
    }

    void OnMouseUp()
    {
        ChangeJoySprite(joyPressedSprite);
        moveXPlayerPos = 0;
        moveXJoyPos = 0;
    }

    void OnMouseDrag()
    {
        ChangeMovePosition(Input.mousePosition.x);
    }

    private void ChangeMovePosition(float v3x)
    {
        moveXPlayerPos = (v3x - Screen.width / 2) * xMultiplier / Screen.width;
        moveXJoyPos = moveXPlayerPos * joyMoveXLesser;
    }


    private void ChangeJoySprite(Sprite expSprite)
    {
        if (((SpriteRenderer)joysticGameObject.GetComponent("SpriteRenderer")).sprite != expSprite)
            ((SpriteRenderer)joysticGameObject.GetComponent("SpriteRenderer")).sprite = expSprite;
    }
}
