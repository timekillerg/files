using UnityEngine;
using System.Collections;
using AssemblyCSharp;

[System.Serializable]
public class Done_Boundary
{
    public float xMin, xMax, zMin, zMax;
}

public class Done_PlayerController : MonoBehaviour
{
    public float speed;
    public float tilt;
    public Done_Boundary boundary;

    public bool enableTouchPlayerControl;
    public bool enableMousePlayerControl;
    public bool enableKeyboardPlayerControl;

    void FixedUpdate()
    {
        if(enableTouchPlayerControl)
            LoadTouchEvents();
        if(enableMousePlayerControl)
            LoadMouseEvents();
        if(enableKeyboardPlayerControl)
            MovePlayerFromKeyboard();
    }

    void LoadTouchEvents()
    {
        if (Input.touchCount > 0)
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.GetTouch(0).position);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit, 100))
            {
                if (hit.collider.tag == "LeftButton")
                {
                    rigidbody.velocity = Vector3.left * speed;
                }
                if (hit.collider.tag == "RightButton")
                {
                    rigidbody.velocity = Vector3.right * speed;
                }
            }
        }
        rigidbody.position = new Vector3
            (
                Mathf.Clamp(rigidbody.position.x, boundary.xMin, boundary.xMax),
                0.0f,
                Mathf.Clamp(rigidbody.position.z, boundary.zMin, boundary.zMax)
                );

        if (Input.touchCount == 0)
        {
            rigidbody.velocity = Vector3.zero;
        }
        rigidbody.rotation = Quaternion.Euler(0.0f, 0.0f, rigidbody.velocity.x * -tilt);

    }

    void LoadMouseEvents()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit, 100))
            {
                if (hit.collider.tag == "LeftButton")
                {
                    rigidbody.velocity = Vector3.left * speed;
                }
                if (hit.collider.tag == "RightButton")
                {
                    rigidbody.velocity = Vector3.right * speed;
                }
            }
        }
        rigidbody.position = new Vector3
            (
                Mathf.Clamp(rigidbody.position.x, boundary.xMin, boundary.xMax),
                0.0f,
                Mathf.Clamp(rigidbody.position.z, boundary.zMin, boundary.zMax)
                );

        if (Input.GetMouseButtonUp(0))
        {
            rigidbody.velocity = Vector3.zero;
        }
        rigidbody.rotation = Quaternion.Euler(0.0f, 0.0f, rigidbody.velocity.x * -tilt);
    }

    void MovePlayerFromKeyboard()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);
        rigidbody.velocity = movement * speed * 3;

        rigidbody.position = new Vector3
        (
            Mathf.Clamp(rigidbody.position.x, boundary.xMin, boundary.xMax),
            0.0f,
            Mathf.Clamp(rigidbody.position.z, boundary.zMin, boundary.zMax)
        );

        rigidbody.rotation = Quaternion.Euler(0.0f, 0.0f, rigidbody.velocity.x * -tilt);
    }
}
