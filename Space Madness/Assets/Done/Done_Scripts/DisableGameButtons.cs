using UnityEngine;
using System.Collections;
using AssemblyCSharp;

public class DisableGameButtons : MonoBehaviour {

    private Vector3 V3_HIDEN = Vector3.zero;
    private Vector3 V3_ON_SCREEN = Vector3.zero;
    private Vector3 V3_DELTA = new Vector3(0.2f, 0.2f, 0.2f);

    private float speed = 4;

    private void Start()
    {
        if (gameObject.name == "Font down")
        {
            V3_HIDEN = new Vector3(0.0f, 8.0f, -9f);
            V3_ON_SCREEN = new Vector3(0.0f, 8.0f, -4.5f);
        }

        if (gameObject.name == "Font top")
        {
            V3_HIDEN = new Vector3(0.0f, 8.0f, 18.5f);
            V3_ON_SCREEN = new Vector3(0.0f, 8.0f, 15.0f);
        }
    }

    private void MoveAndStopStopAtPosition(GameObject go, Vector3 expectedPosition)
    {
        go.rigidbody.velocity = Vector3.zero;
        go.rigidbody.transform.position = Vector3.Lerp(go.transform.position, expectedPosition, Time.fixedDeltaTime * speed);
        if (go.rigidbody.position.x >= (expectedPosition.x - V3_DELTA.x) && go.rigidbody.position.x <= (expectedPosition.x + V3_DELTA.x))
            go.rigidbody.velocity = Vector3.zero;
    }

    void Update()
    {
        if (Time.timeScale == 0.0f)
        {
            MoveAndStopStopAtPosition(this.gameObject, V3_ON_SCREEN);
        }

        if (Time.timeScale != 0.0f && !GameCore.isShowStartCountDown)
        {
            MoveAndStopStopAtPosition(this.gameObject, V3_HIDEN);
        }
    }
}
